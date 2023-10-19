import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { CalculationsInput } from '../../common/calculations/calculationsInput';
import { ResultData } from '../../common/resultData/resultData';
import { ProgressService } from './progress.service';
import { progressStep } from '../../common/progress/progressProvider';
import { delay } from '../../common/utils/delay';
import { tap, map, mergeMap, concatMap, takeWhile, distinctUntilChanged } from 'rxjs/operators';
import { progressMessageComparer } from '../../common/progress/progressResponse';
import { environment } from '../../environments/environment';
import { interval } from 'rxjs';


@Injectable()
export class CalculationService {

  constructor(private httpService: HttpService, private progressService: ProgressService) { }

  public async calculate(inputData: CalculationsInput): Promise<ResultData> {

    this.progressService.setStep(progressStep.gatheringData);
    const operationId = await this.httpService.startCalculations(inputData);

    await this.waitForFinish(operationId);

    const indexesResponse = await this.httpService.getResultIndexes(operationId);

    const partsPromises = indexesResponse.indexes.map(e => this.httpService.getResults(operationId, e));

    const partsResponses = await Promise.all(partsPromises);

    const timeResults = partsResponses.map(e => e.timeResults).reduce((prev, next) => [...prev, ...next]);

    const result = {
      timeSettings: partsResponses[0].timeSettings,
      maxAbsoluteDisplacement: partsResponses[0].maxAbsoluteDisplacement,
      timeResults
    };

    return result;
  }


  private async waitForFinish(guid: string): Promise<void> {

    await interval(5000).pipe(
      tap(value => this.log(value)),
      concatMap(() => this.httpService.getProgress(guid)),
      distinctUntilChanged((prev, next) => progressMessageComparer.equals(prev, next)),
      tap(response => this.progressService.setStep(response.progress)),
      tap(response => this.log(response)),
      takeWhile(response => !response.hasResult)
    ).toPromise();

  }

  private log(value: any): void {
    if (!environment.production) {
      console.log(value);
    }
  }

}

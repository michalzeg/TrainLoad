import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CalculationsInput } from '../../common/calculations/calculationsInput';
import { ResultData } from '../../common/resultData/resultData';
import { ProgressResponse } from '../../common/progress/progressResponse';
import { environment } from '../../environments/environment';
import { ResultIndexes } from '../../common/resultIndexes/resultIndexes';

const baseUrl = environment.production ? '' : 'http://localhost:5000';

const startUrl = () => `${baseUrl}/api/TrainLoadApi`;
const progressUrl = operationId => `${baseUrl}/api/TrainLoadApi/${operationId}/Progress`;
const resultUrl = (operationId, index) => `${baseUrl}/api/TrainLoadApi/${operationId}/Result/${index}`;
const resultIndexexUrl = operationId => `${baseUrl}/api/TrainLoadApi/${operationId}/Result/Indexes`;
@Injectable()
export class HttpService {


  constructor(private http: HttpClient) {

  }
  public async startCalculations(inputData: CalculationsInput): Promise<string> {
    const result = await this.http.post<string>(startUrl(), inputData).toPromise();
    return result;
  }

  public async getProgress(operationId: string): Promise<ProgressResponse> {
    const response = await this.http.get<ProgressResponse>(progressUrl(operationId)).toPromise();
    return response;
  }

  public async getResults(operationId: string, index: number): Promise<ResultData> {
    const result = await this.http.get<ResultData>(resultUrl(operationId, index)).toPromise();
    return result;
  }

  public async getResultIndexes(operationId: string): Promise<ResultIndexes> {
    const result = await this.http.get<ResultIndexes>(resultIndexexUrl(operationId)).toPromise();
    return result;
  }
}

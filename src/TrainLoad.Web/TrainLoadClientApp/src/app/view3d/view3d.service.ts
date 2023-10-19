import { Injectable } from '@angular/core';
import * as THREE from 'three';
import { StructureGeometry } from '../../common/structure/structureGeometry';
import { TimeProvider } from '../../common/time/timeProvider';
import { mockedStructureGeometry } from '../../common/startData/mockedStructureGeometry';
import { ResultData } from '../../common/resultData/resultData';
import { MovingLoad } from '../../common/movingLoad/movingLoad';
import { AccelerationGaugeService } from '../services/acceleration-gauge.service';
import { ThreeJsCreator } from '../drawing-3d-base/model-3d/three-js-creator';
import { StructureCreator } from '../drawing-3d-base/model-3d/structure-creator/structure-creator';
import { ResultCreator } from '../drawing-3d-base/model-3d/results-creator/result-creator';
import { ResultProvider } from '../drawing-3d-base/model-3d/results-creator/result-provider';
import { MovingLoadCreator } from '../drawing-3d-base/model-3d/moving-load-creator/moving-load-creator';
import { StructureData } from '../drawing-3d-base/model-3d/structure-creator/structure-data';




@Injectable()
export class View3dService {

  private threeJsCreator: ThreeJsCreator;
  private structureGeometry: StructureGeometry;
  private structureCreator: StructureCreator;
  private resultCreator: ResultCreator;
  private resultProvider: ResultProvider;
  private timeProvider: TimeProvider;
  private movingLoadCreator: MovingLoadCreator;

  constructor(private accelerationGaugeService: AccelerationGaugeService) {
  }

  public InjectModelCreator(threeJsCreator: ThreeJsCreator): void {
    this.threeJsCreator = threeJsCreator;

    this.structureCreator = new StructureCreator(this.threeJsCreator.getScene());
    this.resultCreator = new ResultCreator(this.threeJsCreator.getScene());
    this.movingLoadCreator = new MovingLoadCreator(this.threeJsCreator.getScene());
  }

  public drawStructure(structureGeometry: StructureGeometry): void {
    this.structureGeometry = structureGeometry;
    this.structureCreator.draw(structureGeometry);
    this.movingLoadCreator.reset();
    this.threeJsCreator.tickAnimation = () => { };
  }

  public drawResults(results: ResultData, movingLoad: MovingLoad): void {
    this.timeProvider = new TimeProvider(results.timeSettings);
    this.resultProvider = new ResultProvider(results);
    this.resultCreator.setResult(this.resultProvider, this.structureCreator.structureData);
    this.movingLoadCreator.start(movingLoad, this.structureGeometry.getLength());
    this.threeJsCreator.tickAnimation = () => this.tick();
  }

  public getStructureGeometry(): StructureGeometry {
    return this.structureGeometry;
  }

  public getStructureData(): StructureData {
    return this.structureCreator.structureData;
  }


  private tick(): void {
    this.timeProvider.tick();
    const time = this.timeProvider.getCurrentTime();
    this.resultProvider.setTime(time);
    this.resultCreator.tickAnimation(time);
    this.movingLoadCreator.tickAnimation(time);
    this.accelerationGaugeService.setValue(this.resultProvider.getMaxAcceleration());
  }

}

import { Injectable } from '@angular/core';
import { Section } from '../../common/structure/section';
import { MovingLoad } from '../../common/movingLoad/movingLoad';
import { trainLoadInputFactory } from '../modal-train-load/input/trainLoadInputFactory';
import { startHSLMA } from '../../common/startData/mockedHSLMA';
import { Span } from '../../common/structure/span';
import { SectionType } from '../../common/types/sectionTypes';
import { TrainLoadType } from '../../common/types/trainLoadType';
import { Subject } from 'rxjs';



@Injectable()
export class StructureService {

  private sectionSource = new Subject<Section>();
  public section$ = this.sectionSource.asObservable();

  private trainLoadSource = new Subject<MovingLoad>();
  public trainLoad$ = this.trainLoadSource.asObservable();

  private spanSource = new Subject<Span>();
  public span$ = this.spanSource.asObservable();

  private sectionTypeSource = new Subject<SectionType>();
  public sectionType$ = this.sectionTypeSource.asObservable();

  private trainLoadTypeSource = new Subject<TrainLoadType>();
  public trainLoadType$ = this.trainLoadTypeSource.asObservable();

  constructor() {
  }

  public setSection(section: Section): void {
    this.sectionSource.next(section);
  }

  public setTrainLoad(trainLoad: MovingLoad): void {
    this.trainLoadSource.next(trainLoad);
  }

  public setSpan(span: Span): void {
    this.spanSource.next(span);
  }

  public setSectionType(sectionType: SectionType): void {
    this.sectionTypeSource.next(sectionType);
  }

  public setTrainLoadType(trainLoadType: TrainLoadType): void {
    this.trainLoadTypeSource.next(trainLoadType);
  }
}

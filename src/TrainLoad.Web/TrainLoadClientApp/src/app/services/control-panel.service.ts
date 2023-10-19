import { Injectable } from '@angular/core';
import { View3dService } from '../view3d/view3d.service';
import { calculationsInputBuilder } from '../../common/calculations/calculationInputBuilder';
import { StructureService } from '../services/structure.service';
import { Section } from '../../common/structure/section';
import { MovingLoad } from '../../common/movingLoad/movingLoad';
import { StatusBarService } from '../services/status-bar.service';
import { structureGeometryBuilder } from '../../common/structureGeometryBuilder/structureGeometryBuilder';
import { Span } from '../../common/structure/span';
import { AccelerationGaugeService } from './acceleration-gauge.service';
import { CalculationService } from './calculation.service';


@Injectable()
export class ControlPanelService {

  private section: Section;
  private movingLoad: MovingLoad;
  private span: Span;

  // tslint:disable-next-line:component-selector
  constructor(private calculationService: CalculationService,
    private view3dService: View3dService,
    private structureService: StructureService,
    private statusBarService: StatusBarService,
    private accelerationGaugeServie: AccelerationGaugeService) {

    this.structureService.section$.subscribe(e => {
      this.section = e;
      this.setStructure();
      this.statusBarService.setDirty();
      this.accelerationGaugeServie.setInvisible();
    });

    this.structureService.trainLoad$.subscribe(e => {
      this.movingLoad = e;
      this.setStructure();
      this.statusBarService.setDirty();
      this.accelerationGaugeServie.setInvisible();
    });

    this.structureService.span$.subscribe(e => {
      this.span = e;
      this.setStructure();
      this.statusBarService.setDirty();
      this.accelerationGaugeServie.setInvisible();
    });
  }

  calculate(): void {
    this.statusBarService.setStartCalculations();
    const input = calculationsInputBuilder()
      .setStructureGeometry(this.view3dService.getStructureGeometry())
      .setStructureData(this.view3dService.getStructureData())
      .setMovingLoad(this.movingLoad)
      .setTimeSettings()
      .build();

    this.calculationService.calculate(input).then(
      data => {
        this.view3dService.drawResults(data, this.movingLoad);
        this.statusBarService.setValid();
        this.accelerationGaugeServie.setVisible();
      },
      () => {
        this.statusBarService.setError();
      }

    );
  }

  setStructure(): void {
    if (!this.section || !this.span) {
      return;
    }

    const str = structureGeometryBuilder().setSection(this.section).setSpan(this.span).build();
    this.view3dService.drawStructure(str);
  }
}

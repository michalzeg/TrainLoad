import { Component, OnInit, AfterViewInit, ViewChild, ContentChild, ChangeDetectionStrategy } from '@angular/core';
import { mockedStructureGeometry } from '../../common/startData/mockedStructureGeometry';
import { Perimeter } from '../../common/structure/perimeter';
import { Section } from '../../common/structure/section';
import { section1Builder } from '../../common/sectionBuilders/section1Builder';
import { Drawing2dDirective } from './drawing2d.directive';
import { SectionDrawing } from '../drawing-2d-base/section-drawing';



@Component({
  // tslint:disable-next-line:component-selector
  selector: 'drawing2d',
  templateUrl: './drawing2d.component.html',
  styleUrls: ['./drawing2d.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class Drawing2dComponent implements AfterViewInit {

  @ViewChild(Drawing2dDirective)
  drawing2dElement: Drawing2dDirective;

  private sectionDrawing: SectionDrawing;

  constructor() {
  }

  draw(section: Section): void {
    this.sectionDrawing.draw(section);
  }

  reset(): void {
    this.sectionDrawing.reset();
  }

  ngAfterViewInit(): void {
    const canvasId = this.drawing2dElement.getCanvasId();
    this.sectionDrawing = new SectionDrawing(canvasId);
  }

}

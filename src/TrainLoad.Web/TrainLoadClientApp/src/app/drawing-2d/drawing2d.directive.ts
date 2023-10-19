declare var require: any;
import { Directive, ElementRef } from '@angular/core';
const Guid = require('guid');
const drawingClassName = 'drawing2d';

@Directive({
  // tslint:disable-next-line:directive-selector
  selector: '[drawing2dElement]',
})
export class Drawing2dDirective {

  constructor(private elementRef: ElementRef) { }

  public getCanvasId(): string {
    const canvasObject = this.elementRef;
    canvasObject.nativeElement.id = Guid.raw().toString();

    return canvasObject.nativeElement.id.toString();
  }
}

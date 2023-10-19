import { Directive, ElementRef, AfterViewInit } from '@angular/core';
import { startProgress } from './progress';


@Directive({
  // tslint:disable-next-line:directive-selector
  selector: '[Progress]'
})
export class ProgressDirective implements AfterViewInit {
  ngAfterViewInit(): void {
    const id = this.el.nativeElement.id;
    startProgress(id);
  }


  constructor(private el: ElementRef) {

  }

}

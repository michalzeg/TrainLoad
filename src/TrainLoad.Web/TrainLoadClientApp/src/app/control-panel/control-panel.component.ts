import { Component, OnInit, ChangeDetectorRef, AfterViewInit, OnDestroy } from '@angular/core';
import { View3dService } from '../view3d/view3d.service';
import { ControlPanelService } from '../services/control-panel.service';
import { StatusBarService } from '../services/status-bar.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css']
})
export class ControlPanelComponent implements AfterViewInit, OnDestroy {

  private destroying$: Subject<boolean> = new Subject<boolean>();

  valid = false;
  dirty = true;
  error = false;
  progress = false;

  constructor(private controlPanelService: ControlPanelService,
    private statusBarService: StatusBarService,
    private cdr: ChangeDetectorRef) { }

  ngAfterViewInit(): void {
    this.statusBarService.dirty$.pipe(takeUntil(this.destroying$)).subscribe(e => this.dirty = e);
    this.statusBarService.valid$.pipe(takeUntil(this.destroying$)).subscribe(e => this.valid = e);
    this.statusBarService.error$.pipe(takeUntil(this.destroying$)).subscribe(e => this.error = e);
    this.statusBarService.calculations$.pipe(takeUntil(this.destroying$)).subscribe(e => this.progress = e);

    this.cdr.detectChanges();
  }

  ngOnDestroy(): void {
    this.destroying$.next(true);
    this.destroying$.complete();
  }

  calculate(): void {
    this.controlPanelService.calculate();
  }



}

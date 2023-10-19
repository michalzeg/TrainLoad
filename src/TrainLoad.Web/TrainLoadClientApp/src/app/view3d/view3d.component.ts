import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { View3dService } from './view3d.service';
import { HttpService } from '../services/http.service';
import { ThreeJsCreator } from '../drawing-3d-base/model-3d/three-js-creator';



@Component({
  // tslint:disable-next-line:component-selector
  selector: 'view3d',
  templateUrl: './view3d.component.html',
  styleUrls: ['./view3d.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class View3DComponent implements OnInit {
  private threeJsCreator: ThreeJsCreator;
  constructor(private view3dService: View3dService, private httpService: HttpService) {
  }

  ngOnInit(): void {
    this.threeJsCreator = new ThreeJsCreator();
    this.threeJsCreator.create();
    this.view3dService.InjectModelCreator(this.threeJsCreator);
  }

}

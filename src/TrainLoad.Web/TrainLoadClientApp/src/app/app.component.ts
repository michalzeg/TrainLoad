import { Component, OnInit } from '@angular/core';
import { View3dService } from './view3d/view3d.service';
import { StructureService } from './services/structure.service';
import { LocalStorageService } from './services/local-storage.service';
import { SectionType } from '../common/types/sectionTypes';
import { sectionInputFactory } from './modal-section1/Input/sectionInputFactory';
import { trainLoadInputFactory } from './modal-train-load/input/trainLoadInputFactory';
import { InitializationService } from './services/initialization.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {


  title = 'app';

  constructor(private structureService: StructureService,
    private initializationService: InitializationService) { }

  ngOnInit(): void {
    setTimeout(() => {
      this.structureService.setSection(this.initializationService.section);
      this.structureService.setSectionType(this.initializationService.sectionType);
      this.structureService.setTrainLoad(this.initializationService.trainLoad);
      this.structureService.setTrainLoadType(this.initializationService.trainLoadType);
      this.structureService.setSpan(this.initializationService.span);
    }, 200);
  }

}

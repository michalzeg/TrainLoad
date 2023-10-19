import * as THREE from 'three';
import { StructureGeometry } from '../../../../common/structure/structureGeometry';
import { BaseCreator } from './base-creator';
import { BarsCreator } from './bars-creator';
import { StructureData } from './structure-data';
import { SupportCreator } from './support-creator';




export class StructureCreator extends BaseCreator {
    private barsCreator: BarsCreator;
    private supportCreator: SupportCreator;

    public structureData: StructureData;

    constructor(scene: THREE.Scene) {
        super(scene);
        this.barsCreator = new BarsCreator(this.scene);
        this.supportCreator = new SupportCreator(this.scene);
    }

    public draw(structureGeometry: StructureGeometry): void {
        if (structureGeometry === undefined || this.scene === undefined) {
            return;
        }
        this.structureData = new StructureData();
        this.clearGeometry();
        this.barsCreator.drawBars(structureGeometry.bars, this.structureData);
        this.supportCreator.drawSupports(structureGeometry.supports, structureGeometry.getBottomWidth());
    }
}

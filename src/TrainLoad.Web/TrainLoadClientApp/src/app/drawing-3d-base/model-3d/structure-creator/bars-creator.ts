declare var require: any;
import * as THREE from 'three';
import { Bar } from '../../../../common/structure/bar';
import { BaseCreator } from './base-creator';
import { StructureData } from './structure-data';
import { getExtrudeSettings } from './extrude-settings';
import { color, colorName, material } from '../material';

const Guid = require('guid');

export class BarsCreator extends BaseCreator {
    private structureData: StructureData;
    constructor(scene: THREE.Scene) {
        super(scene);
    }

    public drawBars(bars: Array<Bar>, structureData: StructureData): void {
        this.structureData = structureData;
        bars.forEach(bar => this.drawBar(bar));
    }

    private drawBar(bar: Bar): void {
        const length = bar.getLength();
        const extrudeSettings = getExtrudeSettings(length);

        bar.section.perimeters.forEach(perimeter => {
            const coordinates = perimeter.coordinates;
            const x0 = coordinates[0].x;
            const y0 = coordinates[0].y;

            const shape = new THREE.Shape();
            shape.moveTo(x0, y0);

            coordinates.slice(1).forEach(point => {
                shape.lineTo(point.x, point.y);
            });

            const geometry = new THREE.ExtrudeGeometry(shape, extrudeSettings);


            geometry.translate(bar.startPoint.x, bar.startPoint.y, bar.startPoint.z);

            const colors = [];
            for (let index = 0; index < geometry.attributes.position.array.length; index = index + 3) {
                colors[index] = color.r;
                colors[index + 1] = color.g;
                colors[index + 2] = color.b;
            }


            const colorAttribute = new THREE.BufferAttribute(new Float32Array(colors), 3);
            colorAttribute.setUsage(THREE.DynamicDrawUsage);
            geometry.setAttribute('color', colorAttribute);


            const mesh = new THREE.Mesh(geometry, material);

            this.structureData.add(geometry, mesh.uuid, bar.id);
            this.scene.add(mesh);
        });
    }
}

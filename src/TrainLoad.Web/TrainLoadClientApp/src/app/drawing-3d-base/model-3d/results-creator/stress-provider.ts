import * as THREE from 'three';
import { StructureData } from '../structure-creator/structure-data';
import { ResultProvider } from './result-provider';



export class StressProvider {
    private structureData: StructureData;
    private scene: THREE.Scene;
    private resultProvider: ResultProvider;
    private meshes: Array<THREE.Mesh>;

    constructor(scene: THREE.Scene, resultProvider: ResultProvider, structureData: StructureData) {
        this.scene = scene;
        this.resultProvider = resultProvider;
        this.structureData = structureData;
        this.meshes = this.scene.children
            .filter(e => e.type === 'Mesh' && structureData.isStructureMesh(e.uuid))
            .map(e => e as THREE.Mesh)
            ;
    }

    public applyStress(): void {

        for (let i = 0; i < this.meshes.length; i++) {
            const mesh = this.meshes[i];

            const baseGeometry = this.structureData.getGeometryByMeshId(mesh.uuid);
            const positions = baseGeometry.attributes.position.array;

            const colors = [];
            for (let j = 0; j < positions.length; j = j + 3) {

                const vertex = {
                    x: positions[j],
                    y: positions[j + 1],
                    z: positions[j + 2]
                };
                const color = this.resultProvider.getColor(vertex, mesh.uuid);
                colors[j] = color.r;
                colors[j + 1] = color.g;
                colors[j + 2] = color.b;
            }

            const colorAttribute = new THREE.BufferAttribute(new Float32Array(colors), 3);
            colorAttribute.setUsage(THREE.DynamicDrawUsage);
            mesh.geometry.setAttribute('color', colorAttribute);
        }
    }

}

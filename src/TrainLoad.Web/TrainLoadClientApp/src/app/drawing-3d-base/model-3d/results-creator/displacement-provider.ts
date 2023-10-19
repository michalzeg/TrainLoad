import * as THREE from 'three';
import { StructureData } from '../structure-creator/structure-data';
import { ResultProvider } from './result-provider';


const scaleFactor = 4;

export class DisplacementProvider {
    private structureData: StructureData;
    private scene: THREE.Scene;
    private resultProvider: ResultProvider;
    private displacementScale: number;
    private meshes: Array<THREE.Mesh>;

    constructor(scene: THREE.Scene, resultProvider: ResultProvider, structureData: StructureData) {
        this.scene = scene;
        this.resultProvider = resultProvider;
        this.structureData = structureData;

        this.calculateDisplacementScale();
        this.meshes = this.scene.children
            .filter(e => e.type === 'Mesh' && structureData.isStructureMesh(e.uuid))
            .map(e => e as THREE.Mesh)
            ;
    }

    public applyDisplacement(): void {
        for (let i = 0; i < this.meshes.length; i++) {
            const mesh = this.meshes[i];
            const baseGeometry = this.structureData.getGeometryByMeshId(mesh.uuid);
            const vertices = mesh.geometry.attributes.position.array;
            mesh.geometry.attributes.position.needsUpdate = true;
            const baseVertices = baseGeometry.attributes.position.array;

            const newPostions = new Float32Array(baseVertices.length);

            for (let j = 0; j < vertices.length; j = j + 3) {

                const basePosition = {
                    x: baseVertices[j],
                    y: baseVertices[j + 1],
                    z: baseVertices[j + 2]
                };
                const displacement = this.resultProvider.getDisplacement(basePosition, mesh.uuid);
                const dy = displacement * this.displacementScale;

                newPostions[j] = basePosition.x;
                newPostions[j + 1] = basePosition.y + dy;
                newPostions[j + 2] = basePosition.z;
            }

            const positionAttribute = new THREE.BufferAttribute(newPostions, 3);
            positionAttribute.setUsage(THREE.DynamicDrawUsage);
            mesh.geometry.setAttribute('position', positionAttribute);

            mesh.geometry.computeVertexNormals();
        }
    }

    private calculateDisplacementScale(): void {
        const maxDisplacement = this.resultProvider.getMaxDisplacement();
        this.displacementScale = scaleFactor / maxDisplacement;
    }
}

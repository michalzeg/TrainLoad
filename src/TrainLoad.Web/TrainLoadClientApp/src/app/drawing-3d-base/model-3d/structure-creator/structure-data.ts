import * as THREE from 'three';
import { Point3D } from '../../../../common/utils/point3d';



export class StructureData {

    private meshIdBarIdMap: Map<string, string>;
    private meshIdGeometryMap: Map<string, THREE.BufferGeometry>;

    constructor() {
        this.meshIdGeometryMap = new Map<string, THREE.BufferGeometry>();
        this.meshIdBarIdMap = new Map<string, string>();

    }

    public add(geometry: THREE.BufferGeometry, meshId: string, barId: string): void {


        this.meshIdGeometryMap.set(meshId, geometry.clone());
        this.meshIdBarIdMap.set(meshId, barId);
    }
    public getGeometryByMeshId(meshId: string): THREE.BufferGeometry {

        const geometry = this.meshIdGeometryMap.get(meshId);
        return geometry;
    }

    public getVerticesByMeshId(meshId: string): Array<Point3D> {
        const geometry = this.meshIdGeometryMap.get(meshId);

        const points = geometry.attributes.position.array;

        const result = [];
        for (let index = 0; index < points.length; index = index + 3) {
            result.push({
                X: points[index],
                Y: points[index + 1],
                Z: points[index + 2]
            });
        }



        return result;
    }

    public getMeshIds(): Array<string> {
        const result = Array.from(this.meshIdBarIdMap.keys());
        return result;
    }

    public getBarIdFromMeshId(meshId: string): string {
        const result = this.meshIdBarIdMap.get(meshId);
        return result;
    }

    public isStructureMesh(meshId: string): boolean {
        const result = this.meshIdGeometryMap.has(meshId);
        return result;
    }
}

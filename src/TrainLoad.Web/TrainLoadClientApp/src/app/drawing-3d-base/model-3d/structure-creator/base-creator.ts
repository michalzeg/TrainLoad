import * as THREE from 'three';

export class BaseCreator {
    protected scene: THREE.Scene;

    constructor(scene: THREE.Scene) {
        this.scene = scene;
    }

    protected clearGeometry(): void {
        const geometryObjects = this.scene.children.filter(e => e instanceof THREE.Mesh).map(e => e as THREE.Mesh).filter(e => e.isMesh);
        for (const geometry of geometryObjects) {
            this.scene.remove(geometry);
        }
    }
}

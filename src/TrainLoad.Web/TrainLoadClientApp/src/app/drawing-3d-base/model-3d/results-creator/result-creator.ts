import { ResultProvider } from './result-provider';
import { DisplacementProvider } from './displacement-provider';
import { StressProvider } from './stress-provider';
import { StructureData } from '../structure-creator/structure-data';



export class ResultCreator {
    private scene: THREE.Scene;

    private resultProvider: ResultProvider;
    private displacementProvider: DisplacementProvider;
    private stressProvider: StressProvider;

    constructor(scene: THREE.Scene) {
        this.scene = scene;
    }

    public setResult(resultProvider: ResultProvider, structureData: StructureData): void {

        this.resultProvider = resultProvider;
        this.displacementProvider = new DisplacementProvider(this.scene, this.resultProvider, structureData);
        this.stressProvider = new StressProvider(this.scene, this.resultProvider, structureData);
    }

    public tickAnimation(time: number): void {
        this.displacementProvider.applyDisplacement();
        this.stressProvider.applyStress();
    }
}

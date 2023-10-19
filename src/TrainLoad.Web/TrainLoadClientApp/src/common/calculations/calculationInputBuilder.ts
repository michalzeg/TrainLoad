import { StructureGeometry } from '../structure/structureGeometry';
import { CalculationsInput } from './calculationsInput';
import { MeshInput } from './meshInput';
import { MovingLoad } from '../movingLoad/movingLoad';
import { TimeSettings } from '../time/timeSettings';
import { StructureData } from '../../app/drawing-3d-base/model-3d/structure-creator/structure-data';



const extraTimeFactor = 1;

export function calculationsInputBuilder() {

    const calculationsInput = new CalculationsInput();

    function setStructureGeometry(structureGeometry: StructureGeometry) {
        calculationsInput.structureGeometry = structureGeometry;
        return { setStructureData };
    }

    function setStructureData(structureData: StructureData) {
        const meshIds = structureData.getMeshIds();

        const vertices = meshIds.map(meshId => {
            const barVertices = structureData.getVerticesByMeshId(meshId);
            const barId = structureData.getBarIdFromMeshId(meshId);
            const vertexInput: MeshInput = {
                barId,
                meshId,
                vertices: barVertices,
            };
            return vertexInput;
        });
        calculationsInput.vertices = vertices;
        return { setMovingLoad };
    }
    function setMovingLoad(movingLoad: MovingLoad) {
        calculationsInput.movingLoads = movingLoad;
        return { setTimeSettings };
    }
    function setTimeSettings() {
        const timeSettings = new TimeSettings();
        const structureLength = calculationsInput.structureGeometry.getLength();
        const loadLength = calculationsInput.movingLoads.getLength();

        const endTime = ((structureLength + loadLength) / calculationsInput.movingLoads.speed) * extraTimeFactor;
        timeSettings.endTime = Math.ceil(endTime);
        calculationsInput.timeSettings = timeSettings;
        return { build };
    }
    function build(): CalculationsInput {
        return calculationsInput;
    }

    return { setStructureGeometry };
}


import { ModelInput } from '../../input/modelInput';
import { HSLMAFromInput } from './HSLMA/HSLMAFromInput';
import { HSLMAInput } from './HSLMA/HSLMAInput';
import { HSLMBInput } from './HSLMB/HSLMBInput';
import { HSLMBFromInput } from './HSLMB/HSLMBFromInput';
import { TrainLoadType } from '../../../common/types/trainLoadType';
import { MovingLoad } from 'src/common/movingLoad/movingLoad';



export function trainLoadInputFactory() {

    return { getInput, getTrainLoadBuilder };

    function getInput(type: TrainLoadType | string): ModelInput[] {
        switch (type) {
            case TrainLoadType.HSLMA: {
                return JSON.parse(JSON.stringify(HSLMAInput));
            }
            case TrainLoadType.HSLMB: {
                return JSON.parse(JSON.stringify(HSLMBInput));
            }
        }
    }

    function getTrainLoadBuilder(type: TrainLoadType) {
        switch (type) {
            case TrainLoadType.HSLMA: {
                return { FromInput: HSLMAFromInput };
            }
            case TrainLoadType.HSLMB: {
                return { FromInput: HSLMBFromInput };
            }
        }
    }
}

import { TrainLoadType } from '../../../common/types/trainLoadType';
import { environment } from '../../../environments/environment';

export const trainLoadTitleFactory = {};
trainLoadTitleFactory[TrainLoadType.HSLMA] = 'Train Load - HSLM-A';
trainLoadTitleFactory[TrainLoadType.HSLMB] = 'Train Load - HSLM-B';

export const trainLoadImagePathFactory = {};
trainLoadImagePathFactory[TrainLoadType.HSLMA] = environment.production
    ? '/TrainLoadClientApp/dist/assets/HSLM-A.svg'
    : './assets/HSLM-A.svg';
trainLoadImagePathFactory[TrainLoadType.HSLMB] = environment.production
    ? '/TrainLoadClientApp/dist/assets/HSLM-B.svg'
    : './assets/HSLM-B.svg';


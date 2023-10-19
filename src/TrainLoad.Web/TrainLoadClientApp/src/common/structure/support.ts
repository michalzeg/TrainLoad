import { Point3D } from '../utils/point3d';

export interface Support {
    location: Point3D;
    direction: string;
}

export function VerticalSupportCreator(location: Point3D): Support {
    return {
        location,
        direction: 'UX',
    };
}

export function HorizontalSupportCreator(location: Point3D): Support {
    return {
        location,
        direction: 'UY',
    };
}

export function OrtogonalSupportCreator(location: Point3D): Support {
    return {
        location,
        direction: 'UX|UY',
    };
}


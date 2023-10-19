import { Section } from './section';
import { Additional } from './additional';
import { Point3D } from '../utils/point3d';
import { Bar } from './bar';
import { Support } from './support';


export class StructureGeometry {
    bars: Array<Bar>;
    supports: Array<Support>;

    public getLength(): number {
        const xs = this.bars.map(bar => [bar.startPoint.z, bar.endPoint.z])
            .reduce((a, b) => a.concat(b));
        const maxX = Math.max(...xs);
        const minX = Math.min(...xs);
        const length = maxX - minX;
        return length;
    }

    public getBottomWidth(): number {
        return this.bars[0].section.getBottomWidth();
    }
}

import { StructureGeometry } from '../structure/structureGeometry';
import { Section } from '../structure/section';
import { Span } from '../structure/span';
import { Bar } from '../structure/bar';
import { Point } from '../utils/point';
import { Point3D } from '../utils/point3d';
import { Support, OrtogonalSupportCreator } from '../structure/support';

const barSplitCount = 2;

export function structureGeometryBuilder() {
    const structure = new StructureGeometry();
    let section: Section;
    let span: Span;

    return { setSection };

    function setSection(sectionValue: Section) {
        section = sectionValue;
        return { setSpan };
    }

    function setSpan(spanValue: Span) {
        span = spanValue;
        return { build };
    }

    function genertateSupports(): Support[] {
        const supports: Support[] = [];
        supports.push(OrtogonalSupportCreator({ x: 0, y: 0, z: 0 }));
        supports.push(OrtogonalSupportCreator({ x: 0, y: 0, z: span.lengths[0] }));
        if (span.lengths.length === 2) {
            supports.push(OrtogonalSupportCreator({ x: 0, y: 0, z: span.lengths[0] + span.lengths[1] }));
        }

        return supports;
    }

    function generateBars(): Bar[] {
        const length = span.lengths.reduce((a, e) => a + e);
        const bars: Bar[] = [];
        const barLength = span.lengths[0] / barSplitCount;
        for (let i = 0; i < span.lengths.length * barSplitCount; i++) {
            const bar = new Bar();
            bar.section = section;
            bar.startPoint = { x: 0, y: 0, z: i * barLength };
            bar.endPoint = { x: 0, y: 0, z: (i + 1) * barLength };
            bars.push(bar);
        }

        return bars;
    }

    function build(): StructureGeometry {
      structure.bars = generateBars();
      structure.supports = genertateSupports();
      return structure;
  }
}

declare var require: any;
const ProgressBar = require('progressbar.js');


export function startProgress(id: string): void {
    const circle = new ProgressBar.Circle(`#${id}`, {
        color: '#5bc0de',
        trailColor: '#eee',
        trailWidth: 1,
        duration: 1000,
        easing: 'bounce',
        strokeWidth: 6,
        text: {
            autoStyleContainer: false
        },
        from: { color: '#5bc0de', a: 0 },
        to: { color: '##2c78b2', a: 1 },
        // Set default step function for all animate calls
        step: (state: { color: any; },
          // tslint:disable-next-line:max-line-length
          c: { path: { setAttribute: (arg0: string, arg1: any) => void; }; value: () => number; setText: (arg0: string) => void; }): void => {
          c.path.setAttribute('stroke', state.color);

          const value = Math.round(c.value() * 100);

          if (value < 0.1) {
            c.setText('');
          } else if (value < 30) {
            c.setText('.');
          } else if (value < 60) {
            c.setText('..');
          } else {
            c.setText('...');
          }
        }
    });

    circle.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
    circle.text.style.fontSize = '2rem';

    circle.animate(1, loop);
    circle.setText('Processing');
    function loop(): void {
        const value = circle.value() < 0.01 ? 1 : 0;
        try {
            circle.animate(value, loop);
        }
        catch (error) {
            console.log(error);
        }
    }
}

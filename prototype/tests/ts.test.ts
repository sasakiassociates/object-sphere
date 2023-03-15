import { writeFileSync } from 'fs';
import { getSnapshot, SnapshotOutOf } from 'mobx-keystone';

import { serialize, deserialize } from '../ts/Onto';
import Point from '../ts/Point';
import Normal from '../ts/Normal';
import NormalPoint from '../ts/NormalPoint';
import ResultCloudData from '../ts/ResultCloudData';
import ResultCloud from '../ts/ResultCloud';
import Result from '../ts/Result';


new Point({});
new Normal({});
new NormalPoint({});
new ResultCloudData({});
new ResultCloud({});
new Result({});


function RandomResult(): Result {
    return new Result({
        ResultCloud: makeupto(10).map(_ => new ResultCloud({
            ResultCloudData: new ResultCloudData({ some: data(), data: data(), right: data(), here: data() }),
            NormalPoint: makeupto(30).map(_ => new NormalPoint({
                Point: new Point({ x: rand(10), y: rand(10), z: rand(10) }),
                Normal: new Normal({ x: rand(10), y: rand(10), z: rand(10) }),
            }))
        }))
    });
}

function concat(a: any[], b: any[]): any[] {
    return [...a, ...b];
}

function data() {
    return ['some', 'data', 'right', 'here'][Math.floor(rand(4))];
}

function rand(ceil: number): number {
    return Math.round(Math.random() * ceil);
}

function make(quantity: number): string[] {
    return Array.from('x'.repeat(quantity));
}

function makeupto(ceil: number): string[] {
    return make(rand(ceil-1)+1);
}


const result = RandomResult();

const snap = deserialize(result, serialize(result));

console.log(JSON.stringify(snap, null, 2));

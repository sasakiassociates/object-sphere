import { Model, model, prop } from 'mobx-keystone';

import { Point as IPoint } from './types';


@model('onto/Point')
class Point extends Model({
    x: prop<number>(0),
    y: prop<number>(0),
    z: prop<number>(0),
}) implements IPoint {}

export default Point;

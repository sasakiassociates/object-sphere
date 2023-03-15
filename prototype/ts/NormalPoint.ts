import { ExtendedModel, model, prop } from 'mobx-keystone';

import Onto from './Onto';
import Point from './Point';
import Normal from './Normal';
import { NormalPoint as INormalPoint } from './types';


@model('onto/NormalPoint')
class NormalPoint extends ExtendedModel(Onto, {
    Point: prop<Point>(() => new Point({})),
    Normal: prop<Normal>(() => new Normal({})),
}) implements INormalPoint {};

export default NormalPoint;

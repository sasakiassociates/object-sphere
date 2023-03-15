import { ExtendedModel, model } from 'mobx-keystone';

import Point from './Point';
import { Normal as INormal } from './types';


@model('onto/Normal')
class Normal extends ExtendedModel(Point, {}) implements INormal {}

export default Normal;

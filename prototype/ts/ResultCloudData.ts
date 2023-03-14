import { ExtendedModel, model, prop } from 'mobx-keystone';

import Onto from './Onto';
import { ResultCloudData as IResultCloudData } from './types';


@model('onto/ResultCloudData')
class ResultCloudData extends ExtendedModel(Onto, {
    some: prop<string>(''),
    data: prop<string>(''),
    right: prop<string>(''),
    here: prop<string>(''),
}) implements IResultCloudData {};

export default ResultCloudData;

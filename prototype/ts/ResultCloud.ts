import { ExtendedModel, model, prop } from 'mobx-keystone';

import Onto from './Onto';
import NormalPoint from './NormalPoint';
import ResultCloudData from './ResultCloudData';
import { ResultCloud as IResultCloud } from './types';


@model('onto/ResultCloud')
class ResultCloud extends ExtendedModel(Onto, {
    ResultCloudData: prop<ResultCloudData>(() => new ResultCloudData({})),
    NormalPoint: prop<NormalPoint[]>(() => []),
}) implements IResultCloud {};

export default ResultCloud;

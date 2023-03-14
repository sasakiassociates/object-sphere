import { ExtendedModel, model, prop } from 'mobx-keystone';

import Onto from './Onto';
import ResultCloud from './ResultCloud';
import { Result as IResult } from './types';


@model('onto/Result')
class Result extends ExtendedModel(Onto, {
    ResultCloud: prop<ResultCloud[]>(() => []),
}) implements IResult {};

export default Result;

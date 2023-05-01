using GraphQLCodeGen;
using Stratosphere;


namespace Types {

    public class Result : OntoNode, Schema.Result {
        public List<ResultCloud> ResultCloud { get; set; }

        public Result(List<ResultCloud>? resultClouds) {
            this.ResultCloud = resultClouds ?? new List<ResultCloud>();
        }
    }

}

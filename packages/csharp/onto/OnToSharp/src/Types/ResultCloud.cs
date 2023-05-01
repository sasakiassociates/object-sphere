using GraphQLCodeGen;
using Stratosphere;


namespace Types {

    public class ResultCloud : OntoNode, Schema.ResultCloud {
        public ResultCloudData ResultCloudData { get; set; }
        public List<NormalPoint> NormalPoint { get; set; }

        public ResultCloud(ResultCloudData? resultCloudData, List<NormalPoint>? normalPoints) {
            this.NormalPoint = normalPoints ?? new List<NormalPoint>();
            this.ResultCloudData = resultCloudData ?? new ResultCloudData();
        }
        
    }

}

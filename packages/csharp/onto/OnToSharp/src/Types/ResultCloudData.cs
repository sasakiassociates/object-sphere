using GraphQLCodeGen;


namespace Types {

    public class ResultCloudData : Schema.ResultCloudData {
        public string data { get; set; }
        public string here { get; set; }
        public string right { get; set; }
        public string some { get; set; }

        public ResultCloudData(string some = "", string data = "", string right = "", string here = "") {
            this.some = some;
            this.data = data;
            this.right = right;
            this.here = here;
        }

        public override string ToString() => $"{some} {data} {right} {here}";
    }

}

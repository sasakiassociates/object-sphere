using GraphQLCodeGen;
using Stratosphere;


namespace Types {

    public class NormalPoint : OntoNode, Schema.NormalPoint {
        public Normal Normal { get; set; }
        public Point Point { get; set; }

        public NormalPoint(Normal? normal, Point? point) {
            this.Normal = normal ?? new Normal();
            this.Point = point ?? new Point();
        }
    }

}

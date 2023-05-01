using GraphQLCodeGen;


namespace Types {

    public class Point : Schema.Point {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Point(int x = 0, int y = 0, int z = 0) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

}

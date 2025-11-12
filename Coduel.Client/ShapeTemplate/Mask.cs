namespace Coduel.Client
{
    public class Mask
    {
        int X { get; set; }
        int Y { get; set; }
        Shape[] shapes;

        public Mask(int x, int y, Shape shape, params Shape[] shapes)
        {
            X = x;
            Y = y;
            List<Shape> temp = new List<Shape>();
            temp.Add(shape);
            temp.AddRange(shapes);
            this.shapes = shapes.ToArray();
        }
    }
}

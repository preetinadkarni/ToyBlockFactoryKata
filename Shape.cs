public class Shape {
    public ShapeType ShapeType { get; set; }
    public Color Color { get; set; }
    public int Quantity { get; set; }
    public Cost Cost { get; set; }


    public Shape(ShapeType st, Color c, int q, Cost cost)
    {
        Color = c;
        Quantity = q;
        Cost = cost;
        ShapeType = st;
    }
}
public enum Color { Red, Blue, Yellow}

public enum Cost { Square = 1, Triangle = 2, Circle = 3, Red = 1 }

public enum ShapeType { Circle, Square, Triangle}

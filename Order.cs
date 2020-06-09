using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class Order
{
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string DueDate { get; set; }
    public string OrderNo { get; set; }

    public List<Shape> blocks;

    public Order() {
        blocks = new List<Shape>();
    }
    

    public void GenerateCuttingListReport()
    {
        Console.WriteLine("~~~");
        Console.WriteLine("Your cutting list has been generated:");
        Console.WriteLine($"Name: {CustomerName} Address: {CustomerAddress} Due Date: {DueDate} Order #: 0001");
        Console.WriteLine("|          | Qty |");
        Console.WriteLine("!----------|-----|");
        int totalCircles = GetShapeCount(blocks, ShapeType.Circle);
        Console.WriteLine($"|Circle    | {totalCircles}  |");
        int totalSquares = GetShapeCount(blocks, ShapeType.Square);
        Console.WriteLine($"|Squares   | {totalSquares}  |");
        int totalTriangles = GetShapeCount(blocks, ShapeType.Triangle);
        Console.WriteLine($"|Triangles | {totalTriangles}  |");
    }

    public static int GetShapeCount(List<Shape> blocks, ShapeType shapeType) 
    {
        List<Shape> s = blocks.FindAll(s => s.ShapeType == shapeType && s.Quantity > 0);
        int total = 0;
        foreach (Shape item in s)
            total = total + item.Quantity;
        return total;    
    }

}
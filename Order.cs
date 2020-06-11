using System;
using System.Collections.Generic;
using System.Linq;
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

    public void GenerateInvoiceReport()
    {
        Console.WriteLine("\n~~~");
        Console.WriteLine("Your invoice report has been generated:");
        Console.WriteLine($"Name: {CustomerName} Address: {CustomerAddress} Due Date: {DueDate} Order #: 0001");
        Console.WriteLine("|          | Red | Blue | Yellow |");
        Console.WriteLine("|----------|-----|------|--------|");
        var redSquare = GetShapeCountByColour(blocks, ShapeType.Square, Color.Red);
        var blueSquare = GetShapeCountByColour(blocks, ShapeType.Square, Color.Blue);
        var yellowSquare = GetShapeCountByColour(blocks, ShapeType.Square, Color.Yellow);
        Console.WriteLine($"|Squares   | {redSquare}   | {blueSquare}    | {yellowSquare}      |");
        var redTriangle = GetShapeCountByColour(blocks, ShapeType.Triangle, Color.Red);
        var blueTriangle = GetShapeCountByColour(blocks, ShapeType.Triangle, Color.Blue);
        var yellowTriangle = GetShapeCountByColour(blocks, ShapeType.Triangle, Color.Yellow);
        Console.WriteLine($"|Triangles | {redTriangle}   | {blueTriangle}    | {yellowTriangle}      |");
        var redCircle = GetShapeCountByColour(blocks, ShapeType.Circle, Color.Red);
        var blueCircle = GetShapeCountByColour(blocks, ShapeType.Circle, Color.Blue);
        var yellowCircle = GetShapeCountByColour(blocks, ShapeType.Circle, Color.Yellow);
        Console.WriteLine($"|Circles   | {redCircle}   | {blueCircle}    | {yellowCircle}      |");
        Console.WriteLine("\n~~~");
    }

    public static string GetShapeCountByColour(List<Shape> blocks, ShapeType shapeType, Color color)
    {
        var result = blocks.FirstOrDefault(r => r.ShapeType == shapeType && r.Color == color);
        var qty = result.Quantity;
        return qty == 0 ? "-" : qty.ToString() ;
    }

    public void GenerateCuttingListReport()
    {
        Console.WriteLine("\n~~~");
        Console.WriteLine("Your cutting list has been generated:");
        Console.WriteLine($"Name: {CustomerName} Address: {CustomerAddress} Due Date: {DueDate} Order #: 0001");
        Console.WriteLine("|          | Qty |");
        Console.WriteLine("!----------|-----|");
        int totalCircles = GetShapeCount(blocks, ShapeType.Circle);
        Console.WriteLine($"|Circle    | {totalCircles}   |");
        int totalSquares = GetShapeCount(blocks, ShapeType.Square);
        Console.WriteLine($"|Squares   | {totalSquares}   |");
        int totalTriangles = GetShapeCount(blocks, ShapeType.Triangle);
        Console.WriteLine($"|Triangles | {totalTriangles}   |");
        Console.WriteLine("\n~~~");
    }

    public static int GetShapeCount(List<Shape> blocks, ShapeType shapeType) 
    {
        var s = blocks.FindAll(s => s.ShapeType == shapeType);
        int total = 0;
        foreach (var item in s)
            total = total + item.Quantity;
        return total;    
    }

}
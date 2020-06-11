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
        PrintReportHeaderFooter();
        Console.WriteLine("Your invoice report has been generated:\n");
        PrintCustomerInformation();
        PrintOrderSummary();
        
        int totalSquares = GetShapeCount(blocks, ShapeType.Square);
        Console.WriteLine($"Squares         {totalSquares} @ ${(int)Cost.Square} ppi = ${GetPrice(totalSquares, Cost.Square)}");
        int totalTriangles = GetShapeCount(blocks, ShapeType.Triangle);
        Console.WriteLine($"Triangles       {totalTriangles} @ ${(int)Cost.Triangle} ppi = ${GetPrice(totalTriangles, Cost.Triangle)}");
        int totalCircles = GetShapeCount(blocks, ShapeType.Circle);
        Console.WriteLine($"Circles         {totalCircles} @ ${(int)Cost.Circle} ppi = ${GetPrice(totalCircles, Cost.Circle)}");
        int totalRedBlocks = GetBlocksCountForSpecificColor(blocks,Color.Red);
        Console.WriteLine($"Red color surcharge {totalRedBlocks} @ ${(int)Cost.Red} ppi = ${GetPrice(totalRedBlocks, Cost.Red)}");
        PrintReportHeaderFooter();
    }
    public void GenerateCuttingListReport()
    {
        PrintReportHeaderFooter();
        Console.WriteLine("Your cutting list has been generated:\n");
        PrintCustomerInformation();
        Console.WriteLine("|          | Qty |");
        Console.WriteLine("!----------|-----|");
        int totalSquares = GetShapeCount(blocks, ShapeType.Square);
        int totalTriangles = GetShapeCount(blocks, ShapeType.Triangle);
        int totalCircles = GetShapeCount(blocks, ShapeType.Circle);
        Console.WriteLine($"|Squares   | {totalSquares}   |");
        Console.WriteLine($"|Triangle  | {totalTriangles}   |");
        Console.WriteLine($"|Circle    | {totalCircles}   |");
        PrintReportHeaderFooter();
    }
    public void GeneratePaintingReport()
    {
        PrintReportHeaderFooter();
        Console.WriteLine("Your painting report has been generated:\n");
        PrintCustomerInformation();
        PrintOrderSummary();
        PrintReportHeaderFooter();

    }
    public void PrintOrderSummary()
    {
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
        Console.WriteLine("");
    }

    public void PrintReportHeaderFooter()
    {
        Console.WriteLine("\n~~~");
    }
    public static string GetShapeCountByColour(List<Shape> blocks, ShapeType shapeType, Color color)
    {
        var result = blocks.FirstOrDefault(r => r.ShapeType == shapeType && r.Color == color);
        var qty = result.Quantity;
        return qty == 0 ? "-" : qty.ToString() ;
    }

    public static int GetPrice(int quantity, Cost cost)
    {
        return quantity * (int)cost;
    }

    public static int GetBlocksCountForSpecificColor(List<Shape> blocks, Color color)
    {
        var result = blocks.FindAll(b => b.Color == color);
        int total = 0;
        foreach (var item in result)
            total = total + item.Quantity;
        return total;
    }

    public static int GetShapeCount(List<Shape> blocks, ShapeType shapeType) 
    {
        var s = blocks.FindAll(s => s.ShapeType == shapeType);
        int total = 0;
        foreach (var item in s)
            total = total + item.Quantity;
        return total;    
    }

    public void PrintCustomerInformation()
    {
        Console.WriteLine($"Name: {CustomerName} Address: {CustomerAddress} Due Date: {DueDate} Order #: 0001\n");
    }
}
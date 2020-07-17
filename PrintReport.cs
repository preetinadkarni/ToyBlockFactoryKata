using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class PrintReport
{
    public static void GenerateInvoiceReport(Order order)
    {
        PrintReportHeaderFooter();
        Console.WriteLine("Your invoice report has been generated:\n");
        PrintCustomerInformation(order);
        PrintOrderSummary(order);
        
        int totalSquares = Order.GetShapeCount(order.blocks, ShapeType.Square);
        Console.WriteLine($"Squares         {totalSquares} @ ${(int)Cost.Square} ppi = ${Order.GetPrice(totalSquares, Cost.Square)}");
        int totalTriangles = Order.GetShapeCount(order.blocks, ShapeType.Triangle);
        Console.WriteLine($"Triangles       {totalTriangles} @ ${(int)Cost.Triangle} ppi = ${Order.GetPrice(totalTriangles, Cost.Triangle)}");
        int totalCircles = Order.GetShapeCount(order.blocks, ShapeType.Circle);
        Console.WriteLine($"Circles         {totalCircles} @ ${(int)Cost.Circle} ppi = ${Order.GetPrice(totalCircles, Cost.Circle)}");
        int totalRedBlocks = Order.GetBlocksCountForSpecificColor(order.blocks,Color.Red);
        Console.WriteLine($"Red color surcharge {totalRedBlocks} @ ${(int)Cost.Red} ppi = ${Order.GetPrice(totalRedBlocks, Cost.Red)}");
        PrintReportHeaderFooter();
    }
    public static void GenerateCuttingListReport(Order order)
    {
        PrintReportHeaderFooter();
        Console.WriteLine("Your cutting list has been generated:\n");
        PrintCustomerInformation(order);
        Console.WriteLine("|          | Qty |");
        Console.WriteLine("!----------|-----|");
        int totalSquares = Order.GetShapeCount(order.blocks, ShapeType.Square);
        int totalTriangles = Order.GetShapeCount(order.blocks, ShapeType.Triangle);
        int totalCircles = Order.GetShapeCount(order.blocks, ShapeType.Circle);
        Console.WriteLine($"|Squares   | {totalSquares}   |");
        Console.WriteLine($"|Triangle  | {totalTriangles}   |");
        Console.WriteLine($"|Circle    | {totalCircles}   |");
        PrintReportHeaderFooter();
    }
    public static void GeneratePaintingReport(Order order)
    {
        PrintReportHeaderFooter();
        Console.WriteLine("Your painting report has been generated:\n");
        PrintCustomerInformation(order);
        PrintOrderSummary(order);
        PrintReportHeaderFooter();

    }
    private static void PrintOrderSummary(Order order)
    {
        Console.WriteLine("|          | Red | Blue | Yellow |");
        Console.WriteLine("|----------|-----|------|--------|");
        var redSquare = Order.GetShapeCountByColour(order.blocks, ShapeType.Square, Color.Red);
        var blueSquare = Order.GetShapeCountByColour(order.blocks, ShapeType.Square, Color.Blue);
        var yellowSquare = Order.GetShapeCountByColour(order.blocks, ShapeType.Square, Color.Yellow);
        Console.WriteLine($"|Squares   | {redSquare}   | {blueSquare}    | {yellowSquare}      |");
        var redTriangle = Order.GetShapeCountByColour(order.blocks, ShapeType.Triangle, Color.Red);
        var blueTriangle = Order.GetShapeCountByColour(order.blocks, ShapeType.Triangle, Color.Blue);
        var yellowTriangle = Order.GetShapeCountByColour(order.blocks, ShapeType.Triangle, Color.Yellow);
        Console.WriteLine($"|Triangles | {redTriangle}   | {blueTriangle}    | {yellowTriangle}      |");
        var redCircle = Order.GetShapeCountByColour(order.blocks, ShapeType.Circle, Color.Red);
        var blueCircle = Order.GetShapeCountByColour(order.blocks, ShapeType.Circle, Color.Blue);
        var yellowCircle = Order.GetShapeCountByColour(order.blocks, ShapeType.Circle, Color.Yellow);
        Console.WriteLine($"|Circles   | {redCircle}   | {blueCircle}    | {yellowCircle}      |");
        Console.WriteLine("");
    }

    private static void PrintReportHeaderFooter()
    {
        Console.WriteLine("\n~~~");
    }
    public static void PrintCustomerInformation(Order order)
    {
        Console.WriteLine($"Name: {order.customer.CustomerName} Address: {order.customer.CustomerAddress} Due Date: {order.DueDate} Order #: 0001\n");
    }
}
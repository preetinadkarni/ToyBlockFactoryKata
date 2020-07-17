using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Order
{
    public Customer customer;
    public string DueDate { get; set; }
    public string OrderNo { get; set; }

    public List<Shape> blocks;
    public Order(Customer c)
    {
        customer = c;
        blocks = new List<Shape>();
    }

    public static string GetShapeCountByColour(List<Shape> blocks, ShapeType shapeType, Color color)
    {
        var result = blocks.FirstOrDefault(r => r.ShapeType == shapeType && r.Color == color);
        var qty = result.Quantity;
        return qty == 0 ? "-" : qty.ToString();
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
}
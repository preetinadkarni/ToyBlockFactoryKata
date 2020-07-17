using System;

namespace ToyBlockFactory
{
    class Program
    {
        public static void Main()
        {
  
           
            ShowWelcome();

            string customerName = GetCustomerName();
            string customerAddress = GetCustomerAddress();
            Customer customer = new Customer(customerName, customerAddress);

            Order order = new Order(customer);
            order.DueDate = GetDueDate();
            ShowBlankLine();

            int redSquareQty = GetOrder("Red Square");
            Shape redSquare = new Shape(ShapeType.Square, Color.Red, redSquareQty, Cost.Square);
            order.blocks.Add(redSquare);

            int blueSquareQty = GetOrder("Blue Square");
            Shape blueSquare = new Shape(ShapeType.Square, Color.Blue, blueSquareQty, Cost.Square);
            order.blocks.Add(blueSquare);

            int yellowSquareQty = GetOrder("Yellow Square");
            Shape yellowSquare = new Shape(ShapeType.Square, Color.Yellow, yellowSquareQty, Cost.Square);
            order.blocks.Add(yellowSquare);

            ShowBlankLine();

            int redTriangleQty = GetOrder("Red Triangle");
            Shape redTriangle = new Shape(ShapeType.Triangle, Color.Red, redTriangleQty, Cost.Triangle);
            order.blocks.Add(redTriangle);

            int blueTriangleQty = GetOrder("Blue Triangle");
            Shape blueTriangle = new Shape(ShapeType.Triangle, Color.Blue, blueTriangleQty, Cost.Triangle);
            order.blocks.Add(blueTriangle);

            int yellowTriangleQty = GetOrder("Yellow Triangle");
            Shape yellowTriangle = new Shape(ShapeType.Triangle, Color.Yellow, yellowTriangleQty, Cost.Triangle);
            order.blocks.Add(yellowTriangle);

            ShowBlankLine();

            int redCircleQty = GetOrder("Red Circle");
            Shape redCircle = new Shape(ShapeType.Circle, Color.Red, redCircleQty, Cost.Circle);
            order.blocks.Add(redCircle);

            int blueCircleQty = GetOrder("Blue Circle");
            Shape blueCircle = new Shape(ShapeType.Circle, Color.Blue, blueCircleQty, Cost.Circle);
            order.blocks.Add(blueCircle);

            int yellowCircleQty = GetOrder("Yellow Circle");
            Shape yellowCircle = new Shape(ShapeType.Circle, Color.Yellow, yellowCircleQty, Cost.Circle);
            order.blocks.Add(yellowCircle);

            ShowBlankLine();
            ShowEndMessage();

            PrintReport.GenerateInvoiceReport(order);
            PrintReport.GenerateCuttingListReport(order);
            PrintReport.GeneratePaintingReport(order);

        }

        private static void ShowWelcome()
        {
            Console.WriteLine("~~~");
            Console.WriteLine("Welcome to the Toy Block Factory!\n");
        }

        private static string GetCustomerName()
        {
            Console.Write("Please input your Name: ");
            string name = Console.ReadLine();
            return name;
        }
        private static string GetCustomerAddress()
        {
            Console.Write("Please input your Address: ");
            string address = Console.ReadLine();
            return address;
        }

        private static string GetDueDate()
        {
            Console.Write("Please input your Due Date: ");
            string dueDate = Console.ReadLine();
            return dueDate;
        }

        private static int GetOrder(string shape)
        {
            int qty = 0,q;
            Console.Write($"Please input the number of {shape}: ");
            string quantity = Console.ReadLine();
            bool success = Int32.TryParse(quantity, out q);
            if (success) 
                qty = q;
            return qty;
        }

        private static void ShowBlankLine()
        {
            Console.WriteLine("");
        }

        private static void ShowEndMessage()
        {
            Console.WriteLine("~~~");
        }
    }
}

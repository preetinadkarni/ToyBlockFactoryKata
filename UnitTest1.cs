using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestProject
{
    [TestFixture]
    public class Tests
    {
        List<Shape> blocks;

        [SetUp]
        public void Setup()
        {
            blocks = new List<Shape>();
            Shape redSquare = new Shape(ShapeType.Square, Color.Red, 1, Cost.Square);
            blocks.Add(redSquare);
            Shape blueSquare = new Shape(ShapeType.Square, Color.Blue, 0, Cost.Square);
            blocks.Add(blueSquare);
            Shape yellowSquare = new Shape(ShapeType.Square, Color.Yellow, 1, Cost.Square);
            blocks.Add(yellowSquare);
            Shape redTriangle = new Shape(ShapeType.Triangle, Color.Red, 0, Cost.Triangle);
            blocks.Add(redTriangle);
            Shape blueTriangle = new Shape(ShapeType.Triangle, Color.Blue, 1, Cost.Triangle);
            blocks.Add(blueTriangle);
            Shape yellowTriangle = new Shape(ShapeType.Triangle, Color.Yellow, 2, Cost.Triangle);
            blocks.Add(yellowTriangle);
            Shape redCircle = new Shape(ShapeType.Circle, Color.Red, 2, Cost.Circle);    
            blocks.Add(redCircle);
            Shape blueCircle = new Shape(ShapeType.Circle, Color.Blue, 1, Cost.Circle);
            blocks.Add(blueCircle);
            Shape yellowCircle = new Shape(ShapeType.Circle, Color.Yellow, 0, Cost.Circle);
            blocks.Add(yellowCircle);
        }


        [TestCase(ShapeType.Triangle, Color.Yellow, ExpectedResult = "2")]
        [TestCase(ShapeType.Square, Color.Blue, ExpectedResult = "-")]
        [TestCase(ShapeType.Circle, Color.Red, ExpectedResult = "2")]
        public string GivenBlocks_GetShapeCountByColor_CalculatesCorrectCountForEachShapeTypeByColor(ShapeType shapeType, Color color)
        {
            return Order.GetShapeCountByColour(blocks, shapeType, color);
        }

        [TestCase(ShapeType.Circle,ExpectedResult = 3)]
        [TestCase(ShapeType.Square, ExpectedResult = 2)]
        [TestCase(ShapeType.Triangle, ExpectedResult = 3)]
        public int GivenBlocks_GetShapeCount_CalculatesCorrectCountForEachShapeType(ShapeType shapeType)
        {
            return Order.GetShapeCount(blocks, shapeType);
        }

        [TestCase(2,Cost.Red, ExpectedResult = 2)]
        [TestCase(2, Cost.Square, ExpectedResult = 2)]
        [TestCase(2, Cost.Triangle, ExpectedResult = 4)]
        [TestCase(3, Cost.Circle, ExpectedResult = 9)]
        public int GivenBlocks_GetPrice_CalculatesCorrectPrice(int quantity, Cost cost)
        {
            return Order.GetPrice(quantity, cost);
        }

        [TestCase(Color.Red, ExpectedResult = 3)]
        public int GivenBlocks_GetBlocksCountForSpecificColor_ReturnsCorrectCount(Color color)
        {
            return Order.GetBlocksCountForSpecificColor(blocks, color);
        }
    }
}
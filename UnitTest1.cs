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
            Shape redSquare = new Shape(ShapeType.Square, Color.Red, 1, ShapeCost.Square);
            blocks.Add(redSquare);
            Shape blueSquare = new Shape(ShapeType.Square, Color.Blue, 0, ShapeCost.Square);
            blocks.Add(blueSquare);
            Shape yellowSquare = new Shape(ShapeType.Square, Color.Yellow, 1, ShapeCost.Square);
            blocks.Add(yellowSquare);
            Shape redTriangle = new Shape(ShapeType.Triangle, Color.Red, 0, ShapeCost.Triangle);
            blocks.Add(redTriangle);
            Shape blueTriangle = new Shape(ShapeType.Triangle, Color.Blue, 1, ShapeCost.Triangle);
            blocks.Add(blueTriangle);
            Shape yellowTriangle = new Shape(ShapeType.Triangle, Color.Yellow, 2, ShapeCost.Triangle);
            blocks.Add(yellowTriangle);
            Shape redCircle = new Shape(ShapeType.Circle, Color.Red, 1, ShapeCost.Circle);    
            blocks.Add(redCircle);
            Shape blueCircle = new Shape(ShapeType.Circle, Color.Blue, 1, ShapeCost.Circle);
            blocks.Add(blueCircle);
            Shape yellowCircle = new Shape(ShapeType.Circle, Color.Yellow, 0, ShapeCost.Circle);
            blocks.Add(yellowCircle);
        }


        [TestCase(ShapeType.Triangle, Color.Yellow, ExpectedResult = "2")]
        [TestCase(ShapeType.Square, Color.Blue, ExpectedResult = "-")]
        [TestCase(ShapeType.Circle, Color.Red, ExpectedResult = "1")]
        public string GivenBlocks_GetShapeCountByColor_CalculatesCorrectCountForEachShapeTypeByColor(ShapeType shapeType, Color color)
        {
            return Order.GetShapeCountByColour(blocks, shapeType, color);
        }

        [TestCase(ShapeType.Circle,ExpectedResult = 2)]
        [TestCase(ShapeType.Square, ExpectedResult = 2)]
        [TestCase(ShapeType.Triangle, ExpectedResult = 3)]
        public int GivenBlocks_GetShapeCount_CalculatesCorrectCountForEachShapeType(ShapeType shapeType)
        {
            return Order.GetShapeCount(blocks, shapeType);
        }
    }
}
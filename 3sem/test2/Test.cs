using NUnit.Framework;

namespace test2
{
    [TestFixture]
    public class Test
    {
        Rectangle rect = new Rectangle(new Vector2D(0,0),new Vector2D(10,0),new Vector2D(10,-10),new Vector2D(0,-10));
        
        [Test]
        public void PerimeterTest(){
            var result = rect.GetPerimeter();
            var t = 40;
            Assert.AreEqual(t,result);
        }

        [Test]
        public void SquareTest()
        {
            var result = rect.GetSquare();
            var t = 100;
            Assert.AreEqual(t,result);
        }

        [Test]
        public void OutputTest()
        {
            var result = rect.ToString();
            var t =
                $"A:(0,0) B:(10,0) C:(0,-10) D:(10,-10) "
                + $"Perimeter:(40) Square:(100)";
            Assert.AreEqual(t,result);
        }

        [Test]
        public void MoveTest()
        {
            Vector2D moveVector = new Vector2D(-12, 4);
            var result = rect.MoveFigure(moveVector).ToString();
            var t = $"A:(-12,4) B:(-2,4) C:(-12,-6) D:(-2,-6) "
                    + $"Perimeter:(40) Square:(100)";
            Assert.AreEqual(result,t);
            
        }
    }
}
using NUnit.Framework;
using RobotSimulation;
using RobotSimulation.Enums;
using RobotSimulation.RoboDataCache;

namespace RobotSimulationTestProject
{
    [TestFixture]
    public class Tests
    {
        RoboDataCache roboDataCache = RoboDataCache.GetRoboCache;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(0,0,Facing.NORTH,"a",true)]
        [TestCase(-1, 0, Facing.WEST, "a", false)]
        [TestCase(0, -2, Facing.WEST,"b",false)]
        [TestCase(5, 5, Facing.WEST, "a", true)]
        [TestCase(5, 7, Facing.WEST,"b",false)]
        [TestCase(10, 5, Facing.EAST, "a", false)]
        public void Place(int X,int Y, Facing facing,string name,bool expected)
        {
            RobotCommands robotMovements = new RobotCommands();
            int ID = roboDataCache.GenerateRobot(name);

            bool result = robotMovements.Place(X, Y, facing, ID);
            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase(0, 0, Facing.NORTH, "a", true)]
        [TestCase(-1, 0, Facing.WEST, "a", false)]
        [TestCase(0, -2, Facing.WEST, "b", false)]
        [TestCase(5, 5, Facing.WEST, "a", true)]
        [TestCase(5, 7, Facing.WEST, "b", false)]
        [TestCase(10, 5, Facing.EAST, "a", false)]
        public void Move(int X, int Y, Facing facing, string name, bool expected)
        {
            RobotCommands robotMovements = new RobotCommands();
            int ID = roboDataCache.GenerateRobot(name);
            robotMovements.Place(X, Y, facing, ID);

            bool result = robotMovements.Move(ID);
            Assert.AreEqual(result, expected);
        }


        [Test]
        [TestCase(0, 0, Facing.NORTH, "a", true)]
        [TestCase(-1, 0, Facing.WEST, "a", false)]
        [TestCase(0, -2, Facing.WEST, "b", false)]
        [TestCase(5, 5, Facing.WEST, "a", true)]
        [TestCase(5, 7, Facing.WEST, "b", false)]
        [TestCase(10, 5, Facing.EAST, "a", false)]
        public void Left(int X, int Y, Facing facing, string name, bool expected)
        {
            RobotCommands robotMovements = new RobotCommands();
            int ID = roboDataCache.GenerateRobot(name);

            robotMovements.Place(X, Y, facing, ID);

            bool result = robotMovements.Left(ID);
            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase(0, 0, Facing.NORTH, "a", true)]
        [TestCase(-1, 0, Facing.WEST, "a", false)]
        [TestCase(0, -2, Facing.WEST, "b", false)]
        [TestCase(5, 5, Facing.WEST, "a", true)]
        [TestCase(5, 7, Facing.WEST, "b", false)]
        [TestCase(10, 5, Facing.EAST, "a", false)]
        public void Right(int X, int Y, Facing facing, string name, bool expected)
        {
            RobotCommands robotMovements = new RobotCommands();
            int ID = roboDataCache.GenerateRobot(name);

            robotMovements.Place(X, Y, facing, ID);

            bool result = robotMovements.Right(ID);
            Assert.AreEqual(result, expected);
        }
    }
}
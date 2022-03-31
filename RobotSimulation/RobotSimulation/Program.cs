using System;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using RobotSimulation.Enums;

namespace RobotSimulation
{
    class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));
        private static RobotCommands rbm = new RobotCommands();
        private static RoboDataCache.RoboDataCache roboDataCache = RoboDataCache.RoboDataCache.GetRoboCache;

       
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            Console.WriteLine("Welcome to Robot Simulation!");
            Console.WriteLine("Press enter to continue");

            // Console.ReadLine();
            while (Console.ReadKey().Key == ConsoleKey.Enter || Console.ReadKey().Key == ConsoleKey.B)
            {

                Console.WriteLine("Enter the name of the Robot that you would like to simulate");
                string robotName = Console.ReadLine();
                int RobotID = roboDataCache.GenerateRobot(robotName);
                if (RobotID != 0)
                
                {
                    Console.WriteLine("Please place the robot using below command to get started");
                    Console.WriteLine("1.PLACE X,Y,F (X coordinate, Y coordinate, F is direction:NORTH, SOUTH, EAST, WEST)\n2.MOVE\n3.LEFT\n4.RIGHT\n5.REPORT\n");
                    string command = Console.ReadLine();

                    switch (command.ToLower())
                    {
                        case var _ when command.ToLower().Contains("place"):
                            Regex rg = new Regex(@"^[P][L][A][C][E] -?\d+,-?\d+,[a-zA-Z]*$", RegexOptions.IgnoreCase);
                            if (!rg.IsMatch(command))
                            {
                                Console.WriteLine("PLACE command is not in the correct format, use PLACE X,Y,F (where X coordinate, Y coordinate, F is direction:NORTH, SOUTH, EAST, WEST)");
                            }
                            else
                            {
                                String[] vs = command.Substring(command.IndexOf(' ')).Split(',');
                               
                                if (rbm.Place(Convert.ToInt32(vs[0]), Convert.ToInt32(vs[1]), (Facing)Enum.Parse(typeof(Facing), vs[2].ToUpper()), RobotID))
                                    Console.WriteLine("Robot has been placed successfully");
                                    logger.Info("Robot has been placed successfully");
                            }
                            break;
                        case var _ when command.ToLower().Contains("move"):
                            if (rbm.Move(RobotID))
                            {
                                Console.WriteLine("Robot has been moved successfully");
                                logger.Info("Robot has been moved successfully");
                            }
                            else
                                Console.WriteLine("First place the robot and then move");

                            break;
                        case var _ when command.ToLower().Contains("left"):
                            if (rbm.Left(RobotID))
                            {
                                Console.WriteLine("Robot has been turned left successfully");
                                logger.Info("Robot has been turned left successfully");

                            }
                            else
                                Console.WriteLine("First place the robot and then turn left");
                            break;
                        case var _ when command.ToLower().Contains("right"):
                            if (rbm.Right(RobotID))
                            {
                                Console.WriteLine("Robot has been turned right successfully");
                                logger.Info("Robot has been turned right successfully");

                            }
                            else
                                Console.WriteLine("First place the robot and then turn right");
                            break;
                        case var _ when command.ToLower().Contains("report"):
                            if (!rbm.Report())
                                Console.WriteLine("No Robots to Report");

                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
            Console.ReadLine();
        }
    }
}
   

using RobotSimulation.Enums;
using RobotSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotSimulation.Common;
using log4net;

namespace RobotSimulation
{
   public class RobotCommands:IRobotCommands
    {

        RoboDataCache.RoboDataCache roboDataCache = RoboDataCache.RoboDataCache.GetRoboCache;
        private static ILog logger = LogManager.GetLogger(typeof(RobotCommands));

        
        /// <summary>
        /// Places the robot at X & Y coordinates and robot facing direction
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="direction"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Place(int? X, int? Y, Facing direction,int ID)
        {
            try
            {
                bool validate = false;
                if (X.HasValue && Y.HasValue)
                {
                    validate = Validation.ValidateRobotPosition(X.Value, Y.Value) && roboDataCache.CheckIfRobotAlreadyPlaced(X.Value, Y.Value, ID);
                    if (validate)
                    {
                        return roboDataCache.UpdateRoboStatus(X.Value, Y.Value, direction, ID);

                    }
                }
                else
                {
                    return roboDataCache.UpdateRoboStatus(null, null, direction, ID);
                }

            }
            catch(Exception ex)
            {
                logger.Error("Place " + ex.InnerException);
            }
            return false;

        }
        /// <summary>
        /// - MOVE will move the toy robot one unit forward in the direction it is currently facing.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Move( int ID)
        {
            try
            {
                if (roboDataCache.CheckIfRobotIsPlaced(ID))
                {
                    Model.Robot rb = roboDataCache.GetRoboById(ID);
                    Facing? direction = rb.Facing;

                   
                        switch (direction)
                        {
                            case (Facing.EAST):
                                rb.X = rb.X + 1;
                                break;
                                ;
                            case (Facing.NORTH):
                                rb.Y = rb.Y + 1;
                                break;
                                ;
                            case (Facing.WEST):
                                rb.X = rb.X - 1;
                                break;
                                ;
                            case (Facing.SOUTH):
                                rb.Y = rb.Y - 1;
                                break;
                                ;
                            default:
                                break;
                        }
                        return Place(rb.X, rb.Y, direction.Value, ID);
                    
                }
               
            }
            catch (Exception e)
            {
                logger.Error("Move " + e.InnerException);
            }
            return false;
        }
        /// <summary>
        /// LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without
        ///changing the position of the robot
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Left(int ID)
        {
            try
            {
                if (roboDataCache.CheckIfRobotIsPlaced(ID))
                {
                    Facing? direction = roboDataCache.GetRoboById(ID).Facing;

                    switch (direction)
                    {
                        case (Facing.EAST):
                            direction = Facing.NORTH;
                            break;
                            ;
                        case (Facing.NORTH):
                            direction = Facing.WEST;
                            break;
                            ;
                        case (Facing.WEST):
                            direction = Facing.SOUTH;
                            break;
                            ;
                        case (Facing.SOUTH):
                            direction = Facing.EAST;
                            break;
                            ;
                        default:
                            break;
                    }
                    return Place(null, null, direction.Value, ID);


                }
            }
            catch (Exception e)
            {
                logger.Error("Left " + e.InnerException);
            }
            
                return false;
            
        }
        /// <summary>
        /// LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without
        ///changing the position of the robot
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Right(int ID)
        {
            try
            {
                if (roboDataCache.CheckIfRobotIsPlaced(ID))
                {
                    Facing? direction = roboDataCache.GetRoboById(ID).Facing;


                    switch (direction)
                    {
                        case (Facing.EAST):
                            direction = Facing.SOUTH;
                            break;
                            ;
                        case (Facing.NORTH):
                            direction = Facing.EAST;
                            break;
                            ;
                        case (Facing.WEST):
                            direction = Facing.NORTH;
                            break;
                            ;
                        case (Facing.SOUTH):
                            direction = Facing.WEST;
                            break;
                            ;
                        default:
                            break;
                    }
                    return Place(null, null, direction.Value, ID);


                }
            }
            catch (Exception e)
            {
                logger.Error("Right " + e.InnerException);
            }

            return false;
            
        }
        /// <summary>
        /// REPORT will announce the X,Y and F of the robot. This can be in any form, but
        /// standard output is sufficient.
        /// </summary>
        /// <returns></returns>
        public bool Report()
        {
            try
            {
                if (roboDataCache.GetRobots.Count() > 0)
                {
                    foreach (Model.Robot robots in roboDataCache.GetRobots)
                    {
                        Console.WriteLine(robots.Name + ':' + robots.X + " , " + robots.Y + " , " + robots.Facing);
                    }
                    return true;
                }
            }
            catch(Exception e)
            {
                logger.Error("Report " + e.InnerException);

            }
            return false;
            
        }
    }
}

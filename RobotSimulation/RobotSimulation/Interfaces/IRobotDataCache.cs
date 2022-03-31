using RobotSimulation.Enums;
using RobotSimulation.Interfaces;
using RobotSimulation.Model;
using System.Collections.Generic;

namespace RobotSimulation.RoboDataCache
{
    public interface IRobotDataCache
    {
        bool UpdateRoboStatus(int? X, int? Y, Facing facing, int ID);
        Robot GetRoboById(int ID);       
        bool CheckIfRobotIsPlaced(int ID);
        int GenerateRobot(string name);
        bool CheckIfRobotAlreadyPlaced(int X, int Y, int ID);
    }
}
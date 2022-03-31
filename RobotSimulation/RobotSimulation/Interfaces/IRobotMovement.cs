using RobotSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulation.Interfaces
{
    interface IRobotCommands
    {
        bool Place(int? X, int? Y, Facing direction,int ID);
        bool Move(int ID);
        bool Left(int ID);
        bool Right( int ID);
        bool Report();
    }
}

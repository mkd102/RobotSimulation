using RobotSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulation.Interfaces
{
    interface IRobot
    {
       
         int ID
        {
            get;
            set;
        }

         string Name
        {
            get;
            set;
        }
         Facing? Facing
        {
            get;
            set;
        }
        int? X
        {
            get;
            set;
        }
        int? Y
        {
            get;
            set;
        }

    }
}

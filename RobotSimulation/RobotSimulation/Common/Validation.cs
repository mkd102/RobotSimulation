using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulation.Common
{
    public static class Validation
    {
        public static bool ValidateRobotPosition(int x, int y)
        {
            if(x<0 || y<0 || x>5 ||y >5)
            {
                return false;
            }
            return true;
        }

      
    }
}

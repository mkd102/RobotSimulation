using RobotSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulation.Model
{
   public class Robot: Interfaces.IRobot
    {
        private int _ID;
        private int? _X;
        private int? _Y;

        private string _Name;
        private Facing? _Facing;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public Facing? Facing
        {
            get { return _Facing; }
            set { _Facing = value; }
        }
        public int? X
        {
            get { return _X; }
            set { _X = value; }
        }
        public int? Y
        {
            get { return _Y; }
            set { _Y = value; }
        }



    }
}

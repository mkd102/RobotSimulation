using log4net;
using RobotSimulation.Enums;
using RobotSimulation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotSimulation.RoboDataCache
{
    public sealed class RoboDataCache: IRobotDataCache
    {
        private static RoboDataCache roboDataCache = null;
        private static object _lock = new object();
        private static List<Robot> RobotStatus = new List<Robot>();
        private static ILog logger = LogManager.GetLogger(typeof(RoboDataCache));

        private RoboDataCache()
        {

        }
        public static RoboDataCache GetRoboCache
        {
            get
            {
                Monitor.Enter(_lock);
                {
                    if (roboDataCache == null)
                    {
                        roboDataCache = new RoboDataCache();

                    }
                }
                Monitor.Exit(_lock);

                return roboDataCache;
            }
            
        }
        public  IEnumerable<Robot> GetRobots
        {
            get
            {
             
                return RobotStatus.Where(r=>r.X!=null && r.Y!=null && r.Facing!=null);
            }
        }
        public  bool UpdateRoboStatus(int? X, int? Y, Facing facing, int ID)
        {
            try
            {
                foreach (Robot r in RobotStatus.Where(r => r.ID == ID))
                {
                    if(X.HasValue)
                    r.X = X;

                    if (Y.HasValue)
                       r.Y = Y;

                    
                        r.Facing = facing;
                }
                return true;
            }
            catch(Exception e)
            {
                logger.Error("UpdateRobotStatus " + e.InnerException);

            }
            return false;

        }
        public  Robot GetRoboById(int ID)
        {
            return RobotStatus.Where(r => r.ID == ID).FirstOrDefault(); 
        }
        private static int GenerateID()
        {
            return RobotStatus.Count +1; ;
        }
        private  void ResetList()
        {
            RobotStatus.Clear();
            RobotStatus = new List<Robot>();
        }
        public  bool CheckIfRobotIsPlaced(int ID)
        {
            Robot rb = GetRoboById(ID);
            if(rb.Facing==null && rb.Y==null && rb.X==null)
            {
                return false;
            }
            return true;
        }

        private  bool UniqueRobotName(string Name)
        {
            if (RobotStatus.Where(n=> n.Name.Equals(Name,StringComparison.OrdinalIgnoreCase)).Count()>0)
            {
                return false;
            }
            return true;
        }
        public  int GenerateRobot(string name)
        {
            try
            {
                if (UniqueRobotName(name))
                {
                    RobotStatus.Add(new Robot { ID = GenerateID(), Name = name.ToLower(), X = null, Y = null, Facing = null });

                }
                return RobotStatus.Where(r => r.Name == name.ToLower()).FirstOrDefault().ID;
            }
            catch(Exception e)
            {
                logger.Error("GenerateRobot " + e.InnerException);

            }
            return 0;
        }

        public  bool CheckIfRobotAlreadyPlaced(int X, int Y,int ID)
        {
            try
            {
                if (RobotStatus.Where(r => r.X == X && r.Y == Y && r.ID != ID).Count() > 0)
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                logger.Error("CheckIfRobotAlreadyPlaced " + ex.InnerException);

            }
            return true;
        }
    }
}

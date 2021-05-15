using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model
{
    public class TodayRunModel
    {
        /// <summary>
        /// 总里程
        /// </summary>
        public double TotalKM { get; set; }
        public string TotalTime { get; set; }
        public double TotalHeat { get; set; }
        public string MinSpeed { get; set; }
        public int PointScore { get; set; }

        public int RunScore { get; set; }
    }


    public class TeamRunModel
    {

        public int UserCount { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
      
       
    }


    public class RankModel
    {

        public int RankID { get; set; }
        public int Totalkm { get; set; }
        public string NickName { get; set; }
        public string HeadPhoto { get; set; }
        public string TeamName { get; set; }
        


    }
}

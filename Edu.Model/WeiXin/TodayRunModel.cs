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

    }
}

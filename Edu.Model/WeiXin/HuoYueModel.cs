using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.WeiXin
{
   public class HuoYueModel
    {
        //name: '华庭队',
        //  type: 'bar',
        //  barGap: 0,
        //  label: labelOption,
        //  emphasis: {
        //      focus: 'series'
        //  },
        //  data: [120, 132, 101, 34, 190, 190, 190, 190, 190, 190, 190],
        //  backgroundStyle:{
        //      color:'#3BCEDEFF'
        //  }

        public string name { get; set; }
        public string type { get; set; }
        public int barGap { get; set; }
        public string label { get; set; }
        public emphasis emphasis { get; set; }
        public List<int> data { get; set; }
        public backgroundStyle backgroundStyle { get; set; }
    }

    public class emphasis {
        public string focus { get; set; }
    }

    public class backgroundStyle {
        public string color { get; set; }
    }

    public class HuoSqlModel
    {
        public string m { get; set; }
        public int T1Count { get; set; }
        public int T2Count { get; set; }
        public int T3Count { get; set; }
        public int T4Count { get; set; }
    }

    public class HuoDate
    {
        public string type { get; set; }
        public axisTick axisTick { get; set; }

        public List<string> data { get; set; }
    }

    public class axisTick
    {
        public string show { get; set; }
    }
}

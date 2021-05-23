using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.WeiXin
{
   public class RunPointModel
    {
        public List<Points> points { get; set; }
        public string color { get; set; }
        public int width { get; set; }
        public bool dottedLine { get; set; }
        public bool arrowLine { get; set; }
        public int borderWidth { get; set; }

        public string borderColor { get; set; }
    }

    public class Points {
        public double latitude { get; set; }

        public double longitude { get; set; }

        public long pointTimestamp { get; set; }
    }
}

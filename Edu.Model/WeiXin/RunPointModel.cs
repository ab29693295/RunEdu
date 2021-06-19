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

    public class CardPoints {

        public double latitude { get; set; }

        public double longitude { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public static class CardPointHelper
    {
        public static CardPoints cdPoints = new CardPoints();


        public static CardPoints cdPoints1 = new CardPoints();
        public static CardPoints cdPoints2 = new CardPoints();
        public static CardPoints cdPoints3 = new CardPoints();
        public static CardPoints cdPoints4 = new CardPoints();
        public static CardPoints cdPoints5 = new CardPoints();
        public static List<CardPoints> GetPoints()
        {
            List<CardPoints> listPoints = new List<CardPoints>();
            cdPoints.latitude = 117.749584;
            cdPoints.longitude = 39.117407;

            cdPoints1.latitude = 117.749347;
            cdPoints1.longitude = 39.117657;


            cdPoints2.latitude = 117.749593;
            cdPoints2.longitude = 39.116971;

            cdPoints3.latitude = 117.749254;
            cdPoints3.longitude = 39.116767;

            cdPoints4.latitude = 116.185881;
            cdPoints4.longitude = 39.903828;

            cdPoints5.latitude = 116.184545;
            cdPoints5.longitude = 39.903802;

            listPoints.Add(cdPoints);

            listPoints.Add(cdPoints1);
            listPoints.Add(cdPoints2);
            listPoints.Add(cdPoints3);
            listPoints.Add(cdPoints4);
            listPoints.Add(cdPoints5);

            return listPoints;
        }
       
    }
}

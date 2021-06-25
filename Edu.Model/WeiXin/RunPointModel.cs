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

        public int status { get; set; }

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

        public static CardPoints cdPoints6 = new CardPoints();

        public static CardPoints cdPoints7 = new CardPoints();
        public static List<CardPoints> GetPoints()
        {
            List<CardPoints> listPoints = new List<CardPoints>();

            cdPoints.latitude = 39.11765657043457;
            cdPoints.longitude = 117.7488784790039;
            cdPoints.status = 0;

            cdPoints.latitude =  39.11765657043457;
            cdPoints.longitude = 117.7488784790039;

            cdPoints1.latitude =   39.11702346801758;
            cdPoints1.longitude = 117.7497329711914;


            cdPoints1.latitude = 39.11702346801758;
            cdPoints1.longitude = 117.7497329711914;
            cdPoints1.status = 0;


            cdPoints2.latitude = 39.117401123046875;
            cdPoints2.longitude = 117.74925231933594;
            cdPoints2.status = 0;

            cdPoints2.latitude =  39.117401123046875;
            cdPoints2.longitude = 117.74925231933594;

            cdPoints3.latitude = 39.1178894004296875;
            cdPoints3.longitude = 117.74901580810547;
>>>>>>> d24706e1d5e513c95dd96128a8fc871e33ecb3d2

            cdPoints3.latitude = 39.1178894004296875;
            cdPoints3.longitude = 117.74901580810547;
            cdPoints3.status = 0;

            cdPoints5.latitude =   39.88974380493164;
            cdPoints5.longitude = 116.63700103759766;
            cdPoints5.status = 0;


            cdPoints6.latitude = 40.066759;
            cdPoints6.longitude = 116.334928;
            cdPoints6.status = 0;

            cdPoints7.latitude = 40.06071090698242;
            cdPoints7.longitude = 116.35884094238281;
            cdPoints7.status = 0;

            //39.890224,116.636894
            //116.334942,40.066759

            // 116.334928,40.066759  百度坐标

            //116.3284683227539,40.06093978881836 腾讯坐标


            listPoints.Add(cdPoints);

            listPoints.Add(cdPoints1);
            listPoints.Add(cdPoints2);
            listPoints.Add(cdPoints3);
            listPoints.Add(cdPoints4);
            listPoints.Add(cdPoints5);
            listPoints.Add(cdPoints6);
            listPoints.Add(cdPoints7);

            return listPoints;
        }
       
    }
}

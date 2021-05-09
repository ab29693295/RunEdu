using System;
using System.Xml;
namespace RunEdu.Web.Pay
{
    public class SafeXmlDocument:XmlDocument
    {
        public SafeXmlDocument()
        {
            this.XmlResolver = null;
        }
    }
}

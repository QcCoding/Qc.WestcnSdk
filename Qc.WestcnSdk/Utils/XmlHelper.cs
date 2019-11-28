using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Qc.WestcnSdk.Utils
{
    public static class XmlHelper
    {
        public static T Deserialize<T>(string xmlStr) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(xmlStr))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return default(T);
        }
    }
}

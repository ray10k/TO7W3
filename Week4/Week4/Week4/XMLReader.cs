using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week4
{
    /// <Author>
    /// Erwin Bonnet
    /// </Author>
    public class XMLReader
    {
        public static string xmlPath = "Testset V 2.0\\testsamples.xml";

        public static List<KeyValuePair<string, NumberPlateCoordinates>> ReadXML()
        {
            return ReadXML(xmlPath);
        }

        public static List<KeyValuePair<string, NumberPlateCoordinates>> ReadXML(string path){
            List<KeyValuePair<string, NumberPlateCoordinates>> list = new List<KeyValuePair<string, NumberPlateCoordinates>>();

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = null;
            xmlDoc.PreserveWhitespace = false;
            xmlDoc.Load(path);
            node = xmlDoc.DocumentElement;

            KeyValuePair<string, NumberPlateCoordinates> kvp;
            NumberPlateCoordinates npc;

            foreach (XmlNode n in node)
            {
                npc = new NumberPlateCoordinates();

                npc.FileName = n.Attributes["filename"].Value;
                XmlNodeList s = n.ChildNodes[0].ChildNodes[0].ChildNodes;
                foreach (XmlNode cornerLocation in s)
                {
                    if (cornerLocation.Name.Equals("upperleft"))
                        npc.LeftTop = new System.Drawing.Point(Int32.Parse(cornerLocation.Attributes["x"].Value), Int32.Parse(cornerLocation.Attributes["y"].Value));
                    if (cornerLocation.Name.Equals("upperright"))
                        npc.RightTop = new System.Drawing.Point(Int32.Parse(cornerLocation.Attributes["x"].Value), Int32.Parse(cornerLocation.Attributes["y"].Value));
                    if (cornerLocation.Name.Equals("lowerleft"))
                        npc.LeftBottom = new System.Drawing.Point(Int32.Parse(cornerLocation.Attributes["x"].Value), Int32.Parse(cornerLocation.Attributes["y"].Value));
                    if (cornerLocation.Name.Equals("lowerright"))
                        npc.RightBottom = new System.Drawing.Point(Int32.Parse(cornerLocation.Attributes["x"].Value), Int32.Parse(cornerLocation.Attributes["y"].Value));
                }

                kvp = new KeyValuePair<string, NumberPlateCoordinates>(n.InnerText, npc);
                list.Add(kvp);
            }
            
            return list;
        }
    }
}

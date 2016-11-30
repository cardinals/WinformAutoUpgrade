using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace Win.Tools
{
    [XmlType("file")]
    public class File
    {
        [XmlAttribute("path")]
        public string path { get; set; }
        [XmlAttribute("url")]
        public string url { get; set; }
        [XmlAttribute("lastver")]
        public string lastver { get; set; }
        [XmlAttribute("size")]
        public string size { get; set; }
        [XmlAttribute("needRestart")]
        public bool needRestart { get; set; }
    }
    [XmlType("updateFiles")]
    public class UpdateFiles : List<File> { }
    public class Config
    {
        /// <summary>
        /// 包含文件名的全路径
        /// </summary>
        /// <param name="fileFullPath"></param>
        public static void GenerateXmlFile(string fileFullPath, Type type, object obj)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(type);
                StreamWriter sw = new StreamWriter(fileFullPath);
                xs.Serialize(sw, obj);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

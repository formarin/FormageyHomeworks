using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Figure(1, 1);
            var triangle = new Figure(3, 1);
            var square = new Figure(4, 1);

            var figList = new List<Figure>() { circle, triangle, square };

            ////Json
            //var serFigList = JsonConvert.SerializeObject(figList);
            //var desFiglist = JsonConvert.DeserializeObject<List<Figure>>(serFigList);

            ////XML
            //var formatter = new XmlSerializer(typeof(List<Figure>));
            //using (FileStream fs = new FileStream("figList.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, figList);
            //}
            //using (FileStream fs = new FileStream("figList.xml", FileMode.OpenOrCreate))
            //{
            //    var desFigList = (List<Figure>)formatter.Deserialize(fs);
            //}

            ////Binary
            //using (FileStream fs = new FileStream("figList.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, figList);
            //}
            //using (FileStream fs = new FileStream("figList.dat", FileMode.OpenOrCreate))
            //{
            //    var desFigList = (List<Figure>)formatter.Deserialize(fs);
            //}
        }
    }
}

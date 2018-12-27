using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipment equipment = new Equipment(1, 2, 5000, "Сканер");
            Equipment equipment2 = new Equipment(2, 3, 6000, "Принтер");
            Equipment[] equipments = new Equipment[] { equipment, equipment2 };
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream("binaryEquipment.txt", FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, equipment);
            }
            using (FileStream fs = new FileStream("binaryEquipment.txt", FileMode.OpenOrCreate))
            {
                Console.WriteLine("---------------------------Binary--------------------------------");
                Equipment equipment1 = (Equipment)binary.Deserialize(fs);
                equipment1.Info();
            }
            SoapFormatter soap = new SoapFormatter();
            using (FileStream fs = new FileStream("soapEquipment.txt", FileMode.OpenOrCreate))
            {
                soap.Serialize(fs, equipment);
            }
            using (FileStream fs = new FileStream("soapEquipment.txt", FileMode.OpenOrCreate))
            {
                Console.WriteLine("---------------------------SOAP--------------------------------");
                Equipment equipment1 = (Equipment)soap.Deserialize(fs);
                equipment1.Info();
            }
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Equipment));
            using(FileStream fs = new FileStream("jsonEquipment.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, equipment);
            }
            Console.WriteLine("---------------------------JSON--------------------------------");
            using (FileStream fs = new FileStream("jsonEquipment.json", FileMode.OpenOrCreate))
            {
                Equipment equipment1 = (Equipment)jsonSerializer.ReadObject(fs);
                equipment.Info();
            }
            Console.WriteLine("---------------------------XML--------------------------------");
            XmlSerializer xml = new XmlSerializer(typeof(Equipment));
            using (FileStream fs = new FileStream("xmlEquipment.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, equipment);
            }
            using (FileStream fs = new FileStream("xmlEquipment.xml", FileMode.OpenOrCreate))
            {
                Equipment equipment1 = (Equipment)xml.Deserialize(fs);
                equipment1.Info();
              
            }
            XmlSerializer xmlMass = new XmlSerializer(typeof(Equipment[]));
            using (FileStream fs = new FileStream("xmlEquipmentMass.xml", FileMode.OpenOrCreate))
            {
               xmlMass.Serialize(fs, equipments);
            }
            Console.WriteLine("---------------------------XMLMass--------------------------------");
            using (FileStream fs = new FileStream("xmlEquipmentMass.xml", FileMode.OpenOrCreate))
            {
                Equipment[] equipment1 = (Equipment[])xmlMass.Deserialize(fs);
                foreach(Equipment a in equipment1)
                {
                    a.Info();
                }
            }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("xmlfile.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("user");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            XmlNode childnode = xRoot.SelectSingleNode("user[company='Microsoft']");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);
            XDocument xdoc = new XDocument();
            XElement boat = new XElement("boat");
            XAttribute boatName = new XAttribute("name", "boat");
            XElement boatAge = new XElement("age","20");
            XElement boatCost = new XElement("cost", "150");
            boat.Add(boatName);
            boat.Add(boatAge);
            boat.Add(boatCost);
            XElement ship = new XElement("boat");
            XAttribute shipName = new XAttribute("name", "ship");
            XElement shipAge = new XElement("age", "5");
            XElement shipCost = new XElement("cost", "50000");
            ship.Add(shipName);
            ship.Add(shipAge);
            ship.Add(shipCost);
            XElement WaterTransport = new XElement("watertransport");
            WaterTransport.Add(boat);
            WaterTransport.Add(ship);
            xdoc.Add(WaterTransport);
            xdoc.Save("transport.xml");
            XDocument xdoc1 = XDocument.Load("transport.xml");
            var item = from xd in xdoc1.Element("watertransport").Elements("boat")
                       where xd.Element("cost").Value == "50000"
                       select new Tranport
                       {
                           Name = xd.Attribute("name").Value,
                           Age = xd.Element("age").Value,
                           Cost = xd.Element("cost").Value
                       };
            foreach (var items in item)
                Console.WriteLine("{0} - {1} - {2}", items.Name, items.Age, items.Cost);
            Console.ReadKey();
        }
    }
    class Tranport
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Cost { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Equipment
    {
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Average { get; set; }
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Equipment()
        {

        }
        public Equipment(int a,int ag,int cost,string str)
        {
            Average = a;
            Age = ag;
            Cost = cost;
            Name = str;
        }
        public void Info()
        {
            Console.WriteLine($"Номер товара:{Average}");
            Console.WriteLine($"Возраст товаара:{Age}");
            Console.WriteLine($"Название товара:{Name}");
            Console.WriteLine($"Цена товара:{Cost}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CSharpLearning
{
    public class MySerialize : IDemonstrate
    {
        public void Demonstrate()
        {
            RemainInstance();
        }

        [Serializable]
        class MySerialPerson
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public void SerializeOneObject()
        {
            string fileName = $"D:/demo.data";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter ft = new BinaryFormatter();
                MySerialPerson ps = new MySerialPerson()
                {
                    Name = "Lin",
                    Age = 26,
                };
                ft.Serialize(fs, ps);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter ft = new BinaryFormatter();
                MySerialPerson ps = (MySerialPerson)ft.Deserialize(fs);
                Console.WriteLine($"Name:{ps.Name}\nAge:{ps.Age}");
            }
        }
        [Serializable]
        class MyStudent
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
        }
        public void MyDataContractSerializer()
        {
            string fileName = $"D:/demo.xml";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(MyStudent));
                MyStudent s = new MyStudent()
                {
                    ID = 12213,
                    Name = "Lin",
                    City = "Auckland"
                };
                dcs.WriteObject(fs, s);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(MyStudent));
                MyStudent s = dcs.ReadObject(fs) as MyStudent;
                Console.WriteLine($"ID: {s.ID}\nName: {s.Name}\nCity:{s.City}");
            }
        }
        [Serializable]
        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Owner { get; set; }
        }
        public void ObjectToJson()
        {
            string fileName = $"D:/demo.json";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Pet[] pets =
                {
                    new Pet{ Name = "Dog A",Age=3,Owner = "Jack"},
                    new Pet{ Name = "Cat E",Age=2,Owner = "Bob"}
                };
                DataContractJsonSerializer sz = new DataContractJsonSerializer(pets.GetType());
                sz.WriteObject(fs, pets);
            }

            using (FileStream fs = File.OpenRead(fileName))
            {
                DataContractJsonSerializer sz = new DataContractJsonSerializer(typeof(Pet[]));
                Pet[] pets = (Pet[])sz.ReadObject(fs);
                foreach (Pet p in pets)
                {
                    Console.WriteLine($"Name: {p.Name}\nAge:{p.Age}\nOwner:{p.Owner}\n");
                }
            }
        }
        [Serializable]
        class MyCar
        {
            public string Color;
            public decimal Speed;
            [NonSerialized]
            public decimal Weight;
        }
        public void IgnoreSomeAttributes()
        {
            MemoryStream mstream = new MemoryStream();
            BinaryFormatter ft = new BinaryFormatter();

            MyCar car1 = new MyCar
            {
                Color = "While",
                Speed = 165.2M,
                Weight = 2324.6M
            };
            ft.Serialize(mstream, car1);
            mstream.Position = 0L;
            MyCar car2 = (MyCar)ft.Deserialize(mstream);
            Console.WriteLine($"Color: {car2.Color}\nSpeed: {car2.Speed}\nWeight: {car2.Weight}");
            mstream.Dispose();
        }
        public class MyTaskItem
        {
            public int TaskID { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime FinishTime { get; set; }
            public string TaskName { get; set; }
            public string TaskDesc { get; set; }
        }
        public void MyXmlSerializer()
        {
            string fileName = $"D:/demo.xml";
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                MyTaskItem item = new MyTaskItem
                {
                    TaskID = 1001,
                    StartTime = new DateTime(2018, 9, 6, 14, 30, 0),
                    FinishTime = new DateTime(2018, 9, 7, 18, 0, 0),
                    TaskName = "Track #1",
                    TaskDesc = "Do something"
                };
                XmlSerializer xmlsz = new XmlSerializer(item.GetType());
                xmlsz.Serialize(fs, item);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xsz = new XmlSerializer(typeof(MyTaskItem));
                MyTaskItem item = (MyTaskItem)xsz.Deserialize(fs);
                Console.WriteLine($"Task ID:{item.TaskID}\nTask Name:{item.TaskName}\nStart: {item.StartTime}\nFinish: {item.FinishTime}\nDesc:{item.TaskDesc}");
            }
        }
        public class MyTest
        {
            public double[] Values { get; set; }
            [XmlArray("Strs")]
            public List<string> StringList { get; set; }
        }
        public void MyXmlArrayAttribute()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                MyTest t = new MyTest
                {
                    Values = new double[]
                    {
                        0.33d, 1.10005d, 12.456d
                    },
                    StringList = new List<string>
                    {
                        "Test 1", "Test 2", "Test 3"
                    }
                };
                XmlSerializer sz = new XmlSerializer(typeof(MyTest));
                sz.Serialize(ms, t);
                ms.Position = 0l;
                using (StreamReader reader = new StreamReader(ms))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }

            }
        }

        [XmlRoot("prod_info")]
        public class MyProduction
        {
            [XmlElement("prod_id")]
            public long ProductID { get; set; }
            [XmlElement("prod_time")]
            public DateTime ProductTime { get; set; }
            [XmlElement("prod_size")]
            public float ProductSize { get; set; }
            [XmlElement("prod_remarks")]
            public string ProductRemarks { get; set; }
        }

        public void CustomXmlElementName()
        {
            using (FileStream fs = new FileStream($"D:/data.xml", FileMode.Create))
            {
                MyProduction prd = new MyProduction()
                {
                    ProductID = 7078201,
                    ProductTime = new DateTime(2018, 1, 3),
                    ProductSize = 37.33f,
                    ProductRemarks = "new style"
                };
                StringBuilder strbd = new StringBuilder();
                strbd.Append($"ProductID:{prd.ProductID}");
                strbd.Append($"ProductTime:{prd.ProductTime}");
                strbd.Append($"ProductSize:{prd.ProductSize}");
                strbd.Append($"ProductRemarks:{prd.ProductRemarks}");
                Console.WriteLine(strbd);
                XmlSerializer serializer = new XmlSerializer(prd.GetType());
                serializer.Serialize(fs, prd);
            }

            using (FileStream fs = new FileStream($"D:/data.xml", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string xml = reader.ReadToEnd();
                    Console.WriteLine("Serialized File");
                    Console.WriteLine(xml);
                }
            }
        }
        [XmlRoot("demo_test")]
        public class MyTest2
        {
            [XmlAttribute("val_a")]
            public int ValueA;
            [XmlAttribute("val_b")]
            public bool ValueB;
            [XmlAttribute("val_c")]
            public string ValueC;
        }
        public void CustomXmlAttribute()
        {
            MemoryStream ms = new MemoryStream();
            MyTest2 t = new MyTest2
            {
                ValueA = 60000,
                ValueB = true,
                ValueC = "Start up"
            };
            XmlSerializer sz = new XmlSerializer(t.GetType());
            sz.Serialize(ms, t);
            ms.Position = 0l;
            String xmlDoc = null;
            using (StreamReader reader = new StreamReader(ms))
            {
                xmlDoc = reader.ReadToEnd();
                Console.WriteLine(xmlDoc);
            }
        }
        [XmlRoot(Namespace = "test.org")]
        public class MyTest3
        {
            [XmlElement(Namespace = "test.org/prop")]
            public int Value1 { get; set; }
            [XmlElement(Namespace = "test.org/prop")]
            public string Value2 { get; set; }
        }
        public void CustomXmlNamespace()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                MyTest3 vt = new MyTest3
                {
                    Value1 = 96,
                    Value2 = "One"
                };
                XmlSerializer szr = new XmlSerializer(vt.GetType());
                szr.Serialize(ms, vt);

                ms.Position = 0L;
                using (StreamReader rd = new StreamReader(ms))
                {
                    string xml = rd.ReadToEnd();
                    Console.WriteLine("XML file:{0}", xml);
                }
            }
        }
        public class MyTest4
        {
            public int ItemCount;
            public string[] Items;
        }
        public class MyTest5
        {
            public int ItemCount;
            [XmlArray("item_list")]
            [XmlArrayItem("sub_item")]
            public string[] Items;
        }
        public void Serialize<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer sz = new XmlSerializer(typeof(T));
                sz.Serialize(ms, obj);

                ms.Position = 0;
                using (StreamReader rd = new StreamReader(ms))
                {
                    string xml = rd.ReadToEnd();
                    Console.WriteLine(xml);
                }
            }
        }
        public void MyCustomXmlElement()
        {
            MyTest4 t1 = new MyTest4();
            t1.Items = new string[] { "item 1", "item 2", "item 3" };
            t1.ItemCount = t1.Items.Length;
            Console.WriteLine("Default Serialized Solution:");
            Serialize(t1);
            MyTest5 t2 = new MyTest5();
            t2.Items = new string[] { "item 1", "item 2", "item 3" };
            t2.ItemCount = t2.Items.Length;
            Console.WriteLine("Custom Serialized Solution:");
            Serialize(t2);
        }
        [DataContract]
        public class Album
        {
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string Artist { get; set; }
            [DataMember]
            public int Year { get; set; }
            [DataMember]
            public string Cover { get; set; }
        }
        public void SimplyCustomizedDataProtocol()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Album ab = new Album
                {
                    Title = "Lee Songs",
                    Year = 2007,
                    Artist = "Lee Tan",
                    Cover = "05.jpg"
                };
                DataContractSerializer szr = new DataContractSerializer(ab.GetType());
                szr.WriteObject(ms, ab);
                ms.Position = 0l;
                using (StreamReader reader = new StreamReader(ms))
                {
                    string data = reader.ReadToEnd();
                    Console.WriteLine("Content:{0}", data);
                }
            }
        }
        [DataContract(Name = "disk_info")]
        public class Disk
        {
            [DataMember(Name = "total_space")]
            public long Space { get; set; }
            [DataMember(Name = "driver_type")]
            public byte Type { get; set; }
        }
        public void CustomizedNameProtocol()
        {
            using (FileStream fs = File.Open($"D:/data.xml", FileMode.Create))
            {
                Disk d = new Disk
                {
                    Space = 560008210310,
                    Type = 0x0C
                };
                DataContractSerializer sz = new DataContractSerializer(d.GetType());
                sz.WriteObject(fs, d);
            }
            using (StreamReader reader = new StreamReader($"D:/data.xml"))
            {
                Console.WriteLine("Result:");
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        [DataContract(Namespace = "demo", Name = "stu_data")]
        public class StudentV1
        {
            [DataMember(Name = "stu_id")]
            public long ID { get; set; }
            [DataMember(Name = "stu_name")]
            public string Name { get; set; }
            [DataMember(Name = "stu_email")]
            public string Email { get; set; }
        }
        [DataContract(Namespace = "demo", Name = "stu_data")]
        public class StudentV2
        {
            [DataMember(Name = "stu_id")]
            public long StudentID { get; set; }
            [DataMember(Name = "stu_name")]
            public string StudentName { get; set; }
            [DataMember(Name = "stu_email")]
            public string StudentEmail { get; set; }
        }
        public void UseSameProtocolForDifferentDataType()
        {
            using (FileStream fs = new FileStream($"D:/test.xml", FileMode.Create))
            {
                StudentV1 st1 = new StudentV1
                {
                    ID = 201811428023,
                    Name = "Zhao",
                    Email = "t003@21cn.com"
                };
                DataContractSerializer szr = new DataContractSerializer(st1.GetType());
                szr.WriteObject(fs, st1);
            }
            using (FileStream fs = new FileStream($"D:/test.xml", FileMode.Open))
            {
                DataContractSerializer szr = new DataContractSerializer(typeof(StudentV2));
                StudentV2 st2 = (StudentV2)szr.ReadObject(fs);
                string msg = "Information:\n" + $"Name:{st2.StudentName}\n" + $"ID:{st2.StudentID}\n" + $"Email:{st2.StudentEmail}";
                Console.WriteLine(msg);
            }
        }
        //280
        [DataContract]
        public class Sample
        {
            [DataMember(Name = "val_1")]
            public double TestVal1;
            [DataMember(Name = "val_2")]
            public DateTime TestVal2;
            [DataMember(Name = "val_3")]
            public uint TestVal3;
        }
        public void DataToJsonFile()
        {
            using (FileStream fs = new FileStream($"D:/data.json", FileMode.Create))
            {
                Sample s1 = new Sample
                {
                    TestVal1 = 333.6515d,
                    TestVal2 = DateTime.Now,
                    TestVal3 = 797001
                };
                DataContractJsonSerializer jsonsz = new DataContractJsonSerializer(typeof(Sample));
                jsonsz.WriteObject(fs, s1);
            }

            using (FileStream fs = new FileStream($"D:/data.json", FileMode.Open))
            {
                DataContractJsonSerializer jssz = new DataContractJsonSerializer(typeof(Sample));
                Sample obj = jssz.ReadObject(fs) as Sample;
                Console.WriteLine($"{nameof(Sample.TestVal1)} = {obj.TestVal1}\n{nameof(Sample.TestVal2)} = {obj.TestVal2}\n{nameof(Sample.TestVal3)} = {obj.TestVal3}");
            }
        }
        //281
        [DataContract(Namespace = "test-rd-data", Name = "rd_body")]
        public class Record
        {
            [DataMember(Name = "rd_ord")]
            public int RecordOrder { get; set; }
            [DataMember(Name = "rd_title")]
            public string RecordTitle { get; set; }
            [DataMember(Name = "rd_size")]
            public long SizeInBytes { get; set; }
            [IgnoreDataMember]
            public bool Tracked { get; set; }
        }
        public void IgnoreAttrubites()
        {
            using (FileStream fs = new FileStream($"D:/rd.xml", FileMode.Create))
            {
                Record rd = new Record
                {
                    RecordOrder = 1,
                    RecordTitle = "Numbers",
                    SizeInBytes = 12105,
                    Tracked = true
                };
                DataContractSerializer szr = new DataContractSerializer(typeof(Record));
                szr.WriteObject(fs, rd);
            }
            using (FileStream fs = new FileStream($"D:/rd.xml", FileMode.Open))
            {
                DataContractSerializer szr = new DataContractSerializer(typeof(Record));
                Record rd = szr.ReadObject(fs) as Record;
                string msg = null;
                msg += $"{nameof(rd.RecordOrder)} = {rd.RecordOrder}\n";
                msg += $"{nameof(rd.RecordTitle)} = {rd.RecordTitle}\n";
                msg += $"{nameof(rd.SizeInBytes)} = {rd.SizeInBytes}\n";
                msg += $"{nameof(rd.Tracked)} = {rd.Tracked}\n";
                Console.WriteLine(msg);
            }
        }
        //282
        [DataContract]
        public class MyTest6
        {
            [DataMember(Order = 2)]
            public string PropD { get; set; }
            [DataMember(Order = 0)]
            public long PropC { get; set; }
            [DataMember(Order = 1)]
            public int PropB { get; set; }
            [DataMember(Order = 3)]
            public short PropA { get; set; }
        }
        public void MyDataMemberOrder()
        {
            using (FileStream fs = new FileStream($"D:/data.xml", FileMode.Create))
            {
                MyTest6 t = new MyTest6
                {
                    PropA = 3,
                    PropB = 15,
                    PropC = 100000L,
                    PropD = "abcde"
                };
                DataContractSerializer szr = new DataContractSerializer(typeof(MyTest6));
                szr.WriteObject(fs, t);
            }
            using (FileStream fs = new FileStream($"D:/data.xml", FileMode.Open))
            {
                XDocument doc = XDocument.Load(fs);
                Console.WriteLine(doc);
            }
        }
        //283
        [DataContract]
        public class OrderDetails
        {
            [DataMember]
            public string ContactName { get; set; }
            [DataMember]
            public decimal Price { get; set; }
            [DataMember]
            public int Quantity { get; set; }
            [DataMember]
            public float Weight { get; set; }
        }
        [DataContract]
        public class OrderInfo
        {
            [DataMember]
            public int OrderNo { get; set; }
            [DataMember]
            public DateTime BuildTime { get; set; }
            [DataMember]
            public OrderDetails DetailsData { get; set; }
        }
        public void RemainInstance()
        {
            using (FileStream fs = new FileStream($"D:/data.xml", FileMode.Create))
            {
                OrderDetails dt1 = new OrderDetails
                {
                    ContactName = "Lee",
                    Price = 3.15M,
                    Quantity = 12,
                    Weight = 17.5f
                };
                OrderInfo[] ords =
                {
                    new OrderInfo{
                        OrderNo = 1,
                        BuildTime = new DateTime(2018,3,27),
                        DetailsData = dt1
                    },
                    new OrderInfo{
                        OrderNo = 2,
                        BuildTime = new DateTime(2018,9,2),
                        DetailsData = dt1
                    }
                };
                DataContractSerializerSettings settings = new DataContractSerializerSettings();
                settings.PreserveObjectReferences = true;
                DataContractSerializer szr = new DataContractSerializer(ords.GetType(), settings);
                szr.WriteObject(fs, ords);
            }
            using (FileStream fs = new FileStream($"D:/data.xml", FileMode.Open))
            {
                XDocument doc = XDocument.Load(fs);
                Console.WriteLine(doc);
            }
        }
    }
}

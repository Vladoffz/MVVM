
using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Unit
{
    class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                XmlSerialization<Person> serialization = new XmlSerialization<Person>();
                Person tom = new Person { Name = "Tom", Age = 35 };
                string json = JsonConvert.SerializeObject(tom,);
                Console.WriteLine(json);
                Person restoredPerson = JsonConvert.DeserializeObject<Person>(json);
                Console.WriteLine(restoredPerson.Name);
                Console.ReadKey();
            }
        }
        public class XmlSerialization<T>
        {
            public string path { get; set; }
            public T obj { get; set; }
            XmlSerializer formatter;
            public XmlSerialization(string path, T obj)
            {
                this.path = path;
                this.obj = obj;

                formatter = new XmlSerializer(typeof(T));

            }


            public bool Serialize()
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, obj);

                    return true;
                }
                return false;
            }
            public T Deserialize()
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    T newObject = (T)formatter.Deserialize(fs);

                    //string str = String.Format("Object DEserialized: Width: {0}, Height: {1}, Cost: {2}", newBaguet.Width, newBaguet.Height, newBaguet.Cost);
                    return newObject;
                }
            }
    }
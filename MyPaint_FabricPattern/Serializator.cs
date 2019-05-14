using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Json;
using System.IO;

namespace MyPaint_FabricPattern
{
    
    class Serializator
    {
        DataContractJsonSerializerSettings settings;
        String filepass;
        String typepass;
        DataContractJsonSerializer jsonFormatter;
        private static Serializator instance;
        
        private Serializator()
        {
            
        }

        public static Serializator getInstance()
        {
            if (instance == null)
                instance = new Serializator();
            return instance;
        }
        public Type GetTypeFromString(String type_str)
        {
            Type type;
            if (type_str == "Rectangle" )
            {
                type = typeof(Rectangle);
            }
            else
            {
                if (type_str == "Triangle")
                {
                    type = typeof(Triangle);
                }
                else
                {
                    if (type_str == "Ellipse" )
                    {
                        type = typeof(Ellipse);
                    }
                    else
                    {
                        type = typeof(Line);
                    }
                }
            }
            return type;
        }
        public String GetStringType(Type type)
        {
            String type_str;
            if (type == typeof(Rectangle))
            {
                type_str = "Rectangle";
            }
            else
            {
                if (type == typeof(Triangle))
                {
                    type_str = "Triangle";
                }
                else
                {
                    if (type == typeof(Ellipse))
                    {
                        type_str = "Ellipse";
                    }
                    else
                    {
                        type_str = "Line";
                    }
                }
            }
            return type_str;
        }
        public void Serialize_JSON(object obj,Type type)
        {
            jsonFormatter = new DataContractJsonSerializer(type);
            using (FileStream fs = new FileStream(filepass, FileMode.Append))
            {
                //jsonFormatter.KnownTypes
                jsonFormatter.WriteObject(fs, obj);
            }
            
        }
        public void Serialize_All(List<Shape> shape_list)
        {
            Shape[] shapes = shape_list.ToArray();
            int counter = 1;
            foreach (Shape shape in shapes)
            {
                //this.SetFilePass("shapes/" + Convert.ToString(counter) + ".json");
                String str_type = this.GetStringType(shape.GetType());
                this.Serialize_JSON(shape, shape.GetType());
                using (FileStream fs = new FileStream("shapes/" + Convert.ToString(counter) + "_type" + ".json", FileMode.Create))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(str_type);
                    fs.Write(bytes, 0, bytes.Length);
                }
                counter++;
            }
            
        }
        public object DeSerialize_JSON(Type type)
        {
            object result;
            jsonFormatter = new DataContractJsonSerializer(type);
            using (FileStream fs = new FileStream(filepass, FileMode.Open))
            {
                //jsonFormatter.KnownTypes
                if (fs.Length != 0)
                {
                    result = jsonFormatter.ReadObject(fs);
                }
                else
                {
                    result = null;
                }
            }
            return result;

        }
        public void SetFilePass(String shapepass, String typespass, Boolean rewrite)
        {
            this.filepass = shapepass;
            this.typepass = typespass;
            if (rewrite)
            {
                using (FileStream fs = new FileStream(filepass, FileMode.Create)) { }
                using (FileStream fs = new FileStream(typepass, FileMode.Create)) { }
            }
        }
        public void Serialize(List<Shape> shape_list)
        {
            while (shape_list.Count != 0)
            {
                Shape shape = shape_list.First();
                Type type = shape.GetType();
                //jsonFormatter = new DataContractJsonSerializer("".GetType());
                using (StreamWriter sw = new StreamWriter(typepass))
                {
                    sw.WriteLine(GetStringType(type));
                }
                jsonFormatter = new DataContractJsonSerializer(type);
                using (FileStream fs = new FileStream(filepass, FileMode.Append))
                {
                    jsonFormatter.WriteObject(fs, shape);
                }
                shape_list.RemoveAt(0);
            }
            
        }
        public void DeSerialize(List<Shape> shape_list)
        {
            Object shape;
            shape_list = new List<Shape>();
            String typestr;
            //jsonFormatter = new DataContractJsonSerializer("".GetType());
            using (StreamReader sr = new StreamReader(typepass))
            {
                typestr = sr.ReadLine();
            }
            jsonFormatter = new DataContractJsonSerializer(this.GetTypeFromString(typestr));
            using (FileStream fs = new FileStream(filepass, FileMode.Open))
            {
                shape = jsonFormatter.ReadObject(fs);
            }
            //is 
            shape_list.Add((Shape)shape);
        }
        public void Serialize_new(List<Shape> list)
        {
            //File.Create("test/shapes.json");
            DataContractJsonSerializerSettings settingsbuff = new DataContractJsonSerializerSettings();
            List<Type> types = new List<Type>();
            for (int i=0; i < list.Count; i++)
            {
                if (!types.Contains(list.ElementAt(i).GetType()))
                {
                    types.Add(list.ElementAt(i).GetType());
                }
            }

            settingsbuff.KnownTypes = types;
            settingsbuff.SerializeReadOnlyTypes = true;
            this.settings = settingsbuff;
            jsonFormatter = new DataContractJsonSerializer(list.GetType(),settings);
            using (FileStream fs = new FileStream("test/shapes.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs,list);
            }
        }
        public List<Shape> Deserialize_new()
        {
            List<Shape> list=new List<Shape>();
            //File.Create("test/shapes.json");
            jsonFormatter = new DataContractJsonSerializer(list.GetType(),settings);
            using (FileStream fs = new FileStream("test/shapes.json", FileMode.Open))
            {
                list= (List<Shape>)jsonFormatter.ReadObject(fs);
            }
            return list;
        }
    }
}

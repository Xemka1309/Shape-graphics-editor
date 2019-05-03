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
        String filepass;
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
        public String GetStringType(Type type)
        {
            String type_str;
            if (type == typeof(Rectangle))
            {
                type_str = "RECTANGLE";
            }
            else
            {
                if (type == typeof(Triangle))
                {
                    type_str = "TRIANGLE";
                }
                else
                {
                    if (type == typeof(Ellipse))
                    {
                        type_str = "ELLIPSE";
                    }
                    else
                    {
                        type_str = "LINE";
                    }
                }
            }
            return type_str;
        }
        public void SetFilePass(String pass)
        {
            filepass = pass;
            FileStream fs = new FileStream(filepass, FileMode.Create);
            fs.Dispose();
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
                this.SetFilePass("shapes/" + Convert.ToString(counter) + ".json");
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

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
            // List<Shape> list = new List<Shape>();
            //list.Add(new Rectangle(5,Colo))
            DataContractJsonSerializerSettings settingsbuff = new DataContractJsonSerializerSettings();
            List<Type> types = new List<Type>();
            types.Add(typeof(Rectangle));
            types.Add(typeof(Triangle));
            types.Add(typeof(Ellipse));
            types.Add(typeof(Line));

            settingsbuff.KnownTypes = types;
            settingsbuff.SerializeReadOnlyTypes = true;
            this.settings = settingsbuff;

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
            if (type_str == "Rectangle")
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
                    if (type_str == "Ellipse")
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
        public void Serialize_JSON(object obj, Type type)
        {
            jsonFormatter = new DataContractJsonSerializer(type);
            using (FileStream fs = new FileStream(filepass, FileMode.Append))
            {
                //jsonFormatter.KnownTypes
                jsonFormatter.WriteObject(fs, obj);
            }

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

        public void Serialize(List<Shape> list, String pass)
        {
            //File.Create("test/shapes.json");
            //DataContractJsonSerializerSettings settingsbuff = new DataContractJsonSerializerSettings();
            //List<Type> types = new List<Type>();
            //for (int i=0; i < list.Count; i++)
            //{
            //    if (!types.Contains(list.ElementAt(i).GetType()))
            //    {
            //       types.Add(list.ElementAt(i).GetType());
            //   }
            // }

            //settingsbuff.KnownTypes = types;
            // settingsbuff.SerializeReadOnlyTypes = true;
            //this.settings = settingsbuff;
            jsonFormatter = new DataContractJsonSerializer(list.GetType(), settings);
            using (FileStream fs = new FileStream(pass, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, list);
            }
        }
        public List<Shape> Deserialize()
        {
            List<Shape> list = new List<Shape>();
            //File.Create("test/shapes.json");
            //settings.
            //EmitTypeInformation emitTypeInformation = new EmitTypeInformation();
            jsonFormatter = new DataContractJsonSerializer(list.GetType(), settings);
            using (FileStream fs = new FileStream("test/shapes.json", FileMode.Open))
            {
                //jsonFormatter.
                list = (List<Shape>)jsonFormatter.ReadObject(fs);
            }
            return list;
        }
        public void SerializeDynamic(List<Shape> shape_list)
        {
            List<Shape> list = new List<Shape>();
            JsonSerializerSettings jsettings = new JsonSerializerSettings();

            jsettings.TypeNameHandling = TypeNameHandling.All;

            //String str=JsonConvert.SerializeObject(shape_list,shape_list.GetType(),jsettings);
            //str= JsonConvert.SerializeObject()
            //JsonConverterCollection jsonConverters = new JsonConverterCollection();
            // jsonConverters
            //JsonArrayAttribute jsonArrayAttribute = new JsonArrayAttribute();
            //JsonConvert.
            using (StreamWriter sw = new StreamWriter("test/shapesdynamic.json"))
            {
                //for ( int i = 0; i < shape_list.Count; i++)
                //{
                //sw.Write('[');
                //     String str = JsonConvert.SerializeObject(shape_list.ElementAt(i),jsettings);
                //sw.Write(str);
                //sw.Write(']');
                // }
                String str = JsonConvert.SerializeObject(shape_list);
                sw.Write(str);
            }


        }
        public List<Shape> DeserializeDynamic()
        {
            List<Shape> list = new List<Shape>();
            //JObject.Parse(str);

            //jsonFormatter = new DataContractJsonSerializer(list.GetType(), settings);
            //TextReader textReader = new TextReader();
            using (StreamReader sr = new StreamReader("test/shapes.json"))
            {
                String str = sr.ReadToEnd();
                //JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                //serializerSettings.
                //JArray jArray = new JArray();

                //jArray.Add(JObject.Parse(str));
                //JTokenReader tokenReader = new JTokenReader(new Jtoken,"");
                //jArray.Add()
                JArray jArray = new JArray();
                JsonTextReader jsonTextReader = new JsonTextReader(sr);
                while (!sr.EndOfStream)
                {
                    jArray.Add(jsonTextReader.Read());
                }

                //jArray.Next.



            }
            return list;
        }

        class myreader : JsonReader
        {
            public override bool Read()
            {
                throw new NotImplementedException();
            }
        }
        public void Serialize2(List<Shape> list)
        {
            //File.Create("test/shapes.json");
            //DataContractJsonSerializerSettings settingsbuff = new DataContractJsonSerializerSettings();
            //List<Type> types = new List<Type>();
            //for (int i=0; i < list.Count; i++)
            //{
            //    if (!types.Contains(list.ElementAt(i).GetType()))
            //    {
            //       types.Add(list.ElementAt(i).GetType());
            //   }
            // }

            //settingsbuff.KnownTypes = types;
            // settingsbuff.SerializeReadOnlyTypes = true;
            //this.settings = settingsbuff;
            jsonFormatter = new DataContractJsonSerializer(list.GetType(), settings);
            settings.EmitTypeInformation = System.Runtime.Serialization.EmitTypeInformation.Always;
            //settings.
            using (FileStream fs = new FileStream("test/shapes.json", FileMode.Create))
            {

            }
        }

        public List<Shape> Desirialize_err(String pass)
        {
            List<Shape> shapeList = new List<Shape>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Shape>), settings);
            String textFromFile;
            using (FileStream fs = new FileStream(pass, FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                textFromFile = Encoding.Default.GetString(array);

            }
            if (pass.IndexOf(".json") == -1)
            {
                MessageBox.Show("invalid file extension");
                return shapeList;
            }
            if (textFromFile.IndexOf("{\"__type\"") == -1 || textFromFile.IndexOf("[{") == -1)
            {
                MessageBox.Show("invalid file");
            }

            textFromFile.Remove(0, 1);

            while (textFromFile.Length > 1)
            {

                int startIndex = textFromFile.IndexOf("{\"__type\"");
                textFromFile = textFromFile.Remove(0, 9 + startIndex);

                int endIndex;

                endIndex = textFromFile.IndexOf("{\"__type\"");
                if (endIndex == -1)
                {
                    endIndex = textFromFile.IndexOf("}]");
                    endIndex += 1;
                }
                else
                    endIndex -= 2;
                if (startIndex < 0)
                    return shapeList;

                string bufstr = "{\"__type\":" + textFromFile.Substring(startIndex, endIndex);
                textFromFile = textFromFile.Remove(0, endIndex + 1);
                startIndex = 0;
                endIndex = -1;


                string bufFile = "buff.json";
                File.WriteAllText(bufFile, bufstr);

                Type type = typeof(List<Shape>);
                try
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(Shape), settings);
                    using (FileStream fs = new FileStream(bufFile, FileMode.OpenOrCreate))
                    {
                        shapeList.Add((Shape)jsonFormatter.ReadObject(fs));
                    }
                }
                catch
                {

                }
                bufstr = String.Empty;
            }
            return shapeList;

            
        }

    }
}

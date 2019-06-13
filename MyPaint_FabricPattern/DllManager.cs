using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using ClassLibrary;

namespace MyPaint_FabricPattern
{
    class DllManager
    {
        String dirpass;
        public DllManager(String dirpass)
        {
            this.dirpass = dirpass;
        }
        public List<IShapeDll> LoadAll(List<Type> types)
        {
            
            String currentdir = Directory.GetCurrentDirectory();
            String[] dirs = Directory.GetFiles(dirpass);
            Assembly[] assemblies = new Assembly[dirs.Length];
            int i = 0;
            foreach (var dir in dirs)
            {
                //Console.Write(" " + dir);
                assemblies[i] = Assembly.LoadFile(currentdir + "\\" + dir);
                i++;
            }
            List<IShapeDll> dlls = new List<IShapeDll>();
            //types = new List<Type>();
            for (i = 0; i < assemblies.Length; i++)
            {
                var assemblyTypes = assemblies[i].GetTypes();
                for (int j = 0; j < assemblyTypes.Length; j++)
                {
                    if ((types.IndexOf(assemblyTypes[j]) == -1) && (assemblyTypes[j].ToString().StartsWith("ClassLibrary")) && (!assemblyTypes[j].ToString().Contains("I")) && (!assemblyTypes[j].ToString().Contains("Shape")))
                    {
                        var shape=(IShapeDll)(assemblies[i].CreateInstance(assemblyTypes[j].FullName));
                        if ( shape != null)
                        {
                            types.Add(assemblyTypes[j]);
                            dlls.Add(shape);
                        }
                    }
                }

            }
            //object obj = assemblies[3].CreateInstance(types.ElementAt(2).ToString());
            //Console.WriteLine(obj.GetType().ToString());
            return dlls;
        }
    }
}

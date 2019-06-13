using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DllManager dllManager = new DllManager("DLLS");
            dllManager.LoadAll();
            Console.ReadKey();
        }
    }
    class DllManager
    {
        String dirpass;
        public DllManager(String dirpass)
        {
            this.dirpass = dirpass;
        }
        public void LoadAll()
        {
            String currentdir = Directory.GetCurrentDirectory();
            String[] dirs = Directory.GetFiles(dirpass);
            Assembly[] assemblies = new Assembly[dirs.Length];
            int i = 0;
            foreach (var dir in dirs)
            {
                Console.Write(" " + dir);
                assemblies[i] = Assembly.LoadFile(currentdir + "\\" + dir);
                i++;
            }
            List<Type> types=new List<Type>();
            for (i = 0; i < assemblies.Length; i++)
            {
                var assemblyTypes = assemblies[i].GetTypes();
                for (int j=0; j < assemblyTypes.Length; j++)
                {
                    if ( (types.IndexOf(assemblyTypes[j]) == -1) && (assemblyTypes[j].ToString().StartsWith("ClassLibrary")) )
                    {
                        types.Add(assemblyTypes[j]);
                        Console.WriteLine(assemblyTypes[j].ToString());
                    }
                }

            }
            
            object obj =assemblies[3].CreateInstance(types.ElementAt(2).ToString());
            Console.WriteLine(obj.GetType().ToString());
            
        }
    }
}

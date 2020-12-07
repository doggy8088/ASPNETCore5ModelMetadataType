using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace EFCoreEntityPartialGenerator
{
    class Program
    {
        static string basePath = @"../../../../WebApplication4\bin\Debug\net5.0\";

        static void Main(string[] args)
        {
            basePath = Path.GetFullPath(basePath);

            var context = new AssemblyLoadContext("testContext", true);
            context.Resolving += Context_Resolving;

            var interfaceAssemblyPath = basePath + @"WebApplication4.dll";
            var interfaceAssembly = context.LoadFromAssemblyPath(interfaceAssemblyPath);

            foreach (var item in interfaceAssembly.GetTypes())
            {
                if (item.Name.StartsWith("<"))
                {
                    continue;
                }

                // Console.WriteLine(item.Name);
                Console.WriteLine(GetFullName(item));
            }

            context.Unload();

        }

        private static System.Reflection.Assembly Context_Resolving(AssemblyLoadContext context, System.Reflection.AssemblyName assemblyName)
        {
            var resolvePath1 = Path.Combine(@"C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App\5.0.0", assemblyName.Name + ".dll");
            var resolvePath2 = Path.Combine(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\5.0.0", assemblyName.Name + ".dll");
            var resolvePath3 = Path.Combine(basePath, assemblyName.Name + ".dll");

            if (File.Exists(resolvePath1))
            {
                return context.LoadFromAssemblyPath(resolvePath1);
            }

            if (File.Exists(resolvePath2))
            {
                return context.LoadFromAssemblyPath(resolvePath2);
            }
            
            return context.LoadFromAssemblyPath(resolvePath3);
        }

        private static string GetFullName(Type t)
        {
            if (!t.IsGenericType) return t.Name;

            StringBuilder sb = new StringBuilder();

            sb.Append(t.Name.Substring(0, t.Name.LastIndexOf("`")));
            sb.Append(t.GetGenericArguments().Aggregate("<",
                delegate (string aggregate, Type type) {
                    return aggregate + (aggregate == "<" ? "" : ",") + GetFullName(type);
                }));
            sb.Append(">");

            return sb.ToString();
        }
    }
}

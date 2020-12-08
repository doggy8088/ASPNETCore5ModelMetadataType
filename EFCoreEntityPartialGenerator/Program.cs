using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace EFCoreEntityPartialGenerator
{
    class Program
    {
        static string basePath = @"../../../../WebApplication4\bin\Debug\net5.0\";

        private static void PrintTypes(Assembly assembly)
        {
            foreach (TypeInfo type in assembly.GetTypes())
            {
                Console.WriteLine(type.Name);
                foreach (PropertyInfo property in type.DeclaredProperties)
                {
                    string attributes = string.Join(
                        ", ",
                        property.CustomAttributes.Select(a => a.AttributeType.Name));

                    if (!string.IsNullOrEmpty(attributes))
                    {
                        Console.WriteLine("    [{0}]", attributes);
                    }
                    Console.WriteLine("    {0} {1}", property.PropertyType.Name, property.Name);
                }
            }
        }
        static void Main(string[] args)
        {
            basePath = Path.GetFullPath(basePath);

            // Get the array of runtime assemblies.
            string[] runtimeAssemblies = Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll");

            // Create the list of assembly paths consisting of runtime assemblies and the inspected assembly.
            var paths = new List<string>(runtimeAssemblies);
            paths.Add(basePath + "WebApplication4.dll");

            // Create PathAssemblyResolver that can resolve assemblies using the created list.
            var resolver = new PathAssemblyResolver(paths);
            //var resolver = new PathAssemblyResolver(new string[] { basePath + @"WebApplication4.dll" });

            var mlc = new MetadataLoadContext(resolver);

            using (mlc)
            {
                Assembly assembly = mlc.LoadFromAssemblyPath(basePath + "WebApplication4.dll");
                AssemblyName name = assembly.GetName();

                foreach (var item in assembly.GetTypes())
                {
                    Console.WriteLine(item.Name + "--");
                }

            }



            using (var dynamicContext = new AssemblyResolver(@"C:\Users\wakau\source\repos\ASPNETCore5ModelMetadataType\WebApplication4\bin\Debug\net5.0\WebApplication4.dll"))
            {
                //PrintTypes(dynamicContext.Assembly);
            }

            return;


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
                delegate (string aggregate, Type type)
                {
                    return aggregate + (aggregate == "<" ? "" : ",") + GetFullName(type);
                }));
            sb.Append(">");

            return sb.ToString();
        }
    }
    internal sealed class AssemblyResolver : IDisposable
    {
        private readonly ICompilationAssemblyResolver assemblyResolver;
        private readonly DependencyContext dependencyContext;
        private readonly AssemblyLoadContext loadContext;

        public AssemblyResolver(string path)
        {
            this.Assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            this.dependencyContext = DependencyContext.Load(this.Assembly);

            this.assemblyResolver = new CompositeCompilationAssemblyResolver(new ICompilationAssemblyResolver[]
            {
                new AppBaseCompilationAssemblyResolver(Path.GetDirectoryName(path)),
                new ReferenceAssemblyPathResolver(),
                new PackageCompilationAssemblyResolver()
            });

            this.loadContext = AssemblyLoadContext.GetLoadContext(this.Assembly);
            this.loadContext.Resolving += OnResolving;
        }

        public Assembly Assembly { get; }

        public void Dispose()
        {
            this.loadContext.Resolving -= this.OnResolving;
        }

        private Assembly OnResolving(AssemblyLoadContext context, AssemblyName name)
        {
            bool NamesMatch(RuntimeLibrary runtime)
            {
                return string.Equals(runtime.Name, name.Name, StringComparison.OrdinalIgnoreCase);
            }

            RuntimeLibrary library =
                this.dependencyContext.RuntimeLibraries.FirstOrDefault(NamesMatch);
            if (library != null)
            {
                var wrapper = new CompilationLibrary(
                    library.Type,
                    library.Name,
                    library.Version,
                    library.Hash,
                    library.RuntimeAssemblyGroups.SelectMany(g => g.AssetPaths),
                    library.Dependencies,
                    library.Serviceable);

                var assemblies = new List<string>();
                this.assemblyResolver.TryResolveAssemblyPaths(wrapper, assemblies);
                if (assemblies.Count > 0)
                {
                    return this.loadContext.LoadFromAssemblyPath(assemblies[0]);
                }
            }

            return null;
        }
    }

}

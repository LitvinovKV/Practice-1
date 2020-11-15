using System;
using System.Linq;
using System.Reflection;

namespace Tools.Extensions
{
    public static class AssemblyExtensions
    {
        public static Type[] GetClassesByBaseClass<T>(this Assembly assembly) where T : class
            => assembly.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsAbstract
                        && type.IsSubclassOf(typeof(T)))
                .ToArray();
        
        public static Type[] GetClassesByBaseClass(this Assembly assembly, Type baseType)
            => assembly.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsAbstract
                        && type.IsSubclassOf(baseType))
                .ToArray();

        public static Type[] GetClassesByInterface<T>(this Assembly assembly) where T : class
            => assembly.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsInterface
                        && type.GetInterface(typeof(T).Name) != null)
                .ToArray();

        public static Type[] GetInterfacesImplementedBy<T>(this Assembly assembly) where T : class
            => assembly.GetTypes()
                .Where(type => type.IsInterface
                        && type.GetInterface(typeof(T).Name) != null)
                .ToArray();
    }
}

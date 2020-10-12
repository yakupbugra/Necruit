using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Necruit.Application.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(x => x.IsClass && !x.IsAbstract && (x.IsInheritedFrom(typeof(MapFrom<>)) || x.IsInheritedFrom(typeof(MapTo<>))))
                .ToList();

            var types2 = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.GetType() == typeof(IHaveCustomMappings)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("CreateMapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }

            foreach (var type in types2)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("CreateMapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }

    public static class Extension
    {
        public static bool IsInheritedFrom(this Type type, Type Lookup)
        {
            if (type.BaseType == null)
                return false;

            if (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == Lookup)
                return true;

            return type.BaseType.IsInheritedFrom(Lookup);
        }
    }
}
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
                .Where(x => x.IsClass
                && !x.IsAbstract && (x.IsInheritedFrom(typeof(MapFrom<>))
                || x.IsInheritedFrom(typeof(MapTo<>))
                || x.IsInheritedFrom(typeof(MapFromTo<,>))))
                .ToList();

            var types2 = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.GetTypeInfo() == typeof(IHaveCustomMappings)))
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
}
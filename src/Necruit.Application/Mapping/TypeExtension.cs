using System;

namespace Necruit.Application.Mapping
{
    public static class TypeExtension
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
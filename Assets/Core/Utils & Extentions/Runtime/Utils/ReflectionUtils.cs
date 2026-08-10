using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    public static class ReflectionUtils
    {
        public static readonly BindingFlags FLAGS_INSTANCE = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        public static readonly BindingFlags FLAGS_STATIC = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

        public static readonly BindingFlags FLAGS_INSTANCE_PRIVATE = BindingFlags.NonPublic | BindingFlags.Instance;
        public static readonly BindingFlags FLAGS_INSTANCE_PUBLIC = BindingFlags.Public | BindingFlags.Instance;

        public static readonly BindingFlags FLAGS_STATIC_PRIVATE = BindingFlags.NonPublic | BindingFlags.Static;
        public static readonly BindingFlags FLAGS_STATIC_PUBLIC = BindingFlags.Public | BindingFlags.Static;

        public static IEnumerable<Type> GetParentTypes(Type type)
        {
            yield return type;

            Type baseType = type.BaseType;
            while (baseType != null)
            {
                yield return baseType;

                baseType = baseType.BaseType;
            }
        }
    }
}
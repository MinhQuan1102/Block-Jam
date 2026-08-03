using System.Reflection;

namespace Core
{
    public static class ReflectionUtils
    {
        public static readonly BindingFlags FLAGS_STATIC = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

    }
}
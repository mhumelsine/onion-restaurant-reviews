using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Isf.XC
{
    public static class ReflectionExtensions
    {
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> cache = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        public static Dictionary<string, PropertyInfo> GetPropertyInfo(this object obj)
        {
            Type type = obj.GetType();

            Dictionary<string, PropertyInfo> info;

            if(!cache.TryGetValue(type, out info))
            {
                info = GetProperyLookup(type);
                cache[type] = info;
            }
            return info;
        }

        private static Dictionary<string, PropertyInfo> GetProperyLookup(Type type)
        {
            Dictionary<string, PropertyInfo> lookup = new Dictionary<string, PropertyInfo>();

            foreach(var prop in type.GetProperties())
            {
                lookup[prop.Name] = prop;
            }

            return lookup;
        }
    }
}

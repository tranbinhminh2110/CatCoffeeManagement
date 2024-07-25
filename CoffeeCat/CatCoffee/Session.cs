using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatCoffee
{
    public static class Session
    {
        private static Dictionary<string, object> sessionValues = new Dictionary<string, object>();

        public static void Set(string key, object value)
        {
            if (sessionValues.ContainsKey(key))
            {
                sessionValues[key] = value;
            }
            else
            {
                sessionValues.Add(key, value);
            }
        }

        public static object Get(string key)
        {
            if (sessionValues.ContainsKey(key))
            {
                return sessionValues[key];
            }
            return null;
        }

        public static void Remove(string key)
        {
            if (sessionValues.ContainsKey(key))
            {
                sessionValues.Remove(key);
            }
        }
        public static void Clear()
        {
            sessionValues.Clear();
        }
    }
}
using System;
using Monitor.Constants;

namespace Monitor.Services
{
    public static class ResourceProvider
    {
        public static string GetResource(string key)
        {
            if (key != String.Empty)
            {
                string value = String.Empty;
                ViewConstants.Resources.TryGetValue(key, out value);
                if (value == null || value == String.Empty)
                {
                    return $"[{key}]";
                }
                return value;
            }
            return "[Empty]";
        }
    }
}

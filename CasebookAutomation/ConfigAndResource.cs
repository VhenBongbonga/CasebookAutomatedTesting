using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CasebookAutomation
{
    public class ConfigAndResource
    {
        public static string GetResourceString(string resourceString)
        {
            string resourceStringValue = null;
            ResourceManager resourceManager = Resources.ResourceManager;

            resourceStringValue = resourceManager.GetString(resourceString);
            if (resourceStringValue == null)
                return resourceString;
            else
                return resourceStringValue;
        }
        public static string GetResourceFile(string resourcename)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            return Convert.ToString(resourceManager.GetObject(resourcename));
        }
        public static int GetResourceInt(string resourceString)
        {
            string val = GetResourceString(resourceString);
            if (!string.IsNullOrWhiteSpace(val))
            {
                return int.Parse(val);
            }

            return 0;
        }
    }
}

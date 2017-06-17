using System;
using System.Configuration;

namespace TrainerWebApi.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public string GetKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
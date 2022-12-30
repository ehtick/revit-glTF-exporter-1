﻿using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Autodesk.Internal.InfoCenter;
using Configuration = System.Configuration.Configuration;

namespace Common_glTF_Exporter.Utils
{
    /// <summary>
    /// SettingsConfig
    /// </summary>
    public static class SettingsConfig
    {
        private static readonly string BinaryLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string appSettingsName = string.Concat(Assembly.GetExecutingAssembly().GetName().Name, ".dll.config");
        private static string appSettingsFile = System.IO.Path.Combine(BinaryLocation, appSettingsName);

        public static string GetValue(string key)
        {
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = appSettingsName }, ConfigurationUserLevel.None);
            return configuration.AppSettings.Settings[key].Value;
        }

        public static void Set(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = appSettingsName }, ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

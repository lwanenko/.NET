using Note.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Helpers
{
    
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region SETTING CONSTANT

        private const string SettingsKey = "myKey";
        private static readonly string SettingsDefault = string.Empty;

        #endregion

        #region VAR 

        public static string Text
        {
            get 
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault,"textVal");
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value, "textVal");
            }
        }

        public static string HashPas 
        {
            get 
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set 
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static User User
        {
            get 
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        #endregion
    }
}
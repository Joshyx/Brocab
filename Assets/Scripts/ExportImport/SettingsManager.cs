using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Brocab.Utility;

namespace Brocab {
    public static class SettingsManager {
        public static Settings settings;

        public static void LoadSettings() {
            try {
                settings = SaveSystem.LoadSettings();
            } catch {
                Debug.LogError("Es gab einen Fehler beim einlesen der Datei. Die Einstellungen wurden auf die Standardwerte zurückgesetzt");
                LoadDefaultValues();
                SaveSettings();
			}
        }
        public static void SaveSettings() {
            SaveSystem.SaveSettings(settings);
		}

        public static void LoadDefaultValues() {
            settings.SetDarkMode(true);
            settings.SetLanguage(CultureInfo.CurrentUICulture);
		}
    }

    public class Settings {
        private bool darkMode;
        private CultureInfo language;

        public void SetDarkMode(bool darkMode) {
            this.darkMode = darkMode;
		}
        public void SetLanguage(CultureInfo culture) {
            this.language = culture;
        }
        public void SetLanguage(string culture) {
            this.language = LanguageHelper.GetCultureInfoFromString(culture);
		}
        public bool GetDarkMode() {
            return this.darkMode;
		}
        public CultureInfo GetLanguage() {
            return this.language;
		}
	}
    public class SaveableSettings {
        public bool darkMode;
        public string language;

        public Settings ToSettings() {
            Settings settings = new Settings();
            settings.SetDarkMode(this.darkMode);
            settings.SetLanguage(this.language);
            return settings;
		}

        public SaveableSettings(Settings settings) {
            this.darkMode = settings.GetDarkMode();
            this.language = settings.GetLanguage().TwoLetterISOLanguageName;
		}
    }
}
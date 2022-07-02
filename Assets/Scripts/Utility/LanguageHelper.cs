using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Brocab.Utility {
    public static class LanguageHelper {
        public static CultureInfo GetCultureInfoFromLanguageName(string langName) {
            foreach(CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
                if(cultureInfo.DisplayName.Equals(langName) || cultureInfo.Name.Equals(langName) || cultureInfo.NativeName.Equals(langName) || cultureInfo.EnglishName.Equals(langName)) {
                    return cultureInfo;
				}
            }
            throw new ArgumentException(langName + " is not a valid language name");
        }

        public static CultureInfo GetCultureInfoFromIsoCode(string isoCode) {
            return CultureInfo.CreateSpecificCulture(isoCode);
        }

        public static CultureInfo GetCultureInfoFromString(string s) {
            try {
                return GetCultureInfoFromLanguageName(s);
			} catch(ArgumentException) {
				try {
					return GetCultureInfoFromIsoCode(s);
				} catch {
                    throw new ArgumentException(s + " is not a valid language name");
                }
			}

        }

        public static CultureInfo GetUserLanguage() {
            return CultureInfo.CurrentCulture;
        }

        public static CultureInfo[] GetMostCommonLanguages() {
            return new CultureInfo[] {
                GetCultureInfoFromIsoCode("en"),    // Englisch
                GetCultureInfoFromIsoCode("de"),    // Deutsch
                GetCultureInfoFromIsoCode("fr"),    // Französisch
                GetCultureInfoFromIsoCode("es"),    // Spanisch
                GetCultureInfoFromIsoCode("zh-cn"), // Chinesisch
                GetCultureInfoFromIsoCode("ja"),    // Japanisch
                GetCultureInfoFromIsoCode("ar-ae"), // Arabisch
                GetCultureInfoFromIsoCode("hi"),    // Hindi
                GetCultureInfoFromIsoCode("pt"),    // Portugiesisch
                GetCultureInfoFromIsoCode("ru")     // Russisch
			};
		}
    }
}
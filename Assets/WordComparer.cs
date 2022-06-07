﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WordComparer {

	// Vergleicht zwei Strings und gibt Infos über die Unterscheide zurück
	public static ErrorInfo CheckSimiliarity(string correct, string actual, bool caseSensitive = false) {
		correct = correct.Trim();
		actual = actual.Trim();
		if (!caseSensitive) {
			correct = correct.ToLower();
			actual = actual.ToLower();
		}

		if (correct.Equals(actual)) {
			return new ErrorInfo(new int[] { }, ErrorInfo.ErrorType.CORRECT);
		} else if (correct.RemoveDiacritics() == actual.RemoveDiacritics()) {
			return new ErrorInfo(GetDifferences(correct, actual).ToArray(), ErrorInfo.ErrorType.WRONG_SPECIAL_CHARACTER);
		}

		List<int> differences = GetDifferences(correct, actual);
		if (differences.Count < ((correct.Length + 3) / 3)) {
			return new ErrorInfo(differences.ToArray(), ErrorInfo.ErrorType.DIFFERENT_SPELLING);
		}

		return new ErrorInfo(differences.ToArray(), ErrorInfo.ErrorType.WRONG);
	}

	// Vergleicht zwei Strings und gibt eine Liste aller Unterschiede zurück
	public static List<int> GetDifferences(string correct, string actual) {
		correct = correct.Trim();
		actual = actual.Trim();

		List<int> differences = new List<int>();

		if (correct == actual) {
			return differences;
		}

		if (correct.Length >= actual.Length) {
			for (int i = 0; i < correct.Length; i++) {
				char character = correct[i];

				if (actual.Length <= i) {
					differences.Add(i);
				} else if (character != actual[i]) {
					differences.Add(i);
				}
			}
		} else {
			for (int i = 0; i < actual.Length; i++) {
				char character = actual[i];

				if (correct.Length <= i) {
					differences.Add(i);
				} else if (character != correct[i]) {
					differences.Add(i);
				}
			}
		}

		return differences;
	}

	// Hier sind Infos über den Fehler, der gemacht wurde
	// Was für einer gemacht wurde und an welchen Stellen im Wort / Satz
	public class ErrorInfo {
		// Die Stellen der Fehler im Wort
		private readonly int[] errors;
		// Die Art des Fehlers
		private readonly ErrorType similiarity;

		public ErrorInfo(int[] errors, ErrorType similiarity) {
			this.errors = errors;
			this.similiarity = similiarity;
		}

		public int[] GetErrors() => this.errors;
		public ErrorType GetSimiliarity() => this.similiarity;

		public enum ErrorType {
			// Wort / Satz ist komplett falsch
			WRONG,
			// Wort / Satz ist komplett richtig
			CORRECT,
			// Es sind nur einzelne Rechtschreibfehler vorhanden
			DIFFERENT_SPELLING,
			// Nur Sonderzeichen wie Accents sind falsch (a anstatt ä und so)
			WRONG_SPECIAL_CHARACTER
		}
	}
}

// Hier werden Sonderzeichen in Normalzeichen konvertiert, also Ä -> A oder ê -> e
public static class CharNormalizer {
	static Dictionary<string, string> foreign_characters = new Dictionary<string, string> {
			{ "æǽ", "ae" },
			{ "œ", "oe" },
			{ "ÄÀÁÂÃÄÅǺĀĂĄǍΑΆẢẠẦẪẨẬẰẮẴẲẶА", "A" },
			{ "äàáâãåǻāăąǎªαάảạầấẫẩậằắẵẳặа", "a" },
			{ "Б", "B" },
			{ "б", "b" },
			{ "ÇĆĈĊČ", "C" },
			{ "çćĉċč", "c" },
			{ "Д", "D" },
			{ "д", "d" },
			{ "ÐĎĐΔ", "Dj" },
			{ "ðďđδ", "dj" },
			{ "ÈÉÊËĒĔĖĘĚΕΈẼẺẸỀẾỄỂỆЕЭ", "E" },
			{ "èéêëēĕėęěέεẽẻẹềếễểệеэ", "e" },
			{ "Ф", "F" },
			{ "ф", "f" },
			{ "ĜĞĠĢΓГҐ", "G" },
			{ "ĝğġģγгґ", "g" },
			{ "ĤĦ", "H" },
			{ "ĥħ", "h" },
			{ "ÌÍÎÏĨĪĬǏĮİΗΉΊΙΪỈỊИЫ", "I" },
			{ "ìíîïĩīĭǐįıηήίιϊỉịиыї", "i" },
			{ "Ĵ", "J" },
			{ "ĵ", "j" },
			{ "ĶΚК", "K" },
			{ "ķκк", "k" },
			{ "ĹĻĽĿŁΛЛ", "L" },
			{ "ĺļľŀłλл", "l" },
			{ "М", "M" },
			{ "м", "m" },
			{ "ÑŃŅŇΝН", "N" },
			{ "ñńņňŉνн", "n" },
			{ "ÖÒÓÔÕŌŎǑŐƠØǾΟΌΩΏỎỌỒỐỖỔỘỜỚỠỞỢО", "O" },
			{ "öòóôõōŏǒőơøǿºοόωώỏọồốỗổộờớỡởợо", "o" },
			{ "П", "P" },
			{ "п", "p" },
			{ "ŔŖŘΡР", "R" },
			{ "ŕŗřρр", "r" },
			{ "ŚŜŞȘŠΣС", "S" },
			{ "śŝşșšſσςс", "s" },
			{ "ȚŢŤŦτТ", "T" },
			{ "țţťŧт", "t" },
			{ "ÜÙÚÛŨŪŬŮŰŲƯǓǕǗǙǛŨỦỤỪỨỮỬỰУ", "U" },
			{ "üùúûũūŭůűųưǔǖǘǚǜυύϋủụừứữửựу", "u" },
			{ "ÝŸŶΥΎΫỲỸỶỴЙ", "Y" },
			{ "ýÿŷỳỹỷỵй", "y" },
			{ "В", "V" },
			{ "в", "v" },
			{ "Ŵ", "W" },
			{ "ŵ", "w" },
			{ "ŹŻŽΖЗ", "Z" },
			{ "źżžζз", "z" },
			{ "ÆǼ", "AE" },
			{ "ß", "ss" },
			{ "Ĳ", "IJ" },
			{ "ĳ", "ij" },
			{ "Œ", "OE" },
			{ "ƒ", "f" },
			{ "ξ", "ks" },
			{ "π", "p" },
			{ "β", "v" },
			{ "μ", "m" },
			{ "ψ", "ps" },
			{ "Ё", "Yo" },
			{ "ё", "yo" },
			{ "Є", "Ye" },
			{ "є", "ye" },
			{ "Ї", "Yi" },
			{ "Ж", "Zh" },
			{ "ж", "zh" },
			{ "Х", "Kh" },
			{ "х", "kh" },
			{ "Ц", "Ts" },
			{ "ц", "ts" },
			{ "Ч", "Ch" },
			{ "ч", "ch" },
			{ "Ш", "Sh" },
			{ "ш", "sh" },
			{ "Щ", "Shch" },
			{ "щ", "shch" },
			{ "ЪъЬь", "b" },
			{ "Ю", "Yu" },
			{ "ю", "yu" },
			{ "Я", "Ya" },
			{ "я", "ya" },
		};

	public static char RemoveDiacritics(this char c) {
		foreach (KeyValuePair<string, string> entry in foreign_characters) {
			if (entry.Key.IndexOf(c) != -1) {
				return entry.Value[0];
			}
		}
		return c;
	}

	public static string RemoveDiacritics(this string s) {
		//StringBuilder sb = new StringBuilder ();
		string text = "";


		foreach (char c in s) {
			int len = text.Length;

			foreach (KeyValuePair<string, string> entry in foreign_characters) {
				if (entry.Key.IndexOf(c) != -1) {
					text += entry.Value;
					break;
				}
			}

			if (len == text.Length) {
				text += c;
			}
		}
		return text;
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brocab {
	/*
	Eine Klasse, um aus Quizlet exportierte Lernsets in Brocab zu importieren
	*/
	public static class QuizletTextImporter {

		/*
		Liest ein exportiertes Quizlet-Lernset (quizletText) ein und
		erstellt eine neue VocabList mit dem Namen listDisplayName bzw dem ID Namen listIdName
		
		So sieht die exportierte Liste aus:

		<wort>TAB<übersetzung>
		<wort>TAB<übersetzung>
		<wort>TAB<übersetzung>
		...
		*/
		public static VocabList QuizletTextToVocabList(string quizletText, string listDisplayName, string listIdName) {

			VocabList result = new VocabList(listDisplayName, listIdName);

			// Geht durch jede Zeile line im exportierten Text
			foreach (string line in quizletText.Split("\r\n")) {

				// Teilt die Zeile in tokens auf, indem es an den TABs teilt
				string[] tokens = line.Split("	");

				// Wenn die Zeile nicht richtig formatiert ist, wird sie ignoriert
				if (tokens.Length < 2) {
					continue;
				}

				// Das Wort und die Übersetzung werden herausgenommen
				string word = tokens[0];
				string vocab = tokens[1];

				// und als neues Wort zur Liste hinzugefügt
				result.AddWord(new Word(word, vocab));
			}

			return result;
		}

		// Wenn keine Namen angegeben: DisplayName wird zu "Imported List" und IDName wird zu "imported_list_" + Uhrzeit,
		// zB "imported_list_2022.24.06.17.53.32.54"
		public static VocabList QuizletTextToVocabList(string quizletText) => QuizletTextToVocabList(quizletText, "Imported List", "imported_list_" + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.ff"));
		// Wenn nur ein DisplayName angegeben ist, wird der IDName gleich wie der DisplayName nur mit Kleinbuchstaben und mit Unterstrich anstatt Leerzeichen
		public static VocabList QuizletTextToVocabList(string quizletText, string listDisplayName) => QuizletTextToVocabList(quizletText, listDisplayName, listDisplayName.Replace(" ", "_").ToLower());
	}
}
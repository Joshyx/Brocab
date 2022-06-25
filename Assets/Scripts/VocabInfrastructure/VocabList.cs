using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Brocab {
	/*
	Eine Liste von Vokabeln, eine Lektion
	*/
	[System.Serializable]
	public class VocabList {
		//Der interne ID-Name der Liste
		//Bleibt immer gleich und ist einmalig
		public readonly string idName;
		//Der Anzeigename der Liste
		//Ist veränderbar und kann es mehrmals geben
		public string displayName;
		// Die ursprüngliche Sprache der Vokabeln
		// Sprachecode in ISO 639-1, zB Deutsch = de, Englisch = en, Amerikanisches Englisch = en-us	(https://www.andiamo.co.uk/resources/iso-language-codes/)
		public string originLanguage;
		// Die Sprache, in die übersetzt werden muss
		// Sprachcode in ISO 639-1
		public string translatedLanguage;
		//Die Liste von Vokabeln
		public List<Word> list = new List<Word>();

		public VocabList(string displayName) {
			this.displayName = displayName;
			this.idName = displayName.ToLower().Replace(" ", "_");
			this.originLanguage = "de";
			this.translatedLanguage = "en";
		}
		public VocabList(string displayName, string idName) {
			this.displayName = displayName;
			this.idName = idName;
			this.originLanguage = "de";
			this.translatedLanguage = "en";
		}
		public VocabList(string displayName, string originLanguage, string translatedLanguage) {
			this.displayName = displayName;
			this.idName = displayName.ToLower().Replace(" ", "_");
			this.originLanguage = originLanguage;
			this.translatedLanguage = translatedLanguage;
		}
		public VocabList(string displayName, string idName, string originLanguage, string translatedLanguage) {
			this.idName = idName;
			this.displayName = displayName;
			this.originLanguage = originLanguage;
			this.translatedLanguage = translatedLanguage;
		}
		[JsonConstructor]
		public VocabList(string displayName, string idName, string originLanguage, string translatedLanguage, List<Word> list) {
			this.idName = idName;
			this.displayName = displayName;
			this.originLanguage = originLanguage;
			this.translatedLanguage = translatedLanguage;
			this.list = list;
		}

		//Gibt die passende Vokabel anhand des passenden Wortes
		public Word GetWord(string wordName) {
			foreach (Word currentWord in list) {
				if (currentWord.GetWord().Equals(wordName)) {
					return currentWord;
				}
			}

			throw new WordNotFoundException("The word " + wordName + " does not exist");
		}

		//Fügt eine neue Vokabel zur Liste hinzu
		public void AddWord(Word word) {
			if (ContainsWord(word.GetWord())) {
				throw new WordAlreadyExistsException("The word " + word.GetWord() + " is already in this list");
			}

			this.list.Add(word);
		}

		public void SetDisplayName(string name) {
			this.displayName = name;
		}
		public string GetDisplayName() => this.displayName;
		public string GetIdName() => this.idName;
		

		//Schaut, ob ein Wort schon in der Liste enthalten ist
		public bool ContainsWord(string word) {
			foreach (Word currentWord in this.list) {
				if (currentWord.GetWord().Equals(word)) {
					return true;
				}
			}
			return false;
		}

		public override string ToString() {
			return JsonConvert.SerializeObject(this);
		}
		public override bool Equals(object obj) {
			if (this == obj) return true;
			if (obj == null || obj.GetType() != obj.GetType()) return false;
			VocabList vocabList = (VocabList)obj;
			return GetIdName() != vocabList.GetIdName() || GetDisplayName() != vocabList.GetDisplayName() || this.list != vocabList.list;
		}
		public override int GetHashCode() {
			return base.GetHashCode();
		}
	}

	public class WordNotFoundException : Exception {
		public WordNotFoundException(string e) { }
	}
	public class WordAlreadyExistsException : Exception {
		public WordAlreadyExistsException(string e) { }
	}
}
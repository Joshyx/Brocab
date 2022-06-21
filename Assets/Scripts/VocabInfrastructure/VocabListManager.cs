using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Brocab {
	/*
	Hier werden alle Vokabellisten gespeichert
	*/
	public class VocabListManager {

		//Die Liste an Vokabellisten
		private static List<VocabList> vocabLists = new List<VocabList>();

		//Eine neue Liste hinzufügen
		public static void AddList(VocabList list) {
			if (ContainsVocabList(list.GetIdName())) {
				throw new ListAlreadyExistsException("The list " + list.GetDisplayName() + " already exists");
			}
			vocabLists.Add(list);
		}
		//Eine Liste anhand des ID-Namens bekmmen
		public static VocabList GetList(string listName) {
			foreach (VocabList list in vocabLists) {
				if (list.idName.Equals(listName)) {
					return list;
				}
			}
			throw new ListNotFoundException("The list " + listName + " doesn't exist");
		}
		//Gibt an, ob eine Liste überhaupt existiert
		public static bool ContainsVocabList(string listName) {
			foreach (VocabList list in vocabLists) {
				if (list.idName.Equals(listName)) {
					return true;
				}
			}
			return false;
		}

		//Speichert alle Listen in Dateien
		public static void SaveLists() {
			SaveSystem.SaveAllLists(vocabLists);
		}
		//Lädt alle Listen aus Dateien
		public static void LoadLists() {
			vocabLists = SaveSystem.LoadAllLists();
		}
	}

	public class ListNotFoundException : Exception {
		public ListNotFoundException(string message) : base(message) { }
	}
	public class ListAlreadyExistsException : Exception {
		public ListAlreadyExistsException(string message) : base(message) { }
	}
}
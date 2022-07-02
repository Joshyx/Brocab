using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace Brocab {
	/*
	Hier werden alle Vokabeln gespeichert
	*/
	public static class SaveSystem {
		// Der Ordner, wo alle Vokablellisten gespeichert werden
		// C:\Users\<Benutzer>\AppData\LocalLow\<Entwicklername>\Brocab
		private static string vocabListFolder = Application.persistentDataPath + "/VocabLists";
		private static string settingsFilePath = Application.persistentDataPath + "/settings.brc";

		// Speichert eine Vokabelliste in einer Datei
		public static void SaveListToFile(VocabList list) {
			string json = JsonConvert.SerializeObject(list, Formatting.Indented);

			if (!Directory.Exists(vocabListFolder)) {
				Directory.CreateDirectory(vocabListFolder);
			}
			File.WriteAllText(vocabListFolder + "/" + list.idName + ".json", json);
		}
		// Lädt eine Vokabelliste von einer Datei
		public static VocabList LoadListFromFile(string listName) {
			string json = File.ReadAllText(vocabListFolder + "/" + listName + ".json");
			return JsonConvert.DeserializeObject<VocabList>(json);
		}

		// Speichert alle Vocabellisten ab
		public static void SaveAllLists(List<VocabList> vocabLists) {
			foreach (VocabList list in vocabLists) {
				SaveListToFile(list);
			}
		}
		// Lädt alle Vokabellisten
		public static List<VocabList> LoadAllLists() {
			List<VocabList> vocabLists = new List<VocabList>();

			// Ein Array mit allen Dateipfaden der Vokabellisten
			string[] fileNames = Directory.GetFileSystemEntries(vocabListFolder, "*.json", SearchOption.TopDirectoryOnly);
			// Lädt jede Liste aus ihrer Datei
			foreach (string fileName in fileNames) {
				vocabLists.Add(LoadListFromFile(fileName.TrimEnd(".json".ToCharArray()).TrimStart((vocabListFolder + "/").ToCharArray())));
			}

			return vocabLists;
		}



		public static Settings LoadSettings() {
			if (File.Exists(settingsFilePath)) {
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(settingsFilePath, FileMode.Open);

				SaveableSettings settings = formatter.Deserialize(stream) as SaveableSettings;
				stream.Close();
				return settings.ToSettings();
			} else {
				throw new FileNotFoundException("Settings File not found in " + settingsFilePath);
			}
		}
		public static void SaveSettings(Settings settings) {
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(settingsFilePath, FileMode.Create);

			formatter.Serialize(stream, new SaveableSettings(settings));
			stream.Close();
		}
	}
}
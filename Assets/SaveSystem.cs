using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

/*
Hier werden alle Vokabeln gespeichert
*/
public static class SaveSystem {
	//Der Ordner, wo alle Vokablellisten gespeichert werden
	//C:\Users\<Benutzer>\AppData\LocalLow\<Entwicklername>\Brocab
	private static string vocabListFolder = Application.persistentDataPath + "/VocabLists";

	//Speichert eine Vokabelliste in einer Datei
	public static void SaveListToFile(VocabList list) {
		string json = JsonConvert.SerializeObject(list, Formatting.Indented);

		if (!Directory.Exists(vocabListFolder)) {
			Directory.CreateDirectory(vocabListFolder);
		}
		/*
        if(!File.Exists(vocabListFolder + "/" + list.idName + ".json")) {
            File.Create(vocabListFolder + "/" + list.idName + ".json");
        }*/
		File.WriteAllText(vocabListFolder + "/" + list.idName + ".json", json);
	}
	//Lädt eine Vokabelliste von einer Datei
	public static VocabList LoadListFromFile(string listName) {
		string json = File.ReadAllText(vocabListFolder + "/" + listName + ".json");
		return JsonConvert.DeserializeObject<VocabList>(json);
	}

	public static void SaveAllLists(List<VocabList> vocabLists) {
		foreach (VocabList list in vocabLists) {
			SaveListToFile(list);
		}
	}
	public static List<VocabList> LoadAllLists() {
		List<VocabList> vocabLists = new List<VocabList>();

		string[] fileNames = Directory.GetFileSystemEntries(vocabListFolder, "*.json", SearchOption.TopDirectoryOnly);
		foreach (string fileName in fileNames) {
			vocabLists.Add(LoadListFromFile(fileName.TrimEnd(".json".ToCharArray()).TrimStart((vocabListFolder + "/").ToCharArray())));
		}

		return vocabLists;
	}
}

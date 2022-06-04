using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

/*
Hier werden alle Vokabeln gespeichert
*/
public class SaveSystem {
    //Der Ordner, wo alle Vokablellisten gespeichert werden
    //C:\Users\<Benutzer>\AppData\LocalLow\<Entwicklername>\Brocab
    private static string vocabListFolder = Application.persistentDataPath + "/vocabLists";
    //Die Datei, in der alle Vokabellisten ausfgelistet sind
    private static string vocabListInfoFile = Application.persistentDataPath + "/vocabListsInfo.json";

    //Speichert eine Vokabelliste in einer Datei
    public static void SaveListToFile(VocabList list) {
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);
        File.WriteAllText(vocabListFolder + "/" + list.idName + ".json", json);
    }
    //Lädt eine Vokabelliste von einer Datei
    public static VocabList LoadListFromFile(string listName) {
        string json = File.ReadAllText(vocabListFolder + "/" + listName + ".json");
        return JsonConvert.DeserializeObject<VocabList>(json);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/*
Eine Klasse, die nur zum Testen da ist.
Später werd ich sie löschen
*/
public class VocabTester : MonoBehaviour
{
    void Start() {
        /*
        VocabList list1 = new VocabList("lol", "LöL");
        list1.AddWord(new Word("trrfgd", "o,jmhojnmb"));

        VocabList list2 = new VocabList("englisch_unit_4", "Englisch Unit 4");
        list2.AddWord(new Word("Hallo", "hello"));
        list2.AddWord(new Word("Frühstück", "breakfast"));
        list2.AddWord(new Word("Morgen", "morning"));

        VocabList list3 = new VocabList("Franz Unit 3 Part 1");
        list3.AddWord(new Word("Guten Tag", "bonjour"));
        list3.AddWord(new Word("Freund", "ami"));

        VocabListManager.AddList(list1);
        VocabListManager.AddList(list2);
        VocabListManager.AddList(list3);

        VocabListManager.SaveLists();
        */
        VocabListManager.LoadLists();
        Debug.Log(JsonConvert.SerializeObject(VocabListManager.GetList("englisch_unit_4"), Formatting.Indented));
    }
}

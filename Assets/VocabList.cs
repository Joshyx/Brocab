using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    //Die Liste von Vokabeln
    public List<Word> list = new List<Word>();

    public VocabList(string idName, string displayName) {
        this.idName = idName;
        this.displayName = displayName;
    }
    public VocabList(string idName) {
        this.idName = idName;
        this.displayName = idName.ToUpper();
    }

    //Gibt die passende Vokabel anhand des passenden Wortes
    public Word GetWord(string wordName) {
        foreach(Word currentWord in list) {
            if(currentWord.GetWord().Equals(wordName)) {
                return currentWord;
            }
        }

        throw new WordNotFoundException("The word " + wordName + " does not exist");
    }

    //Fügt eine neue Vokabel zur Liste hinzu
    public void AddWord(Word word) {
        if(ContainsWord(word.GetWord())) {
            throw new WordAlreadyExistsException("The word " + word.GetWord() + " is already in this list");
        }

        this.list.Add(word);
    }

    public void SetDisplayName(string name) {
        this.displayName = name;
    }
    public string GetDisplayName() {
        return this.displayName;
    }
    public string GetIdName() {
        return this.idName;
    }

    //Schaut, ob ein Wort schon in der Liste enthalten ist
    public bool ContainsWord(string word) {
        foreach(Word currentWord in this.list) {
            if(currentWord.GetWord().Equals(word)) {
                return true;
            }
        }
        return false;
    }
}

public class WordNotFoundException : Exception {
    public WordNotFoundException(string e) {}
}
public class WordAlreadyExistsException : Exception {
    public WordAlreadyExistsException(string e) {}
}
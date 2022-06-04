using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Eine einzelne Vokabel
*/
[System.Serializable]
public class Word {
    //Das ursprüngliche Wort
    public string word;
    //Die passende Übersetzung
    public string translation;

    public Word(string word, string translation) {
        this.word = word;
        this.translation = translation;
    }

    public string GetWord() {
        return this.word;
    }
    public string GetTranslation() {
        return this.translation;
    }

    //Hier wird geschaut, ob die eingegebene Übersetzung richtig ist
    //TODO: Bessere Vergleiche mit Feedback einfügen
    bool IsCorrectTranslation(string translation) {
        return translation.ToLower().Equals(this.translation.ToLower());
    }
}

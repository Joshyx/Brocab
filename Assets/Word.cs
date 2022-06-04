using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word {
    private string word;
    private string translation;

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

    bool IsCorrectTranslation(string translation) {
        return translation.ToLower().Equals(this.translation.ToLower());
    }
}

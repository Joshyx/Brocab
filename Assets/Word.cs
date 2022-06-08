using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Eine einzelne Vokabel
*/
[System.Serializable]
public class Word {
	// Wie oft man eine Vokabel wiederholen muss, bis man sie beherrscht
	public static int MIN_TIMES_TO_REVISE = 5;

	//Das ursprüngliche Wort
	public string word;
	//Die passende Übersetzung
	public string translation;
	//Wie oft der Nutzer diese Vokabel schon richtig übersetzt hat
	public int timesRevised = 0;

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
	public int GetTimesRevised() {
		return this.timesRevised;
	}
	//Wird aufgerufen, sobald der Nutzer die Vokabel richtig übersetzt hat
	//Gibt true zurück, wenn er die Vokabel perfekt beherrscht
	public bool Revise() {
		timesRevised++;

		return this.GetTimesRevised() >= MIN_TIMES_TO_REVISE;
	}

	//Hier wird geschaut, ob die eingegebene Übersetzung richtig ist
	//TODO: Bessere Vergleiche mit Feedback einfügen
	public bool IsCorrectTranslation(string translation) {
		return translation.ToLower().Equals(this.translation.ToLower());
	}
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

/*
Eine Klasse, die nur zum Testen da ist.
Später werd ich sie löschen
*/
public class VocabTester : MonoBehaviour {
	void Start() {
		

		// Du kannst mal an den Variablen ein bisschen rumprobieren, also sie ändern, dann Unity starten und schauen, was rauskommt
		// correct ist das Wort, was gewollt ist und actual ist das Wort, was dann eingegeben wurde
		string correct = "Hello";
		string actual = "Hallo";

		SceneManager.LoadScene(1);

		WordComparer.ErrorInfo info = WordComparer.CheckSimiliarity(correct, actual);

		if (info.GetSimiliarity() == WordComparer.ErrorInfo.ErrorType.CORRECT) {
			Debug.Log("RICHTIG");
		} else if (info.GetSimiliarity() == WordComparer.ErrorInfo.ErrorType.WRONG_SPECIAL_CHARACTER) {
			Debug.Log("FALSCHES ZEICHEN:");
			foreach (int i in info.GetErrors()) {
				Debug.Log(actual[i] + " (richtig: " + correct[i] + ")");
			}
		} else if (info.GetSimiliarity() == WordComparer.ErrorInfo.ErrorType.DIFFERENT_SPELLING) {
			Debug.Log("FALSCHE Rechtshcreibung:");
			foreach (int i in info.GetErrors()) {
				Debug.Log(actual[i] + " (richtig: " + correct[i] + ")");
			}
		} else if (info.GetSimiliarity() == WordComparer.ErrorInfo.ErrorType.WRONG) {
			Debug.Log("GAAANZ Falsch:");
			Debug.Log(actual + " (richtig: " + correct + ")");
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Brocab.Utility;

/*
Eine Klasse, die nur zum Testen da ist.
Später werd ich sie löschen
*/
public class VocabTester : MonoBehaviour {

	void Start() {

		foreach(CultureInfo lang in LanguageHelper.GetMostCommonLanguages()) {
			Debug.Log(lang.NativeName);
		}
	}
}

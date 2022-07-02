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

		Debug.Log(LanguageHelper.GetCultureInfoFromIsoCode("cvbnfgdh"));
	}
}

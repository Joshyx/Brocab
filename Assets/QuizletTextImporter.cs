using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuizletTextImporter {

	public static VocabList QuizletTextToVocabList(string quizletText, string listDisplayName, string listIdName) {

		VocabList result = new VocabList(listDisplayName, listIdName);
		foreach(string line in quizletText.Split("\r\n")) {

			string[] tokens = line.Split("	");

			if(tokens.Length < 2) {
				continue;
			}

			string word = tokens[0];
			string vocab = tokens[1];

			result.AddWord(new Word(word, vocab));
		}

		return result;
	}

	public static VocabList QuizletTextToVocabList(string quizletText) => QuizletTextToVocabList(quizletText, "Imported List", "imported_list_" + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.ff"));
	public static VocabList QuizletTextToVocabList(string quizletText, string listDisplayName) => QuizletTextToVocabList(quizletText, listDisplayName, listDisplayName.Replace(" ", "_").ToLower());
}

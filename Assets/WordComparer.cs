using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WordComparer {
    public static Similiarity CheckSimiliarity(string first, string second, bool caseSensitive = false) {
        if(!caseSensitive) {
            first = first.ToLower();
            second = second.ToLower();
        }

        if (first.Equals(second)) {
            return Similiarity.EQUAL;
        }


        

        return Similiarity.NONE;
    }

    public static List<int> GetDifferences(string first, string second) {
        List<int> differences = new List<int>();

        if (first.Equals(second)) return differences;

        if(first.Length > second.Length) {
            string temp = second;
            second = first;
            first = second;
        }

        for(int i = 0; i < first.Length; i++) {
            char firstChar = first.ToCharArray()[i];
            char secondChar = second.ToCharArray()[i];

            if(firstChar != secondChar) {
                differences.Add(i);
            }
        }

        differences.Sort();
        return differences;
    }

    public enum Similiarity {
        NONE,
        EQUAL,
        DIFFERENT_SPELLING,
        WRONG_SPECIAL_CHARACTER,
        DIFFERENT_SPELLING_AND_WRONG_SPECIAL_CHARACTER
    }
}

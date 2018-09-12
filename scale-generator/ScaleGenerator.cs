using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class ScaleGenerator
{
    public static string[] Pitches(string tonic)
    {
        return Pitches(tonic, "mmmmmmmmmmmm");
    }

    public static string[] Pitches(string tonic, string pattern)
    {
        //intervals are m = minor second, which steps to the next note
        //              M = major second, which steps to the second next note
       //               A = augmented second, which steps the the third next note
        Dictionary<char, int> intervals = new Dictionary<char, int>
        {
            {'m', 1 },
            {'M', 2 },
            {'A', 3 }
        };

        //these are the naturals (no sharps or flats) that have scales with flats when used as tonics
        string[] naturalTonicsUSingFlats = new string[]
        {
            "c", "d", "f", "F", "g"
        };

        //all notes, using sharp notation
        string[] notesWithSharps = new string[]
        {
            "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"
        };

        //all notes, using flat notation
        string[] notesWithFlats = new string[]
        {
            "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab"
        };


        //select which array of notes to use - sharps or flats
        bool tonicHasFlat = tonic.Substring(1) == "b";
        bool tonicIsNaturalUsingFlats = naturalTonicsUSingFlats.Contains(tonic);
        string[] notesToUse = (tonicHasFlat || tonicIsNaturalUsingFlats)  ? notesWithFlats : notesWithSharps;

        //find index of starting note in array of notes to use
        int noteIndex = Array.IndexOf(notesToUse, notesToUse.Single(s => s.ToLower() == tonic.ToLower()));

        //add first note to results
        List<string> results = new List<string> { notesToUse[noteIndex] };

        //use each interval in the pattern to choose next note to add to results
        for (int i = 0; i < pattern.Length; i++)
        {
            //incread note index by interval associated with character from the pattern
            noteIndex += intervals[pattern[i]];

            //loop back to beginning of notes if needed
            if (noteIndex > notesToUse.Length - 1) noteIndex -= notesToUse.Length;

            //add note to results
            results.Add(notesToUse[noteIndex]);
        }

        //check that the interval to the last note gave the same note started with - remove that note from the results
        if (results.First() == results.Last()) return results.Take(results.Count - 1).ToArray();
        else throw new ArgumentException("Invalid pattern.");
    }
}


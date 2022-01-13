//Madison Dunnavant
using System;
using System.Collections.Generic;


namespace UniqueWordAbbreviationExercise
{
    public class UniqueWordAbbreviation
    {
        //Created Hashset and Dictionary
        HashSet<string> dict = new HashSet<string>();
        Dictionary<string, int> abbreviations = new Dictionary<string, int>();


        public UniqueWordAbbreviation(string[] dictionary)
        {
            dict.UnionWith(dictionary);
            foreach (var tempo in dict)
            {
                var abbr = GetAbbreviation(tempo);
                if (!abbreviations.ContainsKey(abbr))
                    abbreviations[abbr] = 1;
                else
                    abbreviations[abbr]++;
            }
        }
        //Checks if values in abbreviations are unique
        public bool IsAbbreviationUnique(string input)
        {
            int temp;
            abbreviations.TryGetValue(GetAbbreviation(input), out temp);
            return temp == (dict.Contains(input) ? 1 : 0);

        }
        //Creates the unique abbreviation 
        public string GetAbbreviation(string wordEntered)
        {
            if (wordEntered.Length < -2)
                return wordEntered;
            else
            {
                return wordEntered[0] + (wordEntered.Length - 2).ToString() + wordEntered[wordEntered.Length - 1];
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            string wordEntered;
            string wordAbbreviation;
            bool isUniqueAbbrev;
            string[] dictionary = { "innoculation", "fiction", "gone", "game", "samson", "forest", "season", "at", "initialization" };

            Console.WriteLine("Please enter a word: ");
            wordEntered = Console.ReadLine().ToLower();

            UniqueWordAbbreviation abbreviations = new UniqueWordAbbreviation(dictionary);

            wordAbbreviation = abbreviations.GetAbbreviation(wordEntered);
            Console.WriteLine("Abbreviation of word entered: " + wordAbbreviation);

            isUniqueAbbrev = abbreviations.IsAbbreviationUnique(wordEntered);
            Console.WriteLine("Value is unique: " + isUniqueAbbrev);


        }

    }
}




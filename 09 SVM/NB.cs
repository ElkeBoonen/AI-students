using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _09_NB
{
    public class NB
    {
        private Dictionary<string, int> _ham = new Dictionary<string, int>();
        private Dictionary<string, int> _spam = new Dictionary<string, int>();

        private double _spamCount;
        private double _hamCount;

        private double _pspam;
        private double _pham;

        private IStemmer stemmer = new EnglishStemmer();

        private void AddWords(string[] words, bool spam)
        {
            foreach (var item in words)
            {
                string word = stemmer.Stem(item);

                if (spam)
                {
                    if (_spam.ContainsKey(word)) _spam[word]++;
                    else _spam[word] = 1;
                }
                else
                {
                    if (_ham.ContainsKey(word)) _ham[word]++;
                    else _ham[word] = 1;
                }
            }
        }

        private void LoadData()
        {
            StreamReader input = File.OpenText("data.txt");
            while (!input.EndOfStream)
            {
                string[] line = input.ReadLine().Split(',');
                if (line.Length == 2)
                {
                    Regex rgx = new Regex(@"[^a-z ]");
                    string text = rgx.Replace(line[1].ToLower(), "");

                    string[] words = text.Split(' ');
                    if (line[0] == "spam")
                    {
                        AddWords(words, true);
                        _spamCount++;
                    }
                    else 
                    {
                        AddWords(words, false);
                        _hamCount++;
                    }
                }
            }
            input.Close();

            _pspam = _spamCount / (_spamCount+_hamCount);
            _pham = _hamCount / (_spamCount + _hamCount);
        }


        public NB()
        {
            LoadData();
        }

        public bool CheckIfSpam(string text)
        {
            string[] array = text.ToLower().Split(' ');

            double P = 1;

            foreach (var item in array)
            {
                P *= CalculatePWord(item);          
            }

            P *= (_pspam / _pham);

            if (P >= 1) return true;
            else return false;

        }

        private double CalculatePWord(string word)
        {
            double spam = 1;
            if (_spam.ContainsKey(word)) spam = _spam[word] / _spamCount;

            double ham = 1;
            if (_ham.ContainsKey(word)) ham = _ham[word] / _hamCount;
       
            return spam/ham;
        }

    }
}

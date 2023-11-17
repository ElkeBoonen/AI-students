using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace DSPS
{
    class NB
    {
        Dictionary<string, int> spamWords = new Dictionary<string, int>();
        Dictionary<string, int> hamWords = new Dictionary<string, int>();
        int totalSpam = 0;
        int totalHam = 0;
        int total = 0;

        public NB(string file)
        {
            GetData(file);
        }

        private void GetData(string file)
        {
            foreach (string line in File.ReadAllLines(file))
            {
                Regex regex = new Regex("[^a-z ]");
                string[] words = regex.Split(line.ToLower());
                total++;
                if (words[0].Trim() == "ham")
                {
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (!hamWords.ContainsKey(words[i])) hamWords[words[i]] = 0;
                        hamWords[words[i]]++;
                    }
                    totalHam++;
                }
                else
                {
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (!spamWords.ContainsKey(words[i])) spamWords[words[i]] = 0;
                        spamWords[words[i]]++;
                    }
                    totalSpam++;
                }
            }
        }
       
        
        public double Predict(string sentence) //prediction of spam
        {
            Regex regex = new Regex("[^a-z ]");
            string[] words = regex.Split(sentence.ToLower());

            double prediction = 1;

            double upper = 1;
            double lower = 1;

            foreach (var word in words)
            {
                if (spamWords.ContainsKey(word)) upper *= (double) spamWords[word] / (double) spamWords.Count();
                if (hamWords.ContainsKey(word)) lower *= (double) hamWords[word] / (double) hamWords.Count();
            }

            upper *= (double) totalSpam / (double) total;
            lower *= (double) totalHam / (double) total;

            prediction = upper/lower;
            return prediction;
        }

        public bool IsSpam(string sentence)
        {
            if (Predict(sentence) > 1) return true;
            return false;
        }
    }
}

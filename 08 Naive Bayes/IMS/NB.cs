using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMS
{
    internal class NB
    {

        private Dictionary<string, int> spamWords = new Dictionary<string, int>();
        private Dictionary<string, int> hamWords = new Dictionary<string, int>();
        private int spamTotal, hamTotal, total = 0;


        //Read in each line and put it in a dictionary with wordcount
        //ount your spam/ham messages and your total, calculate the P(spam) and P(ham)
        //Then read in a sentence and determine the spam factor based on the formula!
        //formule = P(w1|spam)*P(w2|spam)*...*P(spam) / P(w1|ham)*P(w2|ham)*...*P(ham)

        public NB(string file)
        {
            GetData(file);
        }

        private void GetData(string file)
        {
            foreach (string line in File.ReadAllLines(file))
            {
                Regex regex = new Regex("[^a-z]");
                string[] words = regex.Split(line.ToLower());

                total++;
                if (words[0] == "ham")
                {
                    hamTotal++;
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (!hamWords.ContainsKey(words[i])) hamWords[words[i]] = 0;
                        hamWords[words[i]]++;
                    }
                }
                else
                {
                    spamTotal++;
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (!spamWords.ContainsKey(words[i])) spamWords[words[i]] = 0;
                        spamWords[words[i]]++;
                    }
                
                }
            }
        }

        public string Predict(string v)
        {
            Regex regex = new Regex("[^a-z]");
            string[] words = regex.Split(v.ToLower());

            double P = 1;

            foreach (var item in words)
            {
                
                if (spamWords.ContainsKey(item)) P *= (double) spamWords[item] / spamTotal; ;
                if (hamWords.ContainsKey(item)) P /= (double) hamWords[item] / hamTotal;
            }

            P *= (double)spamTotal / hamTotal;

            if (P > 1) return $"Deze zin is SPAM met een kans van {P}";
            return $"Deze zin is HAM";

        }
    }
}

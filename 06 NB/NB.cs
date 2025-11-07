using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_NB
{
    internal class NB
    {
        double spamCount = 0.0;
        double hamCount = 0.0;
        Dictionary<string, double> spamWords = new Dictionary<string, double>();
        Dictionary<string, double> hamWords = new Dictionary<string, double>();


        public NB()
        {
            foreach (string line in File.ReadAllLines("data_small.csv").Skip(1))
            {
                string[] parts = line.Trim().ToLower().Split(new char[] { ' ',',','.','!', '?','!'});
                if (parts[0] == "spam")
                {
                    spamCount++;
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (spamWords.ContainsKey(parts[i])) spamWords[parts[i]]++;
                        else spamWords[parts[i]]=1;
                    }
                }
                else
                {
                    hamCount++;
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (hamWords.ContainsKey(parts[i])) hamWords[parts[i]]++;
                        else hamWords[parts[i]] = 1;
                    }
                } 
            }
        }
        internal object CheckIfSpam(string sms)
        {
            double spam_calculation = 1;
            double ham_calculation = 1;

            string[] parts = sms.Trim().ToLower().Split(new char[] { ' ', ',', '.', '!', '?', '!' });
            foreach (string item in parts)
            {
                Console.WriteLine(item);
                if (spamWords.ContainsKey(item)) spam_calculation *= spamWords[item] / spamCount ;
                if (hamWords.ContainsKey(item)) ham_calculation *= hamWords[item] / hamCount ;

            }
            Console.WriteLine(spam_calculation + " " + ham_calculation + " " + spamCount + " " + spamCount);
            if (spam_calculation / ham_calculation < 1) return true;
            return false;

        }
    }
}

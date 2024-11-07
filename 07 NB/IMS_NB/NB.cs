
using System.Text.RegularExpressions;

namespace IMS_NB
{
    internal class NB
    {
        List<string> spamWords = new List<string>();
        List<string> hamWords = new List<string>();
        private double total = 0.0, spamcount = 0.0, hamcount = 0.0;    

        public NB(string filename)
        {
            foreach (string line in File.ReadAllLines(filename))
            {
                total++;
                string s = Regex.Replace(line.ToLower(), @"[^a-z+]", " ");
                string[] words = s.Split(" ");
                if (words.Length > 0)
                {
                    if (words[0] == "spam")
                    {
                        spamWords.AddRange(words.Skip(1));
                        spamcount++;
                    }
                    else {
                        hamWords.AddRange(words.Skip(1));
                        hamcount++;
                    }
                }
            }
        }

        internal string CheckIfSpam(string sms)
        {
            string s = Regex.Replace(sms.ToLower(), @"[^a-z+]", " ");
            string[] words = s.Split(" ");

            double upper = 1, lower = 1;

            foreach (string word in words)
            {
                int spam = spamWords.Count(s => s.Equals(word));
                int ham = hamWords.Count(s => s.Equals(word));

                Console.WriteLine(word + " " + spam + " " + ham);

                if (spam > 0) upper *= spam / spamcount;
                if (ham > 0) lower *= ham / hamcount;
            }

            Console.WriteLine(upper + " " + lower);

            upper *= spamcount / total;
            lower *= hamcount / total;

            if (upper / lower > 1) return "SPAM";
            return "HAM";
        }
    }
}
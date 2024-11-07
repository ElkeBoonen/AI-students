
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DSPS_NB
{
    internal class NB
    {
        private Dictionary<string,double[]> Words = new Dictionary<string,double[]>();
        private double HamProp;
        private double SpamProp;

        private double total, spamcount, hamcount;

        private string[] FilterWords(string line)
        {
            string s = Regex.Replace(line.ToLower(),"[^a-z]"," ");
            //Console.WriteLine(s);
            return s.Split(" ");
        }

        public NB(string filename)
        {
            spamcount = 0;
            total = 0;
            foreach (var item in File.ReadAllLines(filename))
            {
                string[] strings = FilterWords(item);
                for (int i = 1; i < strings.Length; i++)
                {
                    if (!Words.ContainsKey(strings[i]))
                    {
                        Words[strings[i]] = new double[3];
                    }
                    //spam ham total
                    if (strings[0] == "ham") Words[strings[i]][1]++;
                    if (strings[0] == "spam") Words[strings[i]][0]++;
                    Words[strings[i]][2]++;
                }
                if (strings[0] == "spam") spamcount++;
                total++;
            }

            SpamProp = spamcount/total;
            hamcount = total - spamcount;
            HamProp = hamcount/total;  
        }

        internal string CheckIfSpam(string sms)
        {
            string[] strings = FilterWords(sms);
            double upper = 1, lower = 1;

            foreach (var item in strings)
            {
                if (Words.ContainsKey(item))
                {
                    Console.WriteLine(item + " --> " + String.Join(" - ", Words[item]));
                    if (Words[item][0] > 0)
                    { 
                        upper *= (double)Words[item][0]/(double)spamcount;
                    }
                    if (Words[item][1] > 0)
                    { 
                        lower *= (double)Words[item][1]/(double)hamcount;
                    }
                }
            }
            upper *= SpamProp;
            lower *= HamProp;

            Console.WriteLine(upper);
            Console.WriteLine(lower);

            if (upper / lower > 1) return "SPAM";
            return "HAM";
        }
    }
}
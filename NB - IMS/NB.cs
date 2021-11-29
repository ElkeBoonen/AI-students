using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace NB___IMS
{
    class NB
    {
        Dictionary<string, Dictionary<string, int>> _dictionary;
        double _hamcount, _spamcount;

        public NB()
        {
            _dictionary = new Dictionary<string, Dictionary<string, int>>();

            _dictionary["ham"] = new Dictionary<string, int>();
            _dictionary["spam"] = new Dictionary<string, int>();

        }
        public void ReadData(string filename)
        {
            foreach (var item in File.ReadAllLines(filename))
            {
                Regex regex = new Regex(@"[^a-z ]");
                string[] words = regex.Replace(item,"").Split(' ');

                string key = "spam";
                if (item.Contains("ham,"))
                {
                    key = "ham";
                    _hamcount++;
                }
                else _spamcount++;

                foreach (var word in words)
                {
                    if (_dictionary[key].ContainsKey(word)) _dictionary[key][word]++;
                    else _dictionary[key][word] = 1;
                }
            }
        }

        public string Classify(string text)
        {
            Regex regex = new Regex(@"[^a-z ]");
            string[] words = regex.Replace(text, "").Split(' ');

            double teller = 1, noemer = 1;

            //elk woord dat ik moet classificeren
            foreach (var item in words)
            {
                if (_dictionary["spam"].ContainsKey(item)) teller *= (double)_dictionary["spam"][item] / _spamcount;
                if (_dictionary["ham"].ContainsKey(item)) noemer *= (double)_dictionary["ham"][item] / _hamcount;
            }

            teller *= (double)_spamcount / (_spamcount + _hamcount);
            noemer *= (double)_hamcount / (_spamcount + _hamcount);

            //Console.WriteLine(teller/noemer);

            if (teller / noemer/100 > 1) return "SPAM";
            return "HAM";
        }
    }
}

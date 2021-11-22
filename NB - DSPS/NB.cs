using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace NB___DSPS
{
    class NB
    {
        Dictionary<string, int> _spam = new Dictionary<string, int>();
        Dictionary<string, int> _ham = new Dictionary<string, int>();
        double _countspam = 0;
        double _countham = 0;
        double _total = 0;

        public NB(string filename)
        {
            ReadData(filename);
        }
        private void ReadData(string filename)
        {
            Regex regex = new Regex(@"[a-z]+");    //[a-z]*
            foreach (var item in File.ReadAllLines(filename))
            {
                if (item.IndexOf(',') >= 0)
                {
                    string hamspam = item.ToLower().Substring(0, item.IndexOf(','));
                    string message = item.ToLower().Substring(item.IndexOf(',')+1);

                    if (hamspam == "ham") _countham++;
                    else _countspam++;

                    foreach (Match match in regex.Matches(message))
                    {
                        if (hamspam == "ham")
                        {
                            if (_ham.ContainsKey(match.Value)) _ham[match.Value]++;
                            else _ham[match.Value] = 1;
                        }
                        else
                        {
                            if (_spam.ContainsKey(match.Value)) _spam[match.Value]++;
                            else _spam[match.Value] = 1;
                        }

                    }
                }
            }
            _total = _countham + _countspam;
        }

 

        public bool IsSpam(string text)
        {
            Regex regex = new Regex(@"\w+");    //[a-z]*

            double nom = 1;
            double denom = 1;

            foreach (Match item in regex.Matches(text.ToLower()))
            {
                if (_spam.ContainsKey(item.Value)) nom *= _spam[item.Value] / _countspam;
                if (_ham.ContainsKey(item.Value)) denom *= _ham[item.Value] / _countham;
            }

           

            nom *= _countspam / _total;
            denom *= _countham/_total;

            if (nom/denom >= 1) return true;
            else return false;
        }
    }
}

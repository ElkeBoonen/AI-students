using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RandomOrg.CoreApi;

namespace Randomness
{
    internal class LCG
    {
        const double a = 214013;
        const double c = 2531011;
        double m;
        double r_n;

        public LCG()
        {
            m = Math.Pow(2, 31);
            r_n = (double)DateTime.Now.Ticks;
            //Console.WriteLine(r_n);
        }

        public double Next()
        {
            double next = (a * r_n + c) % m;
            r_n = next;
            return next;
        }

        public double Next(int max)
        {
            return Next() % max;
        }

        //https://api.random.org/dashboard/details
        public async void NextAPI()
        { 
            /*HttpClient client = new HttpClient();
            string key = "b096550b-88fb-4179-bf14-8645c1a4e33b";
            string url = "https://api.random.org/";
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp")
            HttpResponseMessage response = client.GetAsync(key).Result;*/

            RandomOrgClient client = RandomOrgClient.GetRandomOrgClient("b096550b-88fb-4179-bf14-8645c1a4e33b");
            int[] resp = client.GenerateIntegers(10, 0, 20);
            Console.WriteLine(string.Join(" ", resp));

        }


    }
}

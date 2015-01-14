using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHttp.Http;

namespace GCApi.Classes
{
    //Написать про бейджи
    public class player
    {
        static string result;
        static string nick;
        static string get(string name)
        {
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            string url = "https://api.greencubes.org/users/" + name;
            var result = http.Get(url);
            string ans = Convert.ToString(result.RawText);
            ans = ans.Replace("{", "");
            ans = ans.Replace("}", "");
            ans = ans.Replace("\"", "");
            return ans;
        }

        public player(string n)
        {
            nick = n;
            result = get(nick).Replace(",", "");
        }

        public string name()
        {
            int i = result.IndexOf("username:");
            string a = "";
            while (result[i + 10] != '\n')
            {
                a = a + result[i + 10];
                i++;
            }
            return a;
        }

        public bool status()
        {
            int i = result.IndexOf("main:");
            string a = "";
            while (result[i + 6] != '\n')
            {
                a = a + result[i + 6];
                i++;
            }
            if (a == "true")
                return true;
            else
                return false;
        }

        public string date()
        {
            int i = result.LastIndexOf("main:");
            string a = "";
            while (result[i + 6] != '\n')
            {
                a = a + result[i + 6];
                i++;
            }
            DateTime pDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(int.Parse(a));
            string time = Convert.ToString(pDate);
            return time;
        }

        public bool activ()
        {
            const int aktivTime = 1814400;
            int i = result.LastIndexOf("main:");
            string a = "";
            while (result[i + 6] != '\n')
            {
                a = a + result[i + 6];
                i++;
            }
            int Usertime = int.Parse(a);
            int NowTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            if (NowTime - Usertime <= aktivTime)
                return true;
            else
                return false;
        }

        public string prefix()
        {
            int i = result.IndexOf("prefix");
            string a = "";
            while (result[i + 8] != '\n')
            {
                a = a + result[i + 8];
                i++;
            }
            if (a != "null")
            {
                i = result.IndexOf("[");
                a = "";
                while (result[i - 1] != ']')
                {
                    a = a + result[i];
                    i++;
                }
                if (a == "[&aHELP!&4]")
                    a = "[HELP!]";
                if (a == "[&1MOD&9]")
                    a = "[MOD]";
                if (a == "[&rff66c016G&rfff7f7f7C&r99446666]")
                    a = "[GC]";
            }
            else
                a = "";
            return a;
        }

        public bool banned()
        {
            int i = result.IndexOf("banned:");
            string a = "";
            while (result[i + 8] != '\n')
            {
                a = a + result[i + 8];
                i++;
            }
            if (a == "true")
                return true;
            else
                return false;
        }

        public string reg_date()
        {
            int i = result.LastIndexOf("reg_date:");
            string a = "";
            while (result[i + 10] != '\n')
            {
                a = a + result[i + 10];
                i++;
            }
            DateTime pDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(int.Parse(a));
            string time = Convert.ToString(pDate);
            return time;
        }
        public int gcyears()
        {
            const int tw = 1209600;
            int i = result.LastIndexOf("reg_date:");
            string a = "";
            while (result[i + 10] != '\n')
            {
                a = a + result[i + 10];
                i++;
            }
            int Usertime = int.Parse(a);
            int NowTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            int years = (NowTime - Usertime) / tw;
            return years;
        }

    }
}

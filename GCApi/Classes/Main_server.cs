using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHttp.Http;

namespace GCApi.Classes
{

    //Этот класс содержит инфу о игроках в онлайне.
    //TODO:
    //Добавить подсчёт кол-ва игроков. Сделать отображение читаемым.


    public class main_online
    {
        static string res;

        static string get()
        {
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            string url = "https://api.greencubes.org/main/online";
            var result = http.Get(url);
            string ans = Convert.ToString(result.RawText);
            ans = ans.Replace("{", "");
            ans = ans.Replace("}", "");
            ans = ans.Replace("\"", "");
            return ans;
        }

        public main_online()
        {
            res = get();
        }

        public string list()
        {
            string a = res.Replace("\n", "");
            a = a.Replace("[", "");
            a = a.Replace("]", "");
            a = a.Replace(" ", "");
            a = a.Replace(",", " ");
            return a;
        }
    }

    //А вот тут статус сервера.

    public class main_stat
    {
        static string res;

        static string get()
        {
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            string url = "https://api.greencubes.org/main/online";
            var result = http.Get(url);
            string ans = Convert.ToString(result.RawText);
            ans = ans.Replace("{", "");
            ans = ans.Replace("}", "");
            ans = ans.Replace("\"", "");
            return ans;
        }

        public main_stat(string res1)
        {
            res = get();
        }

        public bool status()
        {
            int i = res.IndexOf("status:");
            string a = "";
            while (res[i + 8] != ',')
            {
                a = a + res[i + 8];
                i++;
            }
            if (a == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCApi.Classes;

namespace APILib_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            player user = new player("AndBo");
            Console.WriteLine(user.name());
            main_online server = new main_online();
            Console.WriteLine(server.list());
            Console.ReadKey();

        }
    }
}

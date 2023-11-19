using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace adad
{
    public class Username
    {

        public int id { get; set; }
        public string username { get; set; }

        public Username(int id, string username)
        {
            this.id = id;
            this.username = username;




            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID" + " " + id + " USERNAME " + username);
            Console.ResetColor();
        }



    }
}

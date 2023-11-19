using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DDD_PROJECT;

namespace DDD_PROJECT
{
    public class Register
    {



        //public double ammount { get; set; }
        public int ID { get; set; } // this is not accessible because of private
        public static int NextID = 612459; // counting will start at 100, 101 , 102
        public string idassign { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string type { get; set; }
        public int newid { get; set; }
        public string username1 { get; set; }


        public Register(string userName)
        {

            this.userName = userName;


            //ID = NextID;
            //NextID++;


            //    Console.WriteLine(" USERNAME NAME: " + userName);
            //Console.ResetColor();
        }
        public Register(string userName, string type)
        {

            this.userName = userName;
            this.type = type;


            //ID = NextID;
            //NextID++;


            //Console.WriteLine(type + " USERNAME NAME: " + userName);
            //Console.ResetColor();
        }



        public Register(string userName, string passWord, string type)
        {

            this.userName = userName;
            this.passWord = passWord;
            this.type = type;


            //ID = NextID;
            //NextID++;
            //Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("ID " + ID + " CREATED FOR " + type + " :" + userName);
            //    Console.WriteLine("USER REGISTERED ");
            //    Console.ResetColor();
            //}
            //// example of virtual method modified 
            //public Register(string userName, string newid, string passWord, string type)
            //{

            //    this.userName = userName;
            //    this.passWord = passWord;
            //    this.type = type;


            //    ID = NextID;
            //    NextID++;
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    //Console.WriteLine("ID " + ID + " CREATED FOR " + type + " :" + userName);
            //    //Console.WriteLine("USER REGISTERED ");
            //    //Console.ResetColor();
            //}

        }
    }



}

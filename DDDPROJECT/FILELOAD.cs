using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_PROJECT;


namespace ddd1
{
    internal class fileLoad
    {// pascal case in use here

        public void loadFile1()
        {
            Console.WriteLine("Loading transaction from file...");
            string BeigeLine;
            //Pass the file path and file name to the StreamReader constructor
            StreamReader StrRead = new StreamReader("C:\\users\\672484\\OneDrive - hull.ac.uk\\Desktop\\regSTUDENTS.txt");
            //Read the first line of text
            BeigeLine = StrRead.ReadLine();
            // pascal case here
            //Continue to read until you reach end of file
            while (BeigeLine != null)
            {
                //write the line to console window
                Console.WriteLine(BeigeLine);
                //Read the next line
                BeigeLine = StrRead.ReadLine();
            }
            //close the file
            StrRead.Close();


        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using System.IO;
using adad;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ddd1;
using System.Text;
using System.Transactions;
using DDD_PROJECT;




IDictionary<string, string> feelingsStud = new Dictionary<string, string>();

IDictionary<string, string> studentBookinginfo = new Dictionary<string, string>();


IDictionary<string, int> studentList = new Dictionary<string, int>();

IDictionary<string, string> personalSupervisors = new Dictionary<string, string>();


IDictionary<string, string> seniorTutors = new Dictionary<string, string>();

List<Username> staff = new List<Username>();

List<Register> regUsers = new List<Register>();



static void ReadFromFile()
{
    using (StreamReader sr = File.OpenText(@"C:\Users\672484\Desktop\FileStudentFeelings.txt"))
    {
        string tables = null;

        while ((tables = sr.ReadLine()) != null)
        {
            Console.WriteLine("{0}", tables);
        }
        Console.WriteLine("Table Printed.");
    }
}

static void ReadFromFile1()
{
    using (StreamReader sr = File.OpenText(@"C:\Users\672484\Desktop\MEETINGWITHSTUDENTS.txt"))
    {
        string tables = null;

        while ((tables = sr.ReadLine()) != null)
        {
            Console.WriteLine("{0}", tables);
        }

    }
}




//Read the first line of text



bool menu = true; // used to restart app and not break
while (menu)
{

    menu = true;

    Console.WriteLine("1.LOGIN");
    Console.WriteLine("2.REGISTER");
    Console.WriteLine("3.DISPLAY REGISTERED USERS");

    int cHOICE = int.Parse(Console.ReadLine());
    if (cHOICE == 3)
    {
        Console.WriteLine("LOADING REGISTERED USERS");
        string line3;
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr3 = new StreamReader(@"C:\Users\672484\Desktop\regSTUDENTS.txt");

        //fileLoad loadfirstbeige = new fileLoad();
        //loadfirstbeige.loadFile1(); // method used to load the file


        int startIndexs = 0;
        int lengthsOne = 6;

        int startIndex3 = 7;
        int length3Three = 8;

        foreach (string lineFile in File.ReadLines(@"C:\Users\672484\Desktop\regSTUDENTS.txt", Encoding.UTF8))
        {
            // these wil look at specified indexes and give a specified length

            String substringOne = lineFile.Substring(startIndexs, lengthsOne);
            String substringThree = lineFile.Substring(startIndex3, lineFile.Length - startIndex3);

            string staffId = substringOne;
            string staffName = substringThree;


            Console.WriteLine(substringThree + " " + "ID: " + substringOne);

            Register User = new Register(staffId, staffName);
            regUsers.Add(User);
        }
        sr3.Close();
    }
    if (cHOICE == 2)
    {
        Console.WriteLine("Are you?");
        Console.WriteLine("1.STUDENT");
        Console.WriteLine("2.PERSONAL SUPERVISOR");
        Console.WriteLine("3.SENIOR TUTOR");
        Console.WriteLine("4.EXIT");

        int choice = int.Parse(Console.ReadLine());
        string type;
        if (choice == 1)
        {
            type = "STUDENT";
            Console.WriteLine("PLEASE ENTER YOUR USERNAME AND PASSOWRD");
            Console.WriteLine("NAME: ");
            string usernameReg = Console.ReadLine();



            Console.WriteLine("PASSWORD: ");
            string passwordReg = Console.ReadLine();





            string parameterToCheck = usernameReg; // The parameter value you want to check
            string parameterToCheck2 = type;

            bool parameterExistsInList = regUsers.Any(item => item.userName == parameterToCheck);
            bool parameterExistsInList2 = regUsers.Any(item => item.passWord == parameterToCheck2);

            



            Random generator = new Random();
            int r = generator.Next(1, 1000000);
            string s = r.ToString().PadLeft(6, '0');
            s = generator.Next(1, 1000000).ToString("000000");

            Console.WriteLine(s);
            string idtocheck = s;
            bool newpara = regUsers.Any(item => item.newid == idtocheck);
            if (newpara && parameterExistsInList && parameterExistsInList2)
            {
                Console.WriteLine("STUDENT ALREADY REGISTERED");
            }
            else
            {
                Register USER1 = new Register(usernameReg, idtocheck,passwordReg);
                regUsers.Add(USER1);


                string path = @"C:\users\672484\Desktop\regSTUDENTS.txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine("REGISTERED STUDENTS LIST");
                    tw.Close();
                }

                else if (File.Exists(path))
                {
                    using (var sw = new StreamWriter(path, true))
                    {
                        DateTime currentDateTime = DateTime.Now;
                        string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                        sw.WriteLine(s + "," + passwordReg);


                    }
                }

            }
        }
















        if (choice == 2)
        {
            type = "PERSONAL SUPERVISOR";

            Console.WriteLine("PLEASE ENTER YOUR USERNAME AND PASSOWRD");
            Console.WriteLine("NAME: ");
            string usernameReg = Console.ReadLine();



            Console.WriteLine("PASSWORD: ");
            string passwordReg = Console.ReadLine();


          

            string parameterToCheck = usernameReg; // The parameter value you want to check
            string parameterToCheck2 = type;

            bool parameterExistsInList = regUsers.Any(item => item.userName == parameterToCheck);
           
            bool parameterExistsInList3 = regUsers.Any(item => item.passWord == passwordReg);


            Random generator = new Random();
            int r = generator.Next(1, 1000000);
            string s = r.ToString().PadLeft(6, '0');
            s = generator.Next(1, 1000000).ToString("000000");
            string newpara1 = s;
            Console.WriteLine(s);
            bool newpara = regUsers.Any(item => item.newid == newpara1);
            if (newpara && parameterExistsInList && parameterExistsInList3)
            {
                Console.WriteLine("STAFF ALREADY REGISTERED");
            }
            else
            {
                Register USER1 = new Register(usernameReg, newpara1, passwordReg);
                regUsers.Add(USER1);


                string path = @"C:\Users\672484\Desktop\regSTUDENTS.txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                    TextWriter tw = new StreamWriter(path);

                    tw.Close();
                }

                else if (File.Exists(path))
                {
                    using (var sw = new StreamWriter(path, true))
                    {
                        DateTime currentDateTime = DateTime.Now;
                        string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                        sw.WriteLine(s + "," + usernameReg);


                    }
                }

            }
        }
        if (choice == 3)
        {
            type = "SENIOR TUTOR";

            Console.WriteLine("PLEASE ENTER YOUR USERNAME AND PASSOWRD");
            Console.WriteLine("NAME: ");
            string usernameReg = Console.ReadLine();



            Console.WriteLine("PASSWORD: ");
            string passwordReg = Console.ReadLine();


           

            string parameterToCheck = usernameReg; // The parameter value you want to check
            string parameterToCheck2 = type; // The parameter value you want to check

            bool parameterExistsInList = regUsers.Any(item => item.userName == parameterToCheck);
            
            bool parameterExistsInList3 = regUsers.Any(item => item.passWord == passwordReg);


            Random generator = new Random();
            int r = generator.Next(1, 1000000);
            string s = r.ToString().PadLeft(6, '0');
            s = generator.Next(1, 1000000).ToString("000000");

            Console.WriteLine(s);

            bool newpara = regUsers.Any(item => item.newid == s);
            if (newpara && parameterExistsInList && parameterExistsInList3)
            {
                Console.WriteLine("STAFF ALREADY REGISTERED");
            }
            else
            {
                Register USER1 = new Register(usernameReg, s, passwordReg);
                regUsers.Add(USER1);


                string path = @"C:\users\672484\Desktop\regSTUDENTS.txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                    TextWriter tw = new StreamWriter(path);

                    tw.Close();
                }

                else if (File.Exists(path))
                {
                    using (var sw = new StreamWriter(path, true))
                    {
                        DateTime currentDateTime = DateTime.Now;
                        string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                        sw.WriteLine(s + "," + usernameReg);


                    }
                }

            }
        }
        if (choice == 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("EXIT INITIATED, PROGRESS SAVED");
            Console.ResetColor();
            menu = false;
            break;
        }



    }
    if (cHOICE == 1)
    {
        Console.WriteLine("Are you?");
        Console.WriteLine("1.STUDENT");
        Console.WriteLine("2.PERSONAL SUPERVISOR");
        Console.WriteLine("3.SENIOR TUTOR");
        Console.WriteLine("4.EXIT");


        int choice = int.Parse(Console.ReadLine());

        if (choice == 4)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("EXIT INITIATED, PROGRESS SAVED");
            Console.ResetColor();
            menu = false;
            break;
        }





        if (choice == 1)
        {

            Console.WriteLine("PLEASE ENTER YOUR USERNAME AND PASSOWRD");
            Console.WriteLine("NAME: ");
            string username = Console.ReadLine();

            Console.WriteLine("AND YOUR ID: ");

            string studentId = Console.ReadLine();

            Console.WriteLine("PASSWORD: ");
            string password = Console.ReadLine();

            
            string parameterToCheck = username; // The parameter value you want to check


            bool parameterExistsInList = regUsers.Any(item => item.userName == parameterToCheck);
            
            bool newpara = regUsers.Any(item => item.newid == studentId);
            bool pass = regUsers.Any(item => item.passWord == password);

            if (parameterExistsInList && newpara && pass)
            {
                Console.WriteLine("STUDENT FOUND NAME:" + " " + username + "ID: " + studentId);

                bool menu1 = true; // used to restart app and not break
                while (menu1)
                {

                    menu1 = true;



                    Console.WriteLine("STUDENT: " + username);

                    Console.WriteLine("1.SELF REPORT HOW YOU ARE FEELING / PROGRESSING");
                    Console.WriteLine("2.BOOK A MEETING WITH THE PERSONAL SUPERVISOR");
                    Console.WriteLine("3.LOGOUT");

                    int studentChoice = int.Parse(Console.ReadLine());


                    if (studentChoice == 1)
                    {
                        Console.WriteLine("PLEASE DESCRIBE HOW YOU ARE FEELING AND PROGRESSING");
                        string studentFeelings = Console.ReadLine();

                        try
                        {
                            feelingsStud.Add(studentFeelings, username);
                        }
                        catch
                        {
                            feelingsStud[username] = studentFeelings;
                        }

                        string path1 = @"C:\Users\672484\Desktop\FileStudentFeelings.txt";
                        if (!File.Exists(path1))
                        {
                            File.Create(path1);
                            TextWriter tw = new StreamWriter(path1);
                            tw.WriteLine("-");
                            tw.Close();
                        }

                        else if (File.Exists(path1))
                        {
                            using (var sw = new StreamWriter(path1, true))
                            {
                                DateTime currentDateTime = DateTime.Now;
                                string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                                sw.WriteLine("--------------------------");
                                sw.WriteLine("STUDENT: " + username);
                                sw.WriteLine("ID: " + studentId);
                                sw.WriteLine("DESCRIBED WHEN ASKED HOW HE IS FEELING AND PROGRESSING");
                                sw.WriteLine("AT " + formattedDateTime);
                                sw.WriteLine(studentFeelings);
                                sw.WriteLine("--------------------------");

                            }
                        }
                        continue;
                    }
                    if (studentChoice == 2)
                    {
                        Random random = new Random();
                        // Define a range for the near future, for example, 1 to 30 days from now
                        int minDays = 1;
                        int maxDays = 30;

                        // Generate a random number of days to add to the current date
                        int daysToAdd = random.Next(minDays, maxDays + 1);

                        // Calculate the future date and time
                        DateTime currentDateTime1 = DateTime.Now;
                        DateTime futureDateTime = currentDateTime1.AddDays(daysToAdd);
                        string timestring = futureDateTime.ToString("g");


                        var dateAndTime = DateTime.Now;
                        int year = futureDateTime.Year;
                        int month = futureDateTime.Month;
                        int day = futureDateTime.Day;



                        Console.ForegroundColor = ConsoleColor.Green;



                        // Display the generated future date and time
                        Console.WriteLine("BOOKING CREATED: " + day + "/" + month + " " + "Between 11:00 - 15:00");
                        Console.ResetColor();


                        foreach (var kvp in studentBookinginfo)
                            Console.WriteLine("BOOKING INFO, NEXT: {0}, TIME: {1}", kvp.Key, kvp.Value);


                        string path2 = @"C:\Users\672484\Desktop\APPOINTMENTS.txt";
                        if (!File.Exists(path2))
                        {
                            File.Create(path2);
                            TextWriter tw = new StreamWriter(path2);
                            tw.WriteLine("-");
                            tw.Close();
                        }

                        else if (File.Exists(path2))
                        {
                            using (var sw = new StreamWriter(path2, true))
                            {
                                DateTime currentDateTime = DateTime.Now;
                                string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                                sw.WriteLine("--------------------------");
                                sw.WriteLine("STUDENT: " + username);
                                sw.WriteLine("ID: " + studentId);
                                sw.WriteLine("BOOKED A MEETING WITH THE PERSONAL SUPERVISOR");
                                sw.WriteLine("TIME OF BOOKING: " + day + "/" + month + " " + "Between 11:00 - 15:00");
                                sw.WriteLine("BOOKING CREATED " + futureDateTime.ToString());
                                sw.WriteLine("--------------------------");

                            }
                        }
                        continue;
                    }
                    if (studentChoice == 3)
                    {
                        break;

                    }

                }




            }
            else
            {
                Console.WriteLine("STUDENT NOT REGISTERED");
                break;

            }


            string position = "STUDENT";
            string path = @"C:\Users\672484\Desktop\STUDENTS.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine("STAFF LIST");
                tw.Close();
            }

            else if (File.Exists(path))
            {
                using (var sw = new StreamWriter(path, true))
                {
                    DateTime currentDateTime = DateTime.Now;
                    string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                    sw.WriteLine("--------------------------");
                    sw.WriteLine("USERNAME: " + username);
                    sw.WriteLine("POSITION: " + position);
                    sw.WriteLine("STUDENT ID: " + studentId);
                    sw.WriteLine("LOGGED IN: " + formattedDateTime);
                    sw.WriteLine("--------------------------");

                }
            }

        }
        if (choice == 2)
        {
            Console.WriteLine("PLEASE ENTER YOUR USERNAME AND PASSOWRD");
            Console.WriteLine("NAME: ");
            string username = Console.ReadLine();

            Console.WriteLine("AND YOUR ID: ");

            string studentId = Console.ReadLine();

            Console.WriteLine("PASSWORD: ");
            string password = Console.ReadLine();



            string parameterToCheck = username; // The parameter value you want to check
            string parameterToCheck2 = studentId;
           
            var parameterToCheck4 = password;

            bool parameterExistsInList = regUsers.Any(item => item.userName == parameterToCheck);
           
            bool newpara = regUsers.Any(item => item.newid == parameterToCheck2);
            bool parameterExistsInList3 = regUsers.Any(item => item.passWord == password);

            if (parameterExistsInList && newpara && parameterExistsInList3)
            {
                Console.WriteLine("PERSONAL SUPERVISOR" + " " + username + "" + studentId);




                personalSupervisors.Add("SUPERVISOR", username);

                bool menu1 = true; // used to restart app and not break

                while (menu1)
                {

                    menu1 = true;

                    string position = "PERSONAL SUPERVISOR";

                    Console.WriteLine("PERSONAL SUPERVISOR :" + username);

                    Console.WriteLine("1.REVIEW THE STATUS OF THE STUDENTS");
                    Console.WriteLine("2.BOOK A MEETING WITH STUDENTS");
                    Console.WriteLine("3.LOGOUT");
                    // list with students

                    int psChoice = int.Parse(Console.ReadLine());

                    if (psChoice == 1)
                    {

                        // here to display a list with students and allow PS to comment on their status
                        Console.WriteLine("LIST WITH STUDENTS");

                        //foreach (var kvp in studentList)
                        //    Console.WriteLine("STUDENT USERNAME: {0}, STUDENT ID: {1}", kvp.Key, kvp.Value);

                        ReadFromFile();

                        continue;
                    }
                    if (psChoice == 2)
                    {
                        Console.WriteLine("Please enter day of meeting:");
                        string psMeetingday = Console.ReadLine();

                        Console.WriteLine("Please enter hour of meeting from 8 to 14");
                        int psMeetinghour = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter year of meeting:");
                        int psYearmeeting = int.Parse(Console.ReadLine());



                        Console.WriteLine("LIST WITH STUDENTS");

                        foreach (var kvp in studentList)
                            Console.WriteLine("STUDENT USERNAME: {0}, STUDENT ID: {1}", kvp.Key, kvp.Value);

                        Console.WriteLine("Please enter student you want to meet :");

                        int idmeetStud = int.Parse(Console.ReadLine());

                        Console.WriteLine("MEETING BOOKED WITH STUDENT ID " + idmeetStud + " " + psMeetingday + " " + psMeetinghour + ":00" + " " + psYearmeeting);


                        string path = @"C:\Users\672484\Desktop\MEETINGWITHSTUDENTS.txt";
                        if (!File.Exists(path))
                        {
                            File.Create(path);
                            TextWriter tw = new StreamWriter(path);
                            tw.WriteLine("-");
                            tw.Close();
                        }

                        else if (File.Exists(path))
                        {
                            using (var sw = new StreamWriter(path, true))
                            {
                                DateTime currentDateTime = DateTime.Now;
                                string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                                sw.WriteLine("--------------------------");
                                sw.WriteLine("PERSONAL SUPERVISOR: " + username);
                                sw.WriteLine("BOOKED A MEETING WITH STUDENT ID " + idmeetStud + " " + psMeetingday + " " + psMeetinghour + ":00" + " " + psYearmeeting);
                                sw.WriteLine("AT " + formattedDateTime);
                                sw.WriteLine("--------------------------");

                            }
                            // here all personal supervisor interaction with students needs to be displayed
                        }

                    }

                    if (psChoice == 3)
                    {
                        break;
                    }
                }







                string path1 = @"C:\Users\672484\Desktop\PERSONALSUP.txt";
                if (!File.Exists(path1))
                {
                    File.Create(path1);
                    TextWriter tw = new StreamWriter(path1);
                    tw.WriteLine("STAFF LIST");
                    tw.Close();
                }




                else if (File.Exists(path1))
                {
                    using (var sw = new StreamWriter(path1, true))
                    {
                        DateTime currentDateTime = DateTime.Now;
                        string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");


                        sw.WriteLine("--------------------------");
                        sw.WriteLine("USERNAME: " + username);
                        sw.WriteLine("POSITION: " + "" + "PERSONAL SUPERVISOR");
                        sw.WriteLine("SUPERVISOR ID: " + studentId);
                        sw.WriteLine("LOGGED IN: " + formattedDateTime);
                        sw.WriteLine("--------------------------");

                    }
                }



            }

            else
            {
                Console.WriteLine("PERSONAL SUPERVISOR NOT REGISTERED INSIDE THE SYSTEM");
                break;
            }
        }
        if (choice == 3)
        {
            Console.WriteLine("PLEASE ENTER YOUR USERNAME AND PASSOWRD");
            Console.WriteLine("NAME: ");
            string username = Console.ReadLine();

            Console.WriteLine("AND YOUR ID: ");

            string studentId = Console.ReadLine();

            Console.WriteLine("PASSWORD: ");
            string password = Console.ReadLine();

            bool parameterExistsInList = regUsers.Any(item => item.userName == username);
            
            bool newpara = regUsers.Any(item => item.newid == studentId);
            bool parameterExistsInList3 = regUsers.Any(item => item.passWord == password);

            if (parameterExistsInList && newpara && parameterExistsInList3)
            {

                bool menu2 = true;

                while (menu2)
                {

                    menu2 = true;

                    Console.WriteLine("SENIOR TUTOR :" + username);

                    Console.WriteLine("1.SEE THE STATUS OF THE STUDENTS");
                    Console.WriteLine("2.SEE HOW PERSONAL SUPERVISOR IS INTERACTING WITH THE STUDENTS");
                    Console.WriteLine("3.LOGOUT");

                    int senTutor = int.Parse(Console.ReadLine());

                    if (senTutor == 1)
                    {
                        ReadFromFile();

                        //foreach (var kvp in feelingsStud)
                        //    Console.WriteLine("DESCRIBED FEELINGS / PROGRESSION: {0}, USERNAME: {1}", kvp.Key, kvp.Value);

                        continue;
                    }

                    if (senTutor == 2)
                    {
                        ReadFromFile1();
                    }
                    if (senTutor == 3)
                    {
                        break;
                    }
                }
            }

            else
            {
                Console.WriteLine("SENIOR TUTOR NOT REGISTERED");
            }


        }

    }
}








using System;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pharmacy pharmacy = new Pharmacy("Zeferan Pharmacy");
            string s = "Welcome to Zeferan Pharmacy control panel";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            Console.WriteLine("Enter a username: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            string passWord = Console.ReadLine();

            foreach(var elem in pharmacy.employees)
            {
                if(userName == elem.Username && passWord == elem.Password && elem.RoleType == RoleType.ADMIN)
                {
                    Console.WriteLine("Press 1 to go to the admin panel: ");
                    Console.WriteLine("Press 2 to sale: ");
                    Console.WriteLine("Press 3 to update your personal information: ");
                    string option = Console.ReadLine();
                    while (true)
                    {
                        switch (option)
                        {
                            case "1":
                                Console.WriteLine("Press 1 to add employee: ");
                                Console.WriteLine("Press 2 to add drug: ");
                                Console.WriteLine("Press 3 to delete drug: ");
                                Console.WriteLine("Press 4 to edit drug: ");
                                Console.WriteLine("Press 5 to delete employee: ");
                                Console.WriteLine("Press 6 to edit employee: ");

                                string caseOneOptions = Console.ReadLine();

                                switch (caseOneOptions)
                                {
                                    case "1":

                                        pharmacy.AddEmpolyee();

                                        break;
                                     
                                    case "2":

                                        pharmacy.AddDrug();
                                        break;
                                }

                                break;
                        }





                    }
                }
            }
        }
    }
}

﻿using System;
using System.Text.RegularExpressions;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pharmacy pharmacy = new Pharmacy("Zeferan Pharmacy");
            string s = "Welcome to Zeferan Pharmacy control panel";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Helper.ForEdit.Print(s, ConsoleColor.DarkYellow);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Main:
            while (true) 
            {
                Helper.ForEdit.Print("Enter a username: ");
                string userName = Console.ReadLine();
                Helper.ForEdit.Print("Enter a password: ");
                string passWord = Console.ReadLine();
                foreach (var elem in pharmacy.employees)
                {
                    
                    if (elem.Username == userName && elem.Password == passWord )
                    {
                        if (elem.RoleType == RoleType.ADMIN)
                            {
                            MAINMENU:
                            Helper.ForEdit.Print("Press 1 to go to the admin panel: ");
                            Helper.ForEdit.Print("Press 2 to sale: ");
                            Helper.ForEdit.Print("Press 3 to update your personal information: ");
                                string option = Console.ReadLine();
                                while (true)
                                {
                                    switch (option)
                                    {
                                        case "1":
                                        Helper.ForEdit.Print("Press 1 to add employee: ");
                                        Helper.ForEdit.Print("Press 2 to add drug: ");
                                        Helper.ForEdit.Print("Press 3 to delete drug: ");
                                        Helper.ForEdit.Print("Press 4 to edit drug: ");
                                        Helper.ForEdit.Print("Press 5 to delete employee: ");
                                        Helper.ForEdit.Print("Press 6 to edit employee: ");
                                        Helper.ForEdit.Print("Press 7 to exit: ");

                                            string caseOneOptions = Console.ReadLine();

                                            switch (caseOneOptions)
                                            {
                                                case "1":

                                                    pharmacy.AddEmpolyee();
                                                    goto Main;
                                                    break;

                                                case "2":

                                                    pharmacy.AddDrug();
                                                    break;
                                                case "3":
                                                    pharmacy.DeleteDrug();
                                                    break;
                                                case "4":
                                                    pharmacy.EditDrug();
                                                    break;

                                                case "5":
                                                    pharmacy.DeleteDrug();
                                                    break;
                                                case "6":
                                                    pharmacy.EditEmployee();
                                                    break;
                                                case "7":
                                                    goto MAINMENU;
                                            }

                                            break;

                                        case "2":
                                            pharmacy.Sale();
                                            return;

                                        case "3":

                                        #region updateInfo
                                        Helper.ForEdit.Print("Enter new name");
                                            string newName = Console.ReadLine();
                                            elem.Name = newName;
                                        Helper.ForEdit.Print("Enter new surname");
                                            string newSurname = Console.ReadLine();
                                            elem.Surname = newSurname;
                                        Helper.ForEdit.Print("Input new  birthdate: dd.mm.yyyy ");
                                        BRITHDAY:
                                            string birthdayStr = Console.ReadLine();
                                            bool IsDate = DateTime.TryParseExact(birthdayStr, "dd MM yyyy", null, 0, out DateTime BirthDate);
                                            if (!IsDate)
                                            {
                                            Helper.ForEdit.Print("Enter the date of birth according to the format!!!: ");
                                                goto BRITHDAY;
                                            }
                                            elem.BirthDate = BirthDate;


                                        Helper.ForEdit.Print("Set a new username: ");
                                        USERNAME:
                                            string username = Console.ReadLine();
                                            foreach (var item in pharmacy.employees)
                                            {
                                                if (elem.Username == username)
                                                {
                                                Helper.ForEdit.Print("This username has already exists. Please set other username");
                                                    goto USERNAME;
                                                }
                                            }
                                            elem.Username = username;
                                        Helper.ForEdit.Print("Set a new password: ");
                                        SETPASS:
                                            string password = Console.ReadLine();

                                            if (password.Length >= 5)
                                            {
                                                var hasNumber = new Regex(@"[0-9]+");
                                                var hasUpperChar = new Regex(@"[A-Z]+");
                                                var hasMiniMaxChars = new Regex(@".{8,15}");
                                                var hasLowerChar = new Regex(@"[a-z]+");
                                                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                                                if (!hasLowerChar.IsMatch(password))
                                                {
                                                Helper.ForEdit.Print("Password should contain At least one lower case letter");

                                                }
                                                else if (!hasUpperChar.IsMatch(password))
                                                {
                                                Helper.ForEdit.Print("Password should contain At least one upper case letter");
                                                    goto SETPASS;
                                                }
                                                else if (!hasMiniMaxChars.IsMatch(password))
                                                {
                                                Helper.ForEdit.Print("Password should not be less than or greater than 12 characters");
                                                    goto SETPASS;
                                                }
                                                else if (!hasNumber.IsMatch(password))
                                                {
                                                Helper.ForEdit.Print("Password should contain At least one numeric value");
                                                    goto SETPASS;
                                                }

                                                else if (!hasSymbols.IsMatch(password))
                                                {
                                                Helper.ForEdit.Print("Password should contain At least one special case characters");
                                                    goto SETPASS;
                                                }
                                                else
                                                {
                                                    goto Add;
                                                }
                                            }
                                            else
                                            {
                                            Helper.ForEdit.Print("The minimum length of the password must be 5");
                                                goto SETPASS;
                                            }
                                        Add:
                                            elem.Password = password;

                                        Helper.ForEdit.Print($"You have updated your personal information.");

                                            break;
                                        #endregion


                                        case "4":
                                            goto MAINMENU;
                                        default:
                                            break;

                                    }
                                }
                            }
                            else if (elem.RoleType == RoleType.STAFF)
                            {
                            //STAFFmenu:
                            Helper.ForEdit.Print("Press 1 to sale: ");
                            Helper.ForEdit.Print("Press 2 to update your personal information: ");
                            Helper.ForEdit.Print("Exit");
                                string staffPanel = Console.ReadLine();
                                switch (staffPanel)
                                {
                                    case "1":
                                        pharmacy.Sale();
                                        break;

                                    case "2":
                                        #region forStaff
                                        Console.WriteLine("Enter new name");
                                        string newName = Console.ReadLine();
                                        elem.Name = newName;
                                        Console.WriteLine("Enter new surname");
                                        string newSurname = Console.ReadLine();
                                        elem.Surname = newSurname;
                                        Console.WriteLine("Input new  birthdate: dd.mm.yyyy ");
                                    BRITHDAY:
                                        string birthdayStr = Console.ReadLine();
                                        bool IsDate = DateTime.TryParseExact(birthdayStr, "dd MM yyyy", null, 0, out DateTime BirthDate);
                                        if (!IsDate)
                                        {
                                            Console.WriteLine("Enter the date of birth according to the format!!!: ");
                                            goto BRITHDAY;
                                        }
                                        elem.BirthDate = BirthDate;


                                        Console.WriteLine("Set a new username: ");
                                    USERNAME:
                                        string username = Console.ReadLine();
                                        foreach (var item in pharmacy.employees)
                                        {
                                            if (elem.Username == username)
                                            {
                                                Console.WriteLine("This username has already exists. Please set other username");
                                                goto USERNAME;
                                            }
                                        }
                                        elem.Username = username;
                                        Console.WriteLine("Set a new password: ");
                                    SETPASS:
                                        string password = Console.ReadLine();

                                        if (password.Length >= 5)
                                        {
                                            var hasNumber = new Regex(@"[0-9]+");
                                            var hasUpperChar = new Regex(@"[A-Z]+");
                                            var hasMiniMaxChars = new Regex(@".{8,15}");
                                            var hasLowerChar = new Regex(@"[a-z]+");
                                            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                                            if (!hasLowerChar.IsMatch(password))
                                            {
                                                Console.WriteLine("Password should contain At least one lower case letter");

                                            }
                                            else if (!hasUpperChar.IsMatch(password))
                                            {
                                                Console.WriteLine("Password should contain At least one upper case letter");
                                                goto SETPASS;
                                            }
                                            else if (!hasMiniMaxChars.IsMatch(password))
                                            {
                                                Console.WriteLine("Password should not be less than or greater than 12 characters");
                                                goto SETPASS;
                                            }
                                            else if (!hasNumber.IsMatch(password))
                                            {
                                                Console.WriteLine("Password should contain At least one numeric value");
                                                goto SETPASS;
                                            }

                                            else if (!hasSymbols.IsMatch(password))
                                            {
                                                Console.WriteLine("Password should contain At least one special case characters");
                                                goto SETPASS;
                                            }
                                            else
                                            {
                                                goto Add;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("The minimum length of the password must be 5");
                                            goto SETPASS;
                                        }
                                    Add:
                                        elem.Password = password;

                                        Console.WriteLine($"You have updated your personal information.");

                                        break;
                                    #endregion

                                    default:
                                        break;
                                }
                            }

                    }
                }
                Helper.ForEdit.Print("Username or password is wrong");
                    return;
            }
        }
    }
}

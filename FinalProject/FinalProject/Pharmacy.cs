using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Pharmacy
    {
        public int id { get; set; }
        private int _id { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public string Location;
        public List<Employee> employees = new List<Employee>();
        public List<Drug> drugs = new List<Drug>();

        public Pharmacy(string name)
        {
            Name = name;
            Employee defaultEmp = new Employee {Name = "unknow",  Username = "admin", Password = "admin123", RoleType = RoleType.ADMIN };
            employees.Add(defaultEmp);

        }

        
       
        public void AddEmpolyee()
        {
            Employee employee = new Employee();
            Helper.ForEdit.Print("Input new employee's name: ");
            string empName = Console.ReadLine();
            employee.Name = empName;
            Helper.ForEdit.Print("Input new employee's surname: ");
            string empSurname = Console.ReadLine();
            employee.Surname = empSurname;
            Helper.ForEdit.Print("Input new employee's birthdate: dd.mm.yyyy ");
            BRITHDAY:
            string birthdayStr = Console.ReadLine();
            bool IsDate = DateTime.TryParseExact(birthdayStr, "dd MM yyyy", null, 0, out DateTime BirthDate);
            if (!IsDate)
            {
                Helper.ForEdit.Print("Enter the date of birth according to the format!!!: ",ConsoleColor.DarkRed);
                goto BRITHDAY;
            }
            employee.BirthDate = BirthDate;
            Helper.ForEdit.Print("Enter the salary of the new employee: ");
            SALARY:
            string salaryStr = Console.ReadLine();
            bool isInt = int.TryParse(salaryStr, out int salary);
            if (!isInt)
            {
                Helper.ForEdit.Print("Enter the salary correctly!!!: ",ConsoleColor.DarkRed);
                goto SALARY;
            }
            if(salary < 0)
            {
                Helper.ForEdit.Print("Negative numbers will not be included");
                goto SALARY;
            }
            if(salary < 400)
            {
                Helper.ForEdit.Print("The minimum salary should be 400 manat.", ConsoleColor.DarkRed);
                goto SALARY;
            }
            
            employee.Salary = salary;
            Helper.ForEdit.Print("Set a username and password for the employee to access the control panel: ");
            Helper.ForEdit.Print("Set a username: ");
            USERNAME:
            string username = Console.ReadLine();
            foreach(var elem in employees)
            {
                if(elem.Username == username)
                {
                    Helper.ForEdit.Print("This username has already exists. Please set other username", ConsoleColor.DarkRed);
                    goto USERNAME;
                }
            }
            employee.Username = username;
            Helper.ForEdit.Print("Set a password: ");
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
                    Helper.ForEdit.Print("Password should contain At least one lower case letter", ConsoleColor.DarkRed);
                   
                }
                else if (!hasUpperChar.IsMatch(password))
                {
                    Helper.ForEdit.Print("Password should contain At least one upper case letter", ConsoleColor.DarkRed);
                    goto SETPASS;
                }
                else if (!hasMiniMaxChars.IsMatch(password))
                {
                    Helper.ForEdit.Print("Password should not be less than or greater than 12 characters", ConsoleColor.DarkRed);
                    goto SETPASS;
                }
                else if (!hasNumber.IsMatch(password))
                {
                    Helper.ForEdit.Print("Password should contain At least one numeric value", ConsoleColor.DarkRed);
                    goto SETPASS;
                }

                else if (!hasSymbols.IsMatch(password))
                {
                    Helper.ForEdit.Print("Password should contain At least one special case characters", ConsoleColor.DarkRed);
                    goto SETPASS;
                }
                else
                {
                    goto Add;
                }
            }
            else
              {
                    Helper.ForEdit.Print("The minimum length of the password must be 5", ConsoleColor.DarkRed);
                    goto SETPASS;
              }
            Add:
            employee.Password = password;
            Helper.ForEdit.Print("Is the employee an admin or a staff ?: ");
            EMPLOYEE:
            string roleOfEmpStr = Console.ReadLine();
            
            if (roleOfEmpStr.ToUpper() == "admin".ToUpper())
            {
                employee.RoleType = RoleType.ADMIN;
            }
            else if (roleOfEmpStr.ToUpper() == "staff".ToUpper())
            {
                employee.RoleType = RoleType.STAFF;
            }
            
            employees.Add(employee);
            Helper.ForEdit.Print($"You have added an employee {empName} to the portal.");
            
        }

        public void AddDrug()
        {
            AddDrug:
            Drug drug = new Drug();
            Helper.ForEdit.Print("Input new drug's name: ");
            string drugName = Console.ReadLine();
            drug.Name = drugName;
            Helper.ForEdit.Print("Enter type of drug ?: ");
            DRUG:
            string typeOfDrugStr = Console.ReadLine();
                            
                if (typeOfDrugStr.ToUpper() == "syrop".ToUpper())
                {
                    drug.DrugType = DrugType.SYROP;
                    goto Check;
                }
                if (typeOfDrugStr.ToUpper() == "powder".ToUpper())
                {
                    drug.DrugType = DrugType.POWDER;
                    goto Check;
                }
                if (typeOfDrugStr.ToUpper() == "tablet".ToUpper())
                {
                    drug.DrugType = DrugType.TABLET;
                    goto Check;
                }
                else
                {
                    Helper.ForEdit.Print("Invalid Input. Please try again!", ConsoleColor.DarkRed);
                    goto DRUG;
                }
                Check:
                foreach (var product in drugs)
                {
                    if (product.Name == drugName && product.DrugType.ToString().ToUpper() == typeOfDrugStr.ToUpper())
                    {
                        Helper.ForEdit.Print("You have already entered the drug under this name: ", ConsoleColor.DarkRed);

                        return;
                    }
                }
            
            

            Helper.ForEdit.Print("Input new drug's count ");
            COUNT:
            string countStr = Console.ReadLine();
            bool isInt = int.TryParse(countStr, out int count);
            if (!isInt)
            {
                Helper.ForEdit.Print("Enter the count correctly!!!: ", ConsoleColor.DarkRed);
                goto COUNT;
            }
            if (count < 0)
            {
                Helper.ForEdit.Print("Negative numbers will not be included", ConsoleColor.DarkRed);
                goto COUNT;
            }

            drug.Count = count;
            Helper.ForEdit.Print("Input new drug's purchase price ");
            PURCHASE:
            string purchaseStr = Console.ReadLine();
            bool isDouble = double.TryParse(countStr, out double purchasePrice);
            if (!isDouble)
            {
                Helper.ForEdit.Print("Enter the purchase price correctly!!!: ", ConsoleColor.DarkRed);
                goto PURCHASE;
            }
            if (purchasePrice < 0)
            {
                Helper.ForEdit.Print("Negative numbers will not be included", ConsoleColor.DarkRed);
                goto PURCHASE;
            }
            drug.PurchasePrice = purchasePrice;
            Helper.ForEdit.Print("Input new drug's sale price ");
            SALE:
            string saletStr = Console.ReadLine();
            isDouble = double.TryParse(countStr, out double salePrice);
            if (!isDouble)
            {
                Helper.ForEdit.Print("Enter the sale price correctly!!!: ", ConsoleColor.DarkRed);
                goto SALE;
            }
            if (salePrice < 0)
            {
                Helper.ForEdit.Print("Negative numbers will not be included", ConsoleColor.DarkRed);
                goto SALE;
            }
            drug.SalePrice = salePrice;
            drugs.Add(drug);
            Helper.ForEdit.Print($"You have added drug {drugName} to the portal.");
        }

        public void DeleteDrug()
        {
            if (drugs.Count == 0)
            {
                Helper.ForEdit.Print(("There is currently no drug in stock", ConsoleColor.DarkRed));
                return;
            }
            Helper.ForEdit.Print("Enter the name of the drug you want to delete: ");
            string deletedDrug = Console.ReadLine();
            List<Drug> drug = drugs.FindAll(x => x.Name.ToUpper().Contains(deletedDrug.ToUpper()));

            if(drug.Count == 0)
            {
                Helper.ForEdit.Print("No drug was found under this name", ConsoleColor.DarkRed);
                return;
            }
            else
            {
                foreach(var elem in drug)
                {
                    Helper.ForEdit.Print($"ID: {elem.id}  Name: {elem.Name}  Type of drug: {elem.DrugType}");
                }
                id:
                Helper.ForEdit.Print("Enter the ID number of the drug you want to delete: ");
                string deleteDrugstr = Console.ReadLine();
                bool isInt = int.TryParse(deleteDrugstr, out int deleteDrug);
                if (!isInt)
                {
                    Helper.ForEdit.Print("Invalid Input", ConsoleColor.DarkRed);
                    goto id;
                }

                foreach(var elem in drug)
                {
                    if(elem.id == deleteDrug)
                    {
                        drugs.Remove(elem);
                        Budget = Budget -  (elem.PurchasePrice * elem.Count);
                        Helper.ForEdit.Print($"{elem.Name} has deleted");
                        break;
                    }
                }

            }

        }

        public void EditDrug()
        {
            if (drugs.Count == 0)
            {
                Helper.ForEdit.Print(("There is currently no drug in stock", ConsoleColor.DarkRed));
                return;
            }

            Helper.ForEdit.Print("Enter the name of the product you want to edit: ");
            string editedDrug = Console.ReadLine();
            List<Drug> drug = drugs.FindAll(x => x.Name.ToUpper().Contains(editedDrug.ToUpper()));

            if (drug.Count == 0)
            {
                Helper.ForEdit.Print("No drug was found under this name: ", ConsoleColor.DarkRed);
                return;
            }
            else
            {
                foreach (var elem in drug)
                {
                    Helper.ForEdit.Print($"ID: {elem.id}  Name: {elem.Name}  Type of drug: {elem.DrugType}");
                }
            }

            Helper.ForEdit.Print("Enter the ID of the product you want to edit:");
            IDedit:
            string editDrugstr = Console.ReadLine();
            bool isInt = int.TryParse(editDrugstr, out int editDrug);
            if (!isInt)
            {
                Helper.ForEdit.Print("Invalid Input", ConsoleColor.DarkRed);
                goto IDedit;
            }
            foreach(var item in drugs)
            {
                double currentPurchase = item.PurchasePrice;
                int currentCount = item.Count;
                DrugType currentType = item.DrugType;

                if(item.id == editDrug)
                {

                    Helper.ForEdit.Print("Input new drug's name: ");
                    string drugName = Console.ReadLine();
                    item.Name = drugName;
                    Helper.ForEdit.Print("Enter type of drug ?: ");
                    DRUG:
                    string typeOfDrugStr = Console.ReadLine();
                    bool isEnum = Enum.TryParse(typeOfDrugStr, out DrugType typeOfDrug);
                    if (!isEnum)
                    {
                        Helper.ForEdit.Print("Enter the drug's type correctly: ", ConsoleColor.DarkRed);
                        goto DRUG;
                    }
                    foreach (var elem in drugs)
                    {
                        if(elem.DrugType.ToString().ToUpper() == typeOfDrugStr.ToUpper())
                        {
                            Helper.ForEdit.Print("A drug of this name already exists: ", ConsoleColor.DarkRed);
                            goto IDedit;
                        }
                        else if(typeOfDrugStr.ToUpper() == "powder".ToUpper())
                        {
                            elem.DrugType = typeOfDrug;
                        }
                        else if (typeOfDrugStr.ToUpper() == "syrop".ToUpper())
                        {
                            elem.DrugType = typeOfDrug;
                        }
                        else if (typeOfDrugStr.ToUpper() == "tablet".ToUpper())
                        {
                            elem.DrugType = typeOfDrug;
                        }
                    }
                    

                    Helper.ForEdit.Print("Input new drug's count ");
                    COUNT:
                    string countStr = Console.ReadLine();
                    isInt = int.TryParse(countStr, out int count);
                    if (!isInt)
                    {
                        Helper.ForEdit.Print("Enter the count correctly!!!: ", ConsoleColor.DarkRed);
                        goto COUNT;
                    }
                    if (count < 0)
                    {
                        Helper.ForEdit.Print("Negative numbers will not be included");
                        goto COUNT;
                    }
                    item.Count = count;
                    Helper.ForEdit.Print("Input new drug's purchase price ");
                    PURCHASE:
                    string purchaseStr = Console.ReadLine();
                    bool isDouble = double.TryParse(countStr, out double purchasePrice);
                    if (!isDouble)
                    {
                        Helper.ForEdit.Print("Enter the purchase price correctly!!!: ", ConsoleColor.DarkRed);
                        goto PURCHASE;
                    }
                    if (purchasePrice < 0)
                    {
                        Helper.ForEdit.Print("Negative numbers will not be included");
                        goto PURCHASE;
                    }

                    item.PurchasePrice = purchasePrice;
                    Helper.ForEdit.Print("Input new drug's sale price ");
                    SALE:
                    string saletStr = Console.ReadLine();
                    isDouble = double.TryParse(countStr, out double salePrice);
                    if (!isDouble)
                    {
                        Helper.ForEdit.Print("Enter the sale price correctly!!!: ", ConsoleColor.DarkRed);
                        goto SALE;
                    }
                    if (salePrice < 0)
                    {
                        Helper.ForEdit.Print("Negative numbers will not be included");
                        goto SALE;
                    }
                    if (Budget < (salePrice * count))
                    {
                        Helper.ForEdit.Print("The price of the drug exceeds the budget ", ConsoleColor.DarkRed);
                        return;

                    }
                    item.SalePrice = salePrice;
                    drugs.Add(item);
                    Budget = Budget + (currentPurchase * count) - (currentPurchase * currentCount);
                    Helper.ForEdit.Print($"You have edited drug {drugName}.");
                }

                

            }



            }

        public void DeleteEmpolyee()
        {
            if (employees.Count == 0)
            {
                Helper.ForEdit.Print(("There is currently no empolyee in pharmacy", ConsoleColor.DarkRed));
                return;
            }
            Helper.ForEdit.Print("Enter the name of the empolyee you want to delete: ");
            string deletedEmp = Console.ReadLine();
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(deletedEmp.ToUpper()));

            if (emp.Count == 0)
            {
                Helper.ForEdit.Print("No employee was found under this name", ConsoleColor.DarkRed);
                return;
            }
            
                foreach (var elem in emp)
                {
                    Helper.ForEdit.Print($"ID: {elem.id}    Name: {elem.Name}    Surname: {elem.Surname} ");
                }
                id:
                Helper.ForEdit.Print("Enter the ID number of the employee you want to delete: ");
                string deleteEmpstr = Console.ReadLine();
                bool isInt = int.TryParse(deleteEmpstr, out int empDel);
                if (!isInt)
                {
                    Helper.ForEdit.Print("Invalid Input", ConsoleColor.DarkRed);
                    goto id;
                }

                foreach (var elem in employees)
                {
                    if (elem.id == empDel)
                    {
                        employees.Remove(elem);
                        
                        Helper.ForEdit.Print($"{elem.Name} has deleted");
                        break;
                    }
                    else
                    {
                        Helper.ForEdit.Print("Not found employee in this ID", ConsoleColor.DarkRed);
                    return;
                    }
                }

            
        }
        public void EditEmployee()
        {
            if (employees.Count == 0)
            {
                Helper.ForEdit.Print(("There is currently no employee in pharmacy", ConsoleColor.DarkRed));
                return;
            }

            Helper.ForEdit.Print("Enter the name of the employee you want to edit: ");
            string editedEmp = Console.ReadLine();
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(editedEmp.ToUpper()));

            if (emp.Count == 0)
            {
                Helper.ForEdit.Print("No employee was found under this name: ", ConsoleColor.DarkRed);
                return;
            }
            else
            {
                foreach (var elem in emp)
                {
                    Helper.ForEdit.Print($"ID: {elem.id}  Name: {elem.Name}  Surname: {elem.Surname}");
                }
            }

            Helper.ForEdit.Print("Enter the ID of the employee you want to edit:");
            IDedit:
            string editEmpstr = Console.ReadLine();
            bool isInt = int.TryParse(editEmpstr, out int editEmp);
            if (!isInt)
            {
                Helper.ForEdit.Print("Invalid Input", ConsoleColor.DarkRed);
                goto IDedit;
            }
            foreach (var item in employees)
            {
                

                if (item.id == editEmp)
                {

                    Helper.ForEdit.Print("Input new employee's name: ");
                    string empName = Console.ReadLine();
                    item.Name = empName;
                    Helper.ForEdit.Print("Input new employee's surname: ");
                    string empSurname = Console.ReadLine();
                    item.Surname = empSurname;
                    Helper.ForEdit.Print("Input new employee's birthdate: dd.mm.yyyy ");
                    BRITHDAY:
                    string birthdayStr = Console.ReadLine();
                    bool IsDate = DateTime.TryParseExact(birthdayStr, "dd MM yyyy", null, 0, out DateTime BirthDate);
                    if (!IsDate)
                    {
                        Helper.ForEdit.Print("Enter the date of birth according to the format!!!: ", ConsoleColor.DarkRed);
                        goto BRITHDAY;
                    }
                    item.BirthDate = BirthDate;
                    Helper.ForEdit.Print("Enter roletype of employee ?: ");
                    Emp:
                    string typeOfEmpStr = Console.ReadLine();
                    bool isEnum = Enum.TryParse(typeOfEmpStr, out RoleType typeOfEmp);
                    if (!isEnum)
                    {
                        Helper.ForEdit.Print("Enter the employee's position correctly: ", ConsoleColor.DarkRed);
                        goto Emp;
                    }
                    foreach (var elem in employees)
                    {
                        if (typeOfEmp.ToString().ToUpper() == "staff".ToUpper())
                        {
                            elem.RoleType = typeOfEmp;
                            
                        }
                        else if (typeOfEmp.ToString().ToUpper() == "staff".ToUpper())
                        {
                            elem.RoleType = typeOfEmp;
                        }
                    }
                    Helper.ForEdit.Print("Enter the salary of the new employee: ");
                    SALARY:
                    string salaryStr = Console.ReadLine();
                    isInt = int.TryParse(salaryStr, out int salary);
                    if (!isInt)
                    {
                        Helper.ForEdit.Print("Enter the salary correctly!!!: ", ConsoleColor.DarkRed);
                        goto SALARY;
                    }
                    if (salary < 0)
                    {
                        Helper.ForEdit.Print("Negative numbers will not be included");
                        goto SALARY;
                    }
                    if (salary < 400)
                    {
                        Helper.ForEdit.Print("The minimum salary should be 400 manat.", ConsoleColor.DarkRed);
                        goto SALARY;
                    }

                    item.Salary = salary;
                    
                    Helper.ForEdit.Print("Set a username: ");
                    USERNAME:
                    string username = Console.ReadLine();
                    foreach (var elem in employees)
                    {
                        if (elem.Username == username)
                        {
                            Helper.ForEdit.Print("This username has already exists. Please set other username", ConsoleColor.DarkRed);
                            goto USERNAME;
                        }
                    }
                    item.Username = username;
                    Helper.ForEdit.Print("Set a password: ");
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
                            Helper.ForEdit.Print("Password should contain At least one lower case letter", ConsoleColor.DarkRed);

                        }
                        else if (!hasUpperChar.IsMatch(password))
                        {
                            Helper.ForEdit.Print("Password should contain At least one upper case letter", ConsoleColor.DarkRed);
                            goto SETPASS;
                        }
                        else if (!hasMiniMaxChars.IsMatch(password))
                        {
                            Helper.ForEdit.Print("Password should not be less than or greater than 12 characters", ConsoleColor.DarkRed);
                            goto SETPASS;
                        }
                        else if (!hasNumber.IsMatch(password))
                        {
                            Helper.ForEdit.Print("Password should contain At least one numeric value", ConsoleColor.DarkRed);
                            goto SETPASS;
                        }

                        else if (!hasSymbols.IsMatch(password))
                        {
                            Helper.ForEdit.Print("Password should contain At least one special case characters", ConsoleColor.DarkRed);
                            goto SETPASS;
                        }
                        else
                        {
                            goto Add;
                        }
                    }
                    else
                    {
                        Helper.ForEdit.Print("The minimum length of the password must be 5", ConsoleColor.DarkRed);
                        goto SETPASS;
                    }
                Add:
                    item.Password = password;
                    

                    Helper.ForEdit.Print($"You have edited an employee {empName} to the portal.");
                }



            }
        }
        public void Sale()
        {
                if (drugs.Count == 0)
                {
                    Helper.ForEdit.Print("There is currently no drug on sale", ConsoleColor.DarkRed);
                    return;
                }
                Helper.ForEdit.Print("Enter name of drug");
                string drugName = Console.ReadLine();
                Helper.ForEdit.Print("Enter type of drug: tablet, powder, syrop");
                string drugType = Console.ReadLine();
                PIECES:
                Helper.ForEdit.Print("How many pieces: ");
                string piecesStr = Console.ReadLine();
                bool isInt = int.TryParse(piecesStr, out int pieces);
                if (!isInt)
                {
                    Helper.ForEdit.Print("Invalid Input", ConsoleColor.DarkRed);
                    goto PIECES;
                }
                if (pieces < 0)
                {
                    Helper.ForEdit.Print("Negative numbers will not be included");
                    goto PIECES;
                }
            List<Drug> drug = drugs.FindAll(x => x.Name.ToUpper().Contains(drugName.ToUpper()) && x.DrugType.ToString().ToUpper().Contains(drugType.ToUpper()));
                if(drug.Count == 0)
                {
                    Helper.ForEdit.Print("No medicine was found under this name: ", ConsoleColor.DarkRed);
                    
                }
                else
                {
                    foreach(var elem in drug)
                    {
                        if(elem.Count == 0)
                        {
                            Helper.ForEdit.Print("There is no medicine left", ConsoleColor.DarkRed);
                            return;
                        }
                        else if(elem.Count < pieces)
                        {
                            Helper.ForEdit.Print("The number of medicines you mentioned is not left.", ConsoleColor.DarkRed);
                            Helper.ForEdit.Print($"There are {elem.Count} stocks of this drug in stock. Do you want? yes or no");
                            string answer = Console.ReadLine();
                            if(answer.ToUpper() == "yes".ToUpper())
                            {
                                elem.Count = elem.Count - elem.Count;
                                Budget = Budget + (elem.SalePrice * elem.Count);
                                Helper.ForEdit.Print(($"{elem.Name} named drug has stolen"));
                                Helper.ForEdit.Print($"Budget {Budget}", ConsoleColor.DarkBlue);
                            return;
                            }
                            else
                            {
                                return;
                            }

                            
                        }
                        Helper.ForEdit.Print(($"ID:{elem.id} Name: {elem.Name} Count: {elem.Count} Type: {elem.DrugType} Price:{elem.SalePrice}"));
                        Helper.ForEdit.Print(("Do you agree to sale: yes/no?"));
                        string choice = Console.ReadLine();
                        if (choice.ToUpper() == "yes".ToUpper())
                        {
                            elem.Count = elem.Count - pieces;
                            Budget = Budget + (elem.SalePrice * pieces);
                            Helper.ForEdit.Print(($"{elem.Name} named drug has sold, {pieces} count"));
                            Helper.ForEdit.Print($"Budget {Budget}", ConsoleColor.DarkBlue);
                        }
                    }
                }
            
        }


             
        }
    }


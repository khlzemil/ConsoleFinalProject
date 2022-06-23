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
        public int Location;
        public List<Employee> employees = new List<Employee>();
        public List<Drug> drugs = new List<Drug>();

        public Pharmacy(string name)
        {
            Name = name;
            employees.Add(new Employee { Username = "admin", Password = "admin123", RoleType  = RoleType.ADMIN});

        }

        
       
        public void AddEmpolyee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Input new employee's name: ");
            string empName = Console.ReadLine();
            employee.Name = empName;
            Console.WriteLine("Input new employee's surname: ");
            string empSurname = Console.ReadLine();
            employee.Surname = empSurname;
            Console.WriteLine("Input new employee's birthdate: dd.mm.yyyy ");
            BRITHDAY:
            string birthdayStr = Console.ReadLine();
            bool IsDate = DateTime.TryParseExact(birthdayStr, "dd MM yyyy", null, 0, out DateTime BirthDate);
            if (!IsDate)
            {
                Console.WriteLine("Enter the date of birth according to the format!!!: ");
                goto BRITHDAY;
            }
            employee.BirthDate = BirthDate;
            Console.WriteLine("Enter the salary of the new employee: ");
            SALARY:
            string salaryStr = Console.ReadLine();
            bool isInt = int.TryParse(salaryStr, out int salary);
            if (!isInt)
            {
                Console.WriteLine("Enter the salary correctly!!!: ");
                goto SALARY;
            }
            if(salary < 400)
            {
                Console.WriteLine("The minimum salary should be 400 manat.");
                goto SALARY;
            }
            employee.Salary = salary;
            Console.WriteLine("Set a username and password for the employee to access the control panel: ");
            Console.WriteLine("Set a username: ");
            USERNAME:
            string username = Console.ReadLine();
            foreach(var elem in employees)
            {
                if(elem.Username == username)
                {
                    Console.WriteLine("This username has already exists. Please set other username");
                    goto USERNAME;
                }
            }
            employee.Username = username;
            Console.WriteLine("Set a password: ");
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
            employee.Password = password;
            Console.WriteLine("Is the employee an admin or a staff ?: ");
            EMPLOYEE:
            string roleOfEmpStr = Console.ReadLine();
            bool isEnum = Enum.TryParse(roleOfEmpStr, out RoleType roleOfEmp);
            if (!isEnum)
            {
                Console.WriteLine("Enter the employee's position correctly: ");
                goto EMPLOYEE;
            }
            if (roleOfEmp.ToString().ToUpper() == "admin".ToUpper())
            {
                employee.RoleType = RoleType.ADMIN;
            }
            else if (roleOfEmp.ToString().ToUpper() == "staff".ToUpper())
            {
                employee.RoleType = RoleType.STAFF;
            }
            
            employees.Add(employee);
            Console.WriteLine($"You have added an employee {empName} to the portal.");
            
        }

        public void AddDrug()
        {
            
            Drug drug = new Drug();
            Console.WriteLine("Input new drug's name: ");
            string drugName = Console.ReadLine();
            drug.Name = drugName;
            Console.WriteLine("Enter type of drug ?: ");
            DRUG:
            string typeOfDrugStr = Console.ReadLine();
            bool isEnum = Enum.TryParse(typeOfDrugStr, out DrugType typeOfDrug);
            if (!isEnum)
            {
                Console.WriteLine("Enter the drug's type correctly: ");
                goto DRUG;
            }
            foreach(var elem in drugs)
            {
                if(elem.DrugType.ToString().ToLower() == typeOfDrug.ToString().ToLower())
                {
                    Console.WriteLine("You have already entered the drug under this name: ");
                    return;
                }
                if (typeOfDrug.ToString().ToUpper() == "syrop".ToUpper())
                {
                    elem.DrugType = DrugType.SYROP;
                }
                if (typeOfDrug.ToString().ToUpper() == "powder".ToUpper())
                {
                    elem.DrugType = DrugType.POWDER;
                }
                if (typeOfDrug.ToString().ToUpper() == "tablet".ToUpper())
                {
                    elem.DrugType = DrugType.TABLET;
                }
            }
            

            Console.WriteLine("Input new drug's count ");
            COUNT:
            string countStr = Console.ReadLine();
            bool isInt = int.TryParse(countStr, out int count);
            if (!isInt)
            {
                Console.WriteLine("Enter the count correctly!!!: ");
                goto COUNT;
            }
            drug.Count = count;
            Console.WriteLine("Input new drug's purchase price ");
            PURCHASE:
            string purchaseStr = Console.ReadLine();
            bool isDouble = double.TryParse(countStr, out double purchasePrice);
            if (!isDouble)
            {
                Console.WriteLine("Enter the purchase price correctly!!!: ");
                goto PURCHASE;
            }
            drug.PurchasePrice = purchasePrice;
            Console.WriteLine("Input new drug's sale price ");
        SALE:
            string saletStr = Console.ReadLine();
            isDouble = double.TryParse(countStr, out double salePrice);
            if (!isDouble)
            {
                Console.WriteLine("Enter the sale price correctly!!!: ");
                goto SALE;
            }
            drug.SalePrice = salePrice;
            drugs.Add(drug);
            Console.WriteLine($"You have added drug {drugName} to the portal.");
        }

        public void DeleteDrug()
        {
            if (drugs.Count == 0)
            {
                Console.WriteLine(("There is currently no drug in stock"));
                return;
            }
            Console.WriteLine("Enter the name of the drug you want to delete: ");
            string deletedDrug = Console.ReadLine();
            List<Drug> drug = drugs.FindAll(x => x.Name.ToUpper().Contains(deletedDrug.ToUpper()));

            if(drug.Count == 0)
            {
                Console.WriteLine("No drug was found under this name");
                return;
            }
            else
            {
                foreach(var elem in drug)
                {
                    Console.WriteLine($"ID: {elem.id}  Name: {elem.Name}  Type of drug: {elem.DrugType}");
                }
                id:
                Console.WriteLine("Enter the ID number of the drug you want to delete: ");
                string deleteDrugstr = Console.ReadLine();
                bool isInt = int.TryParse(deleteDrugstr, out int deleteDrug);
                if (!isInt)
                {
                    Console.WriteLine("Invalid Input");
                    goto id;
                }

                foreach(var elem in drug)
                {
                    if(elem.id == deleteDrug)
                    {
                        drugs.Remove(elem);
                        Budget = Budget -  (elem.PurchasePrice * elem.Count);
                        Console.WriteLine($"{elem.Name} has deleted");
                        break;
                    }
                }

            }

        }

        public void EditDrug()
        {
            if (drugs.Count == 0)
            {
                Console.WriteLine(("There is currently no drug in stock"));
                return;
            }

            Console.WriteLine("Enter the name of the product you want to edit: ");
            string editedDrug = Console.ReadLine();
            List<Drug> drug = drugs.FindAll(x => x.Name.ToUpper().Contains(editedDrug.ToUpper()));

            if (drug.Count == 0)
            {
                Console.WriteLine("No drug was found under this name: ");
                return;
            }
            else
            {
                foreach (var elem in drug)
                {
                    Console.WriteLine($"ID: {elem.id}  Name: {elem.Name}  Type of drug: {elem.DrugType}");
                }
            }

            Console.WriteLine("Enter the ID of the product you want to edit:");
            IDedit:
            string editDrugstr = Console.ReadLine();
            bool isInt = int.TryParse(editDrugstr, out int editDrug);
            if (!isInt)
            {
                Console.WriteLine("Invalid Input");
                goto IDedit;
            }
            foreach(var item in drugs)
            {
                double currentPurchase = item.PurchasePrice;
                int currentCount = item.Count;
                DrugType currentType = item.DrugType;

                if(item.id == editDrug)
                {

                    Console.WriteLine("Input new drug's name: ");
                    string drugName = Console.ReadLine();
                    item.Name = drugName;
                    Console.WriteLine("Enter type of drug ?: ");
                    DRUG:
                    string typeOfDrugStr = Console.ReadLine();
                    bool isEnum = Enum.TryParse(typeOfDrugStr, out DrugType typeOfDrug);
                    if (!isEnum)
                    {
                        Console.WriteLine("Enter the drug's type correctly: ");
                        goto DRUG;
                    }
                    foreach (var elem in drugs)
                    {
                        if(elem.DrugType.ToString().ToUpper() == typeOfDrug.ToString().ToUpper())
                        {
                            Console.WriteLine("A drug of this name already exists: ");
                            goto IDedit;
                        }
                        else if(typeOfDrug.ToString().ToUpper() == "powder".ToUpper())
                        {
                            elem.DrugType = typeOfDrug;
                        }
                        else if (typeOfDrug.ToString().ToUpper() == "tablet".ToUpper())
                        {
                            elem.DrugType = typeOfDrug;
                        }
                        else if (typeOfDrug.ToString().ToUpper() == "tablet".ToUpper())
                        {
                            elem.DrugType = typeOfDrug;
                        }
                    }
                    

                    Console.WriteLine("Input new drug's count ");
                    COUNT:
                    string countStr = Console.ReadLine();
                    isInt = int.TryParse(countStr, out int count);
                    if (!isInt)
                    {
                        Console.WriteLine("Enter the count correctly!!!: ");
                        goto COUNT;
                    }
                    item.Count = count;
                    Console.WriteLine("Input new drug's purchase price ");
                    PURCHASE:
                    string purchaseStr = Console.ReadLine();
                    bool isDouble = double.TryParse(countStr, out double purchasePrice);
                    if (!isDouble)
                    {
                        Console.WriteLine("Enter the purchase price correctly!!!: ");
                        goto PURCHASE;
                    }

                    
                    item.PurchasePrice = purchasePrice;
                    Console.WriteLine("Input new drug's sale price ");
                    SALE:
                    string saletStr = Console.ReadLine();
                    isDouble = double.TryParse(countStr, out double salePrice);
                    if (!isDouble)
                    {
                        Console.WriteLine("Enter the sale price correctly!!!: ");
                        goto SALE;
                    }
                    if (Budget < (salePrice * count))
                    {
                        Console.WriteLine("The price of the drug exceeds the budget ");
                        return;

                    }
                    item.SalePrice = salePrice;
                    drugs.Add(item);
                    Budget = Budget + (currentPurchase * count) - (currentPurchase * currentCount);
                    Console.WriteLine($"You have edited drug {drugName}.");
                }

                

            }



            }

        public void DeleteEmpolyee()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine(("There is currently no empolyee in pharmacy"));
                return;
            }
            Console.WriteLine("Enter the name of the empolyee you want to delete: ");
            string deletedEmp = Console.ReadLine();
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(deletedEmp.ToUpper()));

            if (emp.Count == 0)
            {
                Console.WriteLine("No employee was found under this name");
                return;
            }
            else
            {
                foreach (var elem in emp)
                {
                    Console.WriteLine($"ID: {elem.id}  Name: {elem.Name}  Surname: {elem.Surname} Birthdate: {elem.BirthDate}");
                }
                id:
                Console.WriteLine("Enter the ID number of the employee you want to delete: ");
                string deleteEmpstr = Console.ReadLine();
                bool isInt = int.TryParse(deleteEmpstr, out int empDel);
                if (!isInt)
                {
                    Console.WriteLine("Invalid Input");
                    goto id;
                }

                foreach (var elem in employees)
                {
                    if (elem.id == empDel)
                    {
                        employees.Remove(elem);
                        
                        Console.WriteLine($"{elem.Name} has deleted");
                        break;
                    }
                }

            }
        }
        public void EditEmployee()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine(("There is currently no employee in pharmacy"));
                return;
            }

            Console.WriteLine("Enter the name of the employee you want to edit: ");
            string editedEmp = Console.ReadLine();
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(editedEmp.ToUpper()));

            if (emp.Count == 0)
            {
                Console.WriteLine("No employee was found under this name: ");
                return;
            }
            else
            {
                foreach (var elem in emp)
                {
                    Console.WriteLine($"ID: {elem.id}  Name: {elem.Name}  Surname: {elem.Surname}");
                }
            }

            Console.WriteLine("Enter the ID of the employee you want to edit:");
            IDedit:
            string editEmpstr = Console.ReadLine();
            bool isInt = int.TryParse(editEmpstr, out int editEmp);
            if (!isInt)
            {
                Console.WriteLine("Invalid Input");
                goto IDedit;
            }
            foreach (var item in employees)
            {
                

                if (item.id == editEmp)
                {

                    Console.WriteLine("Input new employee's name: ");
                    string empName = Console.ReadLine();
                    item.Name = empName;
                    Console.WriteLine("Input new employee's surname: ");
                    string empSurname = Console.ReadLine();
                    item.Surname = empSurname;
                    Console.WriteLine("Input new employee's birthdate: dd.mm.yyyy ");
                    BRITHDAY:
                    string birthdayStr = Console.ReadLine();
                    bool IsDate = DateTime.TryParseExact(birthdayStr, "dd MM yyyy", null, 0, out DateTime BirthDate);
                    if (!IsDate)
                    {
                        Console.WriteLine("Enter the date of birth according to the format!!!: ");
                        goto BRITHDAY;
                    }
                    item.BirthDate = BirthDate;
                    Console.WriteLine("Enter roletype of employee ?: ");
                    Emp:
                    string typeOfEmpStr = Console.ReadLine();
                    bool isEnum = Enum.TryParse(typeOfEmpStr, out RoleType typeOfEmp);
                    if (!isEnum)
                    {
                        Console.WriteLine("Enter the employee's position correctly: ");
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
                    Console.WriteLine("Enter the salary of the new employee: ");
                    SALARY:
                    string salaryStr = Console.ReadLine();
                    isInt = int.TryParse(salaryStr, out int salary);
                    if (!isInt)
                    {
                        Console.WriteLine("Enter the salary correctly!!!: ");
                        goto SALARY;
                    }
                    if (salary < 400)
                    {
                        Console.WriteLine("The minimum salary should be 400 manat.");
                        goto SALARY;
                    }
                    item.Salary = salary;
                    
                    Console.WriteLine("Set a username: ");
                    USERNAME:
                    string username = Console.ReadLine();
                    foreach (var elem in employees)
                    {
                        if (elem.Username == username)
                        {
                            Console.WriteLine("This username has already exists. Please set other username");
                            goto USERNAME;
                        }
                    }
                    item.Username = username;
                    Console.WriteLine("Set a password: ");
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
                    item.Password = password;
                    

                    Console.WriteLine($"You have edited an employee {empName} to the portal.");
                }



            }
        }
        public void Sale()
        {
                if (drugs.Count == 0)
                {
                    Console.WriteLine(("There is currently no drug on sale"));
                    return;
                }
                Console.WriteLine("Enter name of drug");
                string drugName = Console.ReadLine();
                Console.WriteLine("Enter type of drug: tablet, powder, syrop");
                string drugType = Console.ReadLine();
                PIECES:
                Console.WriteLine("How many pieces: ");
                string piecesStr = Console.ReadLine();
                bool isInt = int.TryParse(piecesStr, out int pieces);
                if (!isInt)
                {
                    Console.WriteLine("Invalid Input");
                    goto PIECES;
                }
                List<Drug> drug = drugs.FindAll(x => x.Name.ToUpper().Contains(drugName.ToUpper()) && x.DrugType.ToString().ToUpper().Contains(drugType.ToUpper()));
                if(drug.Count == 0)
                {
                    Console.WriteLine("No medicine was found under this name: ");
                    return;
                }
                else
                {
                    foreach(var elem in drug)
                    {
                        if(elem.Count == 0)
                        {
                            Console.WriteLine("There is no medicine left");
                            return;
                        }
                        else if(elem.Count < pieces)
                        {
                            Console.WriteLine("The number of medicines you mentioned is not left.");
                            Console.WriteLine($"There are {elem.Count} stocks of this drug in stock. Do you want? yes or no");
                            string answer = Console.ReadLine();
                            if(answer.ToUpper() == "yes".ToUpper())
                            {
                                elem.Count = elem.Count - elem.Count;
                                Budget = Budget + (elem.SalePrice * elem.Count);
                                Console.WriteLine(($"{elem.Name} named drug has stolen"));
                                return;
                            }
                            else
                            {
                                return;
                            }

                            
                        }
                        Console.WriteLine(($"ID:{elem.id} Name: {elem.Name} Count: {elem.Count} Type: {elem.DrugType} Price:{elem.SalePrice}"));
                        Console.WriteLine(("Do you agree to sale: yes/no?"));
                        string choice = Console.ReadLine();
                        if (choice.ToUpper() == "yes".ToUpper())
                        {
                            elem.Count = elem.Count - pieces;
                            Budget = Budget + (elem.SalePrice * pieces);
                            Console.WriteLine(($"{elem.Name} named drug has sold, {pieces} count"));
                        }
                    }
                }
            
        }


             
        }
    }


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
        public int Budget { get; set; }
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
            employee.RoleType = roleOfEmp;
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
            }
            drug.DrugType = typeOfDrug;

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
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork;
using Classwork.cs.Entities;


namespace Classwork.cs.Entities
{
    /// <summary>
    /// CPRG211 Lab 2: Inheritance
    /// </summary>
    /// <remarks>Brayden 748211: </remarks>
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            List<Employee> employees = new List<Employee>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                // id = 0
                string id = parts[0];

                // name = 1
                string name = parts[1];

                // address = 2
                string address = parts[2];

                // phone = 3
                string phone = parts[3];

                // sin = 4
                string sin = parts[4];

                // birthday = 5
                string birthday = parts[5];

                // department = 6
                string department = parts[6];

                // Get first digit of ID
                string firstDigit;

                firstDigit = id.Substring(0, 1);

                /*if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
                {
                }*/

       
                int firstDigitNum = int.Parse(firstDigit);
                int SalariedCount = 0;
                int WagesCount = 0;
                int PartTimeCount = 0;


                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    // Salaried
                    double salary = double.Parse(parts[7]);

                    // Create instance of Salaried
                    Salaried salaried;

                    salaried = new Salaried(id, name, salary);

                    // Add to employees
                    employees.Add(salaried);

                    SalariedCount++;
                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    // Waged
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    // TODO: Create Waged instance and add it to employee list.
                    Wages wages;
                    
                    wages = new Wages(id, name, rate, hours);
                    employees.Add(wages);
                    WagesCount++;
                }
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    // Part time
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    // Create PartTime instance and add it to employee list.

                    PartTime partTime; 
                    partTime = new PartTime(id, name, rate, hours);
                    employees.Add(partTime);
                    PartTimeCount++;
                }


            }

            /**
            * TODO:
            *  - Determine lowest paid salaried employee.
            *  - Determine percentage of employees that are salaried, waged, and part-time.
            */

            double averageWeeklyPay = CalcAverageWeeklyPay(employees);

            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            Employee highestPaidWagedEmployee = FindHighestPaid(employees);

            double highestWagedPay = highestPaidWagedEmployee.Pay;

            Console.WriteLine("Highest waged pay: " + highestWagedPay.ToString("C2"));
            Console.WriteLine("Highest waged employee: " + highestPaidWagedEmployee.Name);

            Employee lowestPaidSalariedEmployee = FindLowestPaid(employees);

            double lowestSalariedPay = lowestPaidSalariedEmployee.Pay;
            Console.WriteLine("Lowest paid salaried employee: " + lowestPaidSalariedEmployee.Name);
            Console.WriteLine("Lowest salaried pay: " + lowestSalariedPay.ToString("C2"));

            
            double salariedTotal = (int)AverageEmployee(employees);
            Console.WriteLine("Salaried: " + salariedTotal);
            
            double wagesTotal = (int)AverageEmployee(employees);
            Console.WriteLine("Waged: " + wagesTotal);

            double partTimeTotal = (int)AverageEmployee(employees);
            Console.WriteLine("Part time: " + partTimeTotal);

            
        }

        private static double AverageEmployee(List<Employee> employees)
        {
            int salariedCount = 0;
            int wagesCount = 0;
            int partTimeCount = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    salariedCount++;
                    double salariedTotal = salariedCount / employees.Count * 100;
                    return salariedTotal;
                }
                else if (employee is Wages wages)
                {
                    wagesCount++;
                    double wagesTotal = wagesCount / employees.Count * 100;
                    return wagesTotal;
                }
                else if (employee is PartTime partTime)
                {
                    partTimeCount++;
                    double partTimeTotal = partTimeCount / employees.Count * 100;
                    return partTimeTotal;
                }
            }
            return AverageEmployee(employees);
        }
        private static double CalcAverageWeeklyPay(List<Employee> employees)
        {
            double weeklyPaySum = 0;
            // It's okay to use loop through employees multiple times.
            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime)
                {
                    //PartTime partTime= (PartTime)employee;
                    double pay = partTime.Pay;

                    weeklyPaySum += pay;

                }
                else if (employee is Wages wages)
                {
                    double pay = wages.Pay;

                    weeklyPaySum += pay;

                }
                else if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;

                    weeklyPaySum += pay;

                }
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;

            return averageWeeklyPay;



        }

        private static Wages FindHighestPaid(List<Employee> employees)
        {
            double highestWagedPay = 0;
            Wages highestWagedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages wages)
                {
                    double pay = wages.Pay;

                    if (pay > highestWagedPay)
                    {
                        highestWagedPay = pay;
                        highestWagedEmployee = wages;
                    }
                }
            }

            return highestWagedEmployee;
        }

        private static Salaried FindLowestPaid(List<Employee> employees)
        {
            // Rename to lowestSalariedPay
            // Change to highest possible value
            double lowestSalariedPay = double.MaxValue;
            // Change type to Salaried
            // Rename to lowestSalariedEmployee
            Salaried lowestSalariedEmployee = null;

            foreach (Employee employee in employees)
            {
                // Check if employee is Salaried
                if (employee is Salaried salary)
                {
                    double pay = salary.Pay;

                    // Reverse to check if pay is less than lowestSalariedPay
                    if (pay < lowestSalariedPay)
                    {
                        lowestSalariedPay = pay;
                        lowestSalariedEmployee = salary;
                    }
                }
            }

            return lowestSalariedEmployee;
        }
    }
}
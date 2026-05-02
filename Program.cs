using System;
using System.Globalization;
using System.Xml.Linq;

namespace SalaryIncrease
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;

            Console.Write("How many employees will be registered? ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine();
            List<Employee> list = new List<Employee>();

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Employee #" + (i + 1));
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Employee existing = list.Find(x => x.Id == id);
                while (existing != null)
                {
                    Console.Write("This id already exists! Try again: ");
                    id = int.Parse(Console.ReadLine());
                    existing = list.Find(x => x.Id == id);                
                }
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine(), CI);
                Console.WriteLine();
                list.Add(new Employee(id, name, salary));
            }

            Console.WriteLine();
            Console.Write("Enter the employee id that will have salary increase:");
            int searchId = int.Parse(Console.ReadLine());

            Employee emp = list.Find(x => x.Id == searchId);
            if (emp == null)
            {
                Console.WriteLine("This Id does not exist");
            }
            else
            {
                Console.Write("Enter the percentage: ");
                double percentage = double.Parse(Console.ReadLine(), CI);
                emp.IncreaseSalary(percentage);
            }

            Console.WriteLine();
            Console.WriteLine("Updated list of employees:");

            foreach (Employee emps in list)
            {
                Console.WriteLine(emps);
            }
        }
    }
}

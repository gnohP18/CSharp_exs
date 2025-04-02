using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CSharp_Ex_3.Models
{
    public class Company
{
    private List<Employee> Employees { get; set; } = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public void DisplayAllEmployees()
    {
        foreach (var employee in Employees)
        {
            Console.WriteLine(employee);
        }
    }

    public decimal GetTotalSalary()
    {
        return Employees.Sum(emp => emp.CalculateSalary());
    }

    public Employee? GetHighestPaidEmployee()
    {
        return Employees.OrderByDescending(emp => emp.CalculateSalary()).FirstOrDefault();
    }

    public Employee? GetLowestPaidEmployee()
    {
        return Employees.OrderBy(emp => emp.CalculateSalary()).FirstOrDefault();
    }
}

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CSharp_Ex_3.Models
{
    public class Manager : Employee
    {
        public decimal BaseSalary { get; set; }
        public decimal SalaryCoefficient { get; set; }

        public Manager(string fullName, DateTime birthDate, string address, decimal baseSalary, decimal salaryCoefficient)
            : base(fullName, birthDate, address)
        {
            BaseSalary = baseSalary;
            SalaryCoefficient = salaryCoefficient;
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary * SalaryCoefficient;
        }
    }

}
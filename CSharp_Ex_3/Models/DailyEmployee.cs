using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CSharp_Ex_3.Models
{
    public class DailyEmployee : Employee
    {
        public int WorkingDays { get; set; }
        private const decimal SalaryPerDay = 50000m;

        public DailyEmployee(string fullName, DateTime birthDate, string address, int workingDays)
            : base(fullName, birthDate, address)
        {
            WorkingDays = workingDays;
        }

        public override decimal CalculateSalary()
        {
            return WorkingDays * SalaryPerDay;
        }
    }

}
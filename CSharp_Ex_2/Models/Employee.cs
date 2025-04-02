using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CSharp_Ex_2.Models
{
    public class Employee: BaseModel
    {
        private decimal KPI = 10000;
        private decimal BONUS = 100;
        private decimal FINE = -30;

        public string Name { get; set; } 
        public decimal SalaryCoefficient { get; set; }
        public List<Insurance> SoldInsurances { get; set; }

        public Employee(int id, string name, decimal salaryCoefficient): base(id)
        {
            Name = name;
            SalaryCoefficient = salaryCoefficient;
            SoldInsurances = new List<Insurance>();
        }

        public bool CheckKPI() 
        {
            return SoldInsurances.Any(_ => _.Amount > KPI);
        }
        
        public decimal CalculateTotalCommission()
        {
            return SoldInsurances.Count > 0 ? SoldInsurances.Sum(insurance => insurance.CalculateCommission()) : 0;
        }


        public decimal CalculateSalaryMonth() 
        {
            var bonus = SoldInsurances.Any(_ => _.Amount > KPI) ? BONUS : FINE;

            var totalInsuranceFee = SoldInsurances.Sum(_ => _.Amount);

            return 40 * SalaryCoefficient + (decimal)0.01* (totalInsuranceFee - CalculateTotalCommission()) + bonus; 
        }

        public void ShowSoldInsurance() 
        {
            System.Console.WriteLine($"{Id} {Name} {SalaryCoefficient} Salary={CalculateSalaryMonth()} Commision={CalculateTotalCommission()}");
            foreach (var item in SoldInsurances)
            {
                System.Console.WriteLine($"     {item.ToString()}");
            }
        }

        public override string ToString()
        {
            return $"{Id} {Name} {SalaryCoefficient} Salary={CalculateSalaryMonth()}";
        }
    }
}
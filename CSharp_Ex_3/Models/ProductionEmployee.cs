using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CSharp_Ex_3.Models
{
    public class ProductionEmployee : Employee
    {
        public int ProductsMade { get; set; }
        private const decimal SalaryPerProduct = 20000m;

        public ProductionEmployee(string fullName, DateTime birthDate, string address, int productsMade)
            : base(fullName, birthDate, address)
        {
            ProductsMade = productsMade;
        }

        public override decimal CalculateSalary()
        {
            return ProductsMade * SalaryPerProduct;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Ex_2.Models
{
    public abstract class Insurance
    {
        public string BuyerName { get; set; } 
        public decimal Amount { get; set; } 
        public int DurationMonths { get; set; } 

        public abstract decimal CalculateCommission();
    }
}
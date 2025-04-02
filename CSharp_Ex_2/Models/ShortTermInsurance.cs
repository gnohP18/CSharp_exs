using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Ex_2.Models
{
    public class ShortTermInsurance : Insurance
    {
        public ShortTermInsurance(string buyerName, decimal amount, int durationMonths)
        {
            BuyerName = buyerName;
            Amount = amount;
            DurationMonths = durationMonths;
        }

        public override decimal CalculateCommission()
        {
            return Amount * 0.05m;
        }

        public override string ToString()
        {
            return $"BuyerName:{BuyerName} Amount:{Amount} DurationMonths:{DurationMonths} Commission:{CalculateCommission()}";
        }
    }
}
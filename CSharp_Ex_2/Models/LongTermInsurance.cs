using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Ex_2.Models
{
    public class LongTermInsurance : Insurance
    {
        public decimal MonthlyAmount { get; set; }

        public LongTermInsurance(string buyerName, decimal amount, decimal monthlyAmount, int durationMonths)
        {
            BuyerName = buyerName;
            Amount = amount;
            MonthlyAmount = monthlyAmount;
            DurationMonths = durationMonths;
        }

        public override decimal CalculateCommission()
        {
            return MonthlyAmount * 0.50m;
        }

        public override string ToString()
        {
            return $"BuyerName:{BuyerName} Amount:{Amount} MonthlyAmount:{MonthlyAmount} DurationMonths:{DurationMonths} Commission:{CalculateCommission()}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CSharp_Ex.Models
{
    public abstract class Postage : BaseModel
    {
        public Postage (int id, string address, string placeReceive, Customer customer): base(id) {
            Address = address;
            PlaceReceive = placeReceive;
            Customer = customer;
        }

        public string Address { get; set; } = String.Empty;
        public string PlaceReceive { get; set; } = String.Empty;
        public Customer Customer { get; set; }
        public int Fee { get; set; }

        public abstract float GetFee();
    }
}
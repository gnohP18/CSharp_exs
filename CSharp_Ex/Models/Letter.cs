using System.Reflection.Metadata.Ecma335;
using CSharp_Ex.Common.Enums;
using CSharp_Ex.Models;

namespace Models
{
    public class Letter : Postage
    {
        public Letter(int id, string address, string placeReceive, Customer customer, FeeType type) :
        base(id, address, placeReceive, customer)
        {
            Type = type;
         }

        public FeeType Type { get; set; }

        public override float GetFee()
        {
            
            return FeeTypeExtensions.GetFee(Type);
        }

        public override string ToString()
        {
            return $"{Id}   {Customer.SenderName}  {Address}   {Customer.ReceiverName}   {PlaceReceive} {((FeeType)Type).ToString()}={GetFee()}";
        }
    }
}
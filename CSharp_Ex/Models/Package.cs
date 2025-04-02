using CSharp_Ex.Models;

namespace Models 
{
    public class Package: Postage
    {
        private const int PackageFee = 10000;

        public Package(
            int id, string address, string placeReceive, float weight, Customer customer): base(id, address, placeReceive, customer) 
        {
            Weight = weight;
        }

        public float Weight { get; set; }

        public override float GetFee()
        {
            return Weight * PackageFee;
        }

        public override string ToString()
        {
            return $"{Id}  {Customer.SenderName}   {Address}   {Customer.ReceiverName}   {PlaceReceive} {Weight}    Fee={GetFee()}";
        }
    }
}
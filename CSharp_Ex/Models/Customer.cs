namespace Models {
    public class Customer: BaseModel
    {
        public Customer(int id, string senderName, string receiverName) : base(id)
        {
            SenderName = senderName;
            ReceiverName = receiverName;
        }


        public string SenderName {get; set;} = String.Empty;
        public string ReceiverName {get; set;} = String.Empty;
    }
}
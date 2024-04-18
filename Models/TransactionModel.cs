namespace OpenQuantTest.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public UserModel Payer { get; set; }

        public UserModel Receiver { get; set; }

        public decimal Amount { get; set;}
    }
}

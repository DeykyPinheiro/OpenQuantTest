using System.Transactions;

namespace OpenQuantTest.Models
{
    public class Account
    {

        public int Id { get; set; }

        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; set; }


    }
}

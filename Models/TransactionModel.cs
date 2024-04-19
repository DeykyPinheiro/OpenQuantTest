using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipes;

namespace OpenQuantTest.Models
{
    public class TransactionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("PayerId")] 
        public UserModel Payer { get; set; }

        [ForeignKey("ReceiverId")] 
        public UserModel Receiver { get; set; }

        public decimal Amount { get; set; }

        public TransactionModel(UserModel payer, UserModel receiver, decimal amount)
        {
            this.Payer = payer;
            this.Receiver = receiver;
            Amount = amount;
        }

        public TransactionModel()
        {
        }
    }
}

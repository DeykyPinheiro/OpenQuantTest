using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenQuantTest.Models
{
    public class TransactionModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public UserModel Payer { get; set; }

        public UserModel Receiver { get; set; }

        public decimal Amount { get; set;}
    }
}

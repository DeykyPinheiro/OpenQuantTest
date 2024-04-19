using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenQuantTest.Models
{
    public class UserModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public AccountModel Account { get; set; }

        public UserModel(string name, string email)
        {
            Name = name;
            Email = email;
            Account = new AccountModel();
        }

   
    }
}

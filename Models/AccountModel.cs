﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace OpenQuantTest.Models
{
    public class AccountModel
    {
        [Key]
        [ForeignKey("User")]
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public List<TransactionModel> Transactions { get; set; }

        public AccountModel()
        {
            Balance = 0;
            Transactions = new List<TransactionModel>();
        }
    }
}

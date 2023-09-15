using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Vulcan.Models
{
    public class VulcanTransaction
    {
        public VulcanTransaction()
        {

        }

        public VulcanTransaction(int Id, string AccountHolder, int BranchCode, int AccountNumber, int AccountType, DateTime TransactionDate, decimal Amount, int Status, DateTime EffectiveStatusDate)
        {
            this.Id = Id;
            this.AccountHolder = AccountHolder;
            this.BranchCode = BranchCode;
            this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
            this.TransactionDate = TransactionDate;
            this.Amount = Amount;
            this.Status = Status;
            this.EffectiveStatusDate = EffectiveStatusDate;
        }

        public int Id { get; set; }

        public required string AccountHolder { get; set; }

        public required int BranchCode { get; set; }

        public required long AccountNumber { get; set; }

        public required int AccountType { get; set; }

        public required DateTime TransactionDate { get; set; }
        
        public required decimal Amount { get; set; }

        public required int Status { get; set; }

        public required DateTime EffectiveStatusDate { get; set; }

        [NotMapped]
        public string TimeBreached { get; set; }
    }
}
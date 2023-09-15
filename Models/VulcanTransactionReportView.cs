using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Vulcan.Models
{
    // [Table("VulcanTransactionReportView")]
    public class VulcanTransactionReportView
    {
        [Key]
        public required long Id { get; set; }

        public required int BranchCode { get; set; }

        public required int AccountType { get; set; }

        public required int Status { get; set; }

        public required int TotalCount { get; set; }

        public required decimal TotalAmount { get; set; }
    }
}
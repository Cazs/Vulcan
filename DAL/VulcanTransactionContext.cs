using Microsoft.EntityFrameworkCore;
using Vulcan.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Vulcan.DAL
{
    public class VulcanTransactionContext : DbContext
    {
        public VulcanTransactionContext(DbContextOptions<VulcanTransactionContext> options)
            : base(options)
        {
        }

        public DbSet<VulcanTransaction> VulcanTransaction { get; set; }

        public DbSet<Vulcan.Models.VulcanTransactionReportView> VulcanTransactionReportView { get; set; } = default!;
    }
}
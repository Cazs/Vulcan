using Microsoft.EntityFrameworkCore;
using Vulcan.Models;
// using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
// using Microsoft.EntityFrameworkCore;

namespace Vulcan.DAL
{
    public class VulcanTransactionContext : DbContext
    {
        public VulcanTransactionContext(DbContextOptions<VulcanTransactionContext> options)
            : base(options)
        {
        }

        public DbSet<VulcanTransaction> VulcanTransaction { get; set; }

        // public DbSet<VulcanTransaction> Movie { get; set; }

        /* public TransactionContext() : base("SchoolContext")
         {
         }*/

        /*public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }*/

        /*protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        */
    }
}
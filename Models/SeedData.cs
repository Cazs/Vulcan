using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vulcan.DAL;
using System;
using System.Linq;

namespace Vulcan.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new VulcanTransactionContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<VulcanTransactionContext>>()))
        {
            // Look for any movies.
            if (context.VulcanTransaction.Any())
            {
                return; // DB has been seeded
            }
            context.SaveChanges();
        }

        using (var context = new VulcanTransactionReportViewContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<VulcanTransactionReportViewContext>>()))
        {
            // Look for any movies.
            if (context.VulcanTransactionReportView.Any())
            {
                return; // DB has been seeded
            }
            context.SaveChanges();
        }
    }
}
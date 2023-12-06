using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ticketer.Message.Infrastructure.Data;

public static class SeedData
{
    public static readonly Core.MessageAggregate.Message Message1 = new("test one");
    public static readonly Core.MessageAggregate.Message Message2 = new("test two");

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
        {
            // Look for any Contributors.
            if (dbContext.Messages.Any())
            {
                return; // DB has been seeded
            }

            PopulateTestData(dbContext);
        }
    }

    public static void PopulateTestData(AppDbContext dbContext)
    {
        foreach (var item in dbContext.Messages)
        {
            dbContext.Remove(item);
        }

        dbContext.SaveChanges();

        dbContext.Messages.Add(Message1);
        dbContext.Messages.Add(Message2);

        dbContext.SaveChanges();
    }
}

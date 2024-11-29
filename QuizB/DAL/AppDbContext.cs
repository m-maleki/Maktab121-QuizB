using QuizB.Entities;
using QuizB.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace QuizB.DAL;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(
                "Data Source=Masoud;Database=QuizB;Integrated Security=true;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Card> Cards { get; set; }
}
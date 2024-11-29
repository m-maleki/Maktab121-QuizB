using QuizB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizB.DAL.Configurations;
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Transactions");

        builder.HasOne(x => x.SourceCard)
            .WithMany(x => x.TransactionsAsSource)
            .HasForeignKey(x => x.SourceCardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DestinationCard)
            .WithMany(x => x.TransactionsAsDestination)
            .HasForeignKey(x => x.DestinationCardId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
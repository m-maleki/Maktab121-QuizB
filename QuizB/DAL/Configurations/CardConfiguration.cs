using QuizB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuizB.DAL.Configurations;
public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Cards");

        builder.HasData(new List<Card>()
        {
            new Card() {Id = 1 , CardNumber = "6037997568331020" , HolderName = "MeliCard" ,Password = "1234" ,Balance = 500},
            new Card() {Id = 2 ,CardNumber = "6037997568331030" , HolderName = "MeliCard" ,Password = "1234" ,Balance = 100},
        });
    }
}
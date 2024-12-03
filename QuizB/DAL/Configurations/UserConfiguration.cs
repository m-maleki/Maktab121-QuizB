using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizB.Entities;

namespace QuizB.DAL.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Users");

        builder.HasData(new List<User>()
        {
            new User() { Id = 1, FirstName = "Ali", LastName = "Ali" },
            new User() { Id = 2, FirstName = "Sara", LastName = "Sara" }
        });
    }
}
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasData(
            new Author {Id = 1, Name = "James", Surname = "Patterson"},
            new Author {Id = 2, Name = "Stephen", Surname = "King"},
            new Author {Id = 3, Name = "Stan", Surname = "Lee"},
            new Author {Id = 4, Name = "John", Surname = "Gresham"},
            new Author {Id = 5, Name = "Danielle", Surname = "Steel"},
            new Author {Id = 6, Name = "Anne", Surname = "Rice"},
            new Author {Id = 7, Name = "Dean", Surname = "Koontz"},
            new Author {Id = 8, Name = "Danielle", Surname = "Steel"},
            new Author {Id = 9, Name = "Nora", Surname = "Roberts"},
            new Author {Id = 10, Name = "Tony", Surname = "Morrison"},
            new Author {Id = 11, Name = "William", Surname = "Shakespeare"},
            new Author {Id = 12, Name = "Agatha", Surname = "Christie"},
            new Author {Id = 13, Name = "Barbara", Surname = "Cartland"},
            new Author {Id = 14, Name = "Kyotaro", Surname = "Nishimura"}
        );
    }
}
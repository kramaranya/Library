using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                    .HasOne(a => a.Author)
                    .WithMany(c => c.Books)
                    .HasForeignKey(i => i.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder
                    .HasOne(a => a.Genre)
                    .WithMany(c => c.Books)
                    .HasForeignKey(i => i.GenreId)
                    .OnDelete(DeleteBehavior.SetNull);
            
            builder
                    .HasMany(a => a.Users)
                    .WithMany(a => a.Books)
                    .UsingEntity(i => i.ToTable("Form"));

            builder.HasKey(a => a.Id);

            builder.HasData(
                    new Book
                    {
                            Id = 1, Title = "Shakespeare's Sonnets", AuthorId = 1, GenreId = 1, 
                            Quantity = 5, PublicationDate = new DateTime(2019, 11, 13)
                    },
                    new Book
                    {
                            Id = 2, Title = "Shall I compare thee to a summer's day?", AuthorId = 1, GenreId = 1, 
                            Quantity = 2, PublicationDate = new DateTime(1985, 03, 2)
                    },
                    new Book
                    {
                            Id = 3, Title = "Hercule Poirot", AuthorId = 2, GenreId = 4, 
                            Quantity = 1, PublicationDate = new DateTime(1999, 07, 17)
                    },
                    new Book
                    {
                            Id = 4, Title = "Jane Marple", AuthorId = 2, GenreId = 4, 
                            Quantity = 6, PublicationDate = new DateTime(2014, 05, 27)
                    },
                    new Book
                    {
                            Id = 5, Title = "Duel of Hearts", AuthorId = 3, GenreId = 5, 
                            Quantity = 0, PublicationDate = new DateTime(1786, 09, 18)
                    },
                    new Book
                    {
                            Id = 6, Title = "Romantic Royal Marriages", AuthorId = 3, GenreId = 5, 
                            Quantity = 3, PublicationDate = new DateTime(1954, 03, 11)
                    },
                    new Book
                    {
                            Id = 7, Title = "A Ghost in Monte Carlo", AuthorId = 3, GenreId = 5, 
                            Quantity = 4, PublicationDate = new DateTime(1994, 02, 06)
                    },
                    new Book
                    {
                            Id = 8, Title = "Zoya", AuthorId = 5, GenreId = 5, 
                            Quantity = 3, PublicationDate = new DateTime(1991, 04, 01)
                    },
                    new Book
                    {
                            Id = 9, Title = "Sisters", AuthorId = 5, GenreId = 5, 
                            Quantity = 1, PublicationDate = new DateTime(1832, 08, 19)
                    },
                    new Book
                    {
                            Id = 10, Title = "The Mystery Train Disappears", AuthorId = 4, GenreId = 3, 
                            Quantity = 3, PublicationDate = new DateTime(2011, 03, 13)
                    },
                    new Book
                    {
                            Id = 11, Title = "Kisei Honsen Satsujin Jiken", AuthorId = 4, GenreId = 3, 
                            Quantity = 8, PublicationDate = new DateTime(2004, 12, 25)
                    },
                    new Book
                    {
                            Id = 12, Title = "Maigret", AuthorId = 6, GenreId = 4, 
                            Quantity = 3, PublicationDate = new DateTime(2022, 10, 27)
                    },
                    new Book
                    {
                            Id = 13, Title = "The Strange Case of Peter the Lett", AuthorId = 6, GenreId = 4, 
                            Quantity = 5, PublicationDate = new DateTime(2011, 11, 18)
                    },
                    new Book
                    {
                            Id = 14, Title = "Tu pasado me condena", AuthorId = 7, GenreId = 5, 
                            Quantity = 0, PublicationDate = new DateTime(1992, 03, 04)
                    },
                    new Book
                    {
                            Id = 15, Title = "Poltava", AuthorId = 8, GenreId = 1, 
                            Quantity = 2, PublicationDate = new DateTime(2019, 05, 19)
                    },
                    new Book
                    {
                            Id = 16, Title = "The Gypsies", AuthorId = 8, GenreId = 1, 
                            Quantity = 4, PublicationDate = new DateTime(2016, 12, 17)
                    },
                    new Book
                    {
                            Id = 17, Title = "Frank Merriwell", AuthorId = 9, GenreId = 2, 
                            Quantity = 6, PublicationDate = new DateTime(1992, 03, 18)
                    },
                    new Book
                    {
                            Id = 18, Title = "Boltwood of Yale", AuthorId = 9, GenreId = 2, 
                            Quantity = 1, PublicationDate = new DateTime(2010, 02, 18)
                    },
                    new Book
                    {
                            Id = 19, Title = "Winnetou", AuthorId = 10, GenreId = 2, 
                            Quantity = 5, PublicationDate = new DateTime(1845, 10, 18)
                    },
                    new Book
                    {
                            Id = 20, Title = "The Oil Prince", AuthorId = 10, GenreId = 2, 
                            Quantity = 3, PublicationDate = new DateTime(1905, 05, 23)
                    }
            );
        }
}
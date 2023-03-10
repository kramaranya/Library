// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Form", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "James",
                            Surname = "Patterson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Stephen",
                            Surname = "King"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Stan",
                            Surname = "Lee"
                        },
                        new
                        {
                            Id = 4,
                            Name = "John",
                            Surname = "Gresham"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Danielle",
                            Surname = "Steel"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Anne",
                            Surname = "Rice"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Dean",
                            Surname = "Koontz"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Danielle",
                            Surname = "Steel"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Nora",
                            Surname = "Roberts"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Tony",
                            Surname = "Morrison"
                        },
                        new
                        {
                            Id = 11,
                            Name = "William",
                            Surname = "Shakespeare"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Agatha",
                            Surname = "Christie"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Barbara",
                            Surname = "Cartland"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Kyotaro",
                            Surname = "Nishimura"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            GenreId = 1,
                            PublicationDate = new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 5,
                            Title = "Shakespeare's Sonnets"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            GenreId = 1,
                            PublicationDate = new DateTime(1985, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 2,
                            Title = "Shall I compare thee to a summer's day?"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            GenreId = 4,
                            PublicationDate = new DateTime(1999, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 1,
                            Title = "Hercule Poirot"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            GenreId = 4,
                            PublicationDate = new DateTime(2014, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 6,
                            Title = "Jane Marple"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 3,
                            GenreId = 5,
                            PublicationDate = new DateTime(1786, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 0,
                            Title = "Duel of Hearts"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 3,
                            GenreId = 5,
                            PublicationDate = new DateTime(1954, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 3,
                            Title = "Romantic Royal Marriages"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            GenreId = 5,
                            PublicationDate = new DateTime(1994, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 4,
                            Title = "A Ghost in Monte Carlo"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 5,
                            GenreId = 5,
                            PublicationDate = new DateTime(1991, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 3,
                            Title = "Zoya"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 5,
                            GenreId = 5,
                            PublicationDate = new DateTime(1832, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 1,
                            Title = "Sisters"
                        },
                        new
                        {
                            Id = 10,
                            AuthorId = 4,
                            GenreId = 3,
                            PublicationDate = new DateTime(2011, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 3,
                            Title = "The Mystery Train Disappears"
                        },
                        new
                        {
                            Id = 11,
                            AuthorId = 4,
                            GenreId = 3,
                            PublicationDate = new DateTime(2004, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 8,
                            Title = "Kisei Honsen Satsujin Jiken"
                        },
                        new
                        {
                            Id = 12,
                            AuthorId = 6,
                            GenreId = 4,
                            PublicationDate = new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 3,
                            Title = "Maigret"
                        },
                        new
                        {
                            Id = 13,
                            AuthorId = 6,
                            GenreId = 4,
                            PublicationDate = new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 5,
                            Title = "The Strange Case of Peter the Lett"
                        },
                        new
                        {
                            Id = 14,
                            AuthorId = 7,
                            GenreId = 5,
                            PublicationDate = new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 0,
                            Title = "Tu pasado me condena"
                        },
                        new
                        {
                            Id = 15,
                            AuthorId = 8,
                            GenreId = 1,
                            PublicationDate = new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 2,
                            Title = "Poltava"
                        },
                        new
                        {
                            Id = 16,
                            AuthorId = 8,
                            GenreId = 1,
                            PublicationDate = new DateTime(2016, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 4,
                            Title = "The Gypsies"
                        },
                        new
                        {
                            Id = 17,
                            AuthorId = 9,
                            GenreId = 2,
                            PublicationDate = new DateTime(1992, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 6,
                            Title = "Frank Merriwell"
                        },
                        new
                        {
                            Id = 18,
                            AuthorId = 9,
                            GenreId = 2,
                            PublicationDate = new DateTime(2010, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 1,
                            Title = "Boltwood of Yale"
                        },
                        new
                        {
                            Id = 19,
                            AuthorId = 10,
                            GenreId = 2,
                            PublicationDate = new DateTime(1845, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 5,
                            Title = "Winnetou"
                        },
                        new
                        {
                            Id = 20,
                            AuthorId = 10,
                            GenreId = 2,
                            PublicationDate = new DateTime(1905, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 3,
                            Title = "The Oil Prince"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Poetry"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Folktale"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Detective"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1965, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Catherine ",
                            Password = "204jsk",
                            PhoneNumber = "719-557-7626",
                            Surname = "McGinley",
                            Username = "kakdld"
                        });
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("DAL.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Book", b =>
                {
                    b.HasOne("DAL.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("DAL.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DAL.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.HasData(
            new User
            {
                Id = 1, Name = "User1 ", Surname = "User1", Username = "user1", Password = "user1", 
                PhoneNumber = "719-557-7626", DateOfBirth = new DateTime(1965, 9, 16)
            },
            new User
            {
                Id = 2, Name = "User2", Surname = "User2", Username = "user2", Password = "user2", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 3, Name = "User3", Surname = "User3", Username = "user3", Password = "user3", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 4, Name = "User4", Surname = "User4", Username = "user4", Password = "user4", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 5, Name = "User5", Surname = "User5", Username = "user5", Password = "user5", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 6, Name = "User6", Surname = "User6", Username = "user6", Password = "user6", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 7, Name = "User7", Surname = "User7", Username = "user7", Password = "user7", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 8, Name = "User8", Surname = "User8", Username = "user8", Password = "user8", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 9, Name = "User9", Surname = "User9", Username = "user9", Password = "user9", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 10, Name = "User10", Surname = "User10", Username = "user10", Password = "user10", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 11, Name = "User11", Surname = "User11", Username = "user11", Password = "user11", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 12, Name = "User12", Surname = "User12", Username = "user12", Password = "user12", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 13, Name = "User13", Surname = "User13", Username = "user13", Password = "user13", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 14, Name = "User14", Surname = "User14", Username = "user14", Password = "user14", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 15, Name = "User15", Surname = "User15", Username = "user15", Password = "user15", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(2021, 12, 13)
            },
            new User
            {
                Id = 16, Name = "User16", Surname = "User16", Username = "user16", Password = "user16", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1942, 12, 13)
            },
            new User
            {
                Id = 17, Name = "User17", Surname = "User17", Username = "user17", Password = "user17", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            },
            new User
            {
                Id = 18, Name = "User18", Surname = "User18", Username = "user18", Password = "user18", 
                PhoneNumber = "517-663-4353", DateOfBirth = new DateTime(1984, 12, 13)
            }
        );
    }
}
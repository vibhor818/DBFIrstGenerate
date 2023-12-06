using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexInheritDemo.MyContexts
{

    public class VBContext : DbContext
    {
        // public DbSet<Person> People { get; set; }
        //public DbSet<Blog> Blogs { get; set; }
        //public DbSet<RssBlog> RssBogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb;database=efdbtest;trusted_connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>()
            //    .HasDiscriminator<string>("Blog_Type")
            //    .HasValue<Blog>("BLog_Main")
            //    .HasValue<RssBlog>("Rss_Blog");
            modelBuilder.Entity<BankAccount>().HasNoKey();
            modelBuilder.Entity<CreditCard>().HasNoKey();
            //modelBuilder.Entity<Blog>().HasNoKey();


            //modelBuilder.Entity<BillingDetail>().ToTable("BillingDetails");
            //modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            //modelBuilder.Entity<CreditCard>().ToTable("CreditCards");

            //modelBuilder.Entity<Blog>().Property(p => p.Url).HasColumnName("Url");
        }
        //public DbSet<Blog> Blogs { get; set; }
       // public DbSet<BillingDetail> BillingDetails { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }

    public abstract  class BillingDetail
    {
        public int BillingDetailId { get; set; }
        public string Owner { get; set; }
        public string Number { get; set; }
    }
    //[Table("BankAccounts")]
    public class BankAccount:BillingDetail
    {
        public string BankName { get; set; }
        public string BankNumber { get; set; }
    }
    //[Table("CreditCards")]
    public class CreditCard:BillingDetail
    {
        public int CardType { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
    }


    [Index(nameof(FirstName),nameof(LastName))]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public abstract class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
    public class RssBlog : Blog
    {
        public string RssUrl { get; set; }
    }
}


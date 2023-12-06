using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Principal;

public class VBContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb;database=efdbtest;trusted_connection=true");
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Currency>().HaveConversion<CurrencyConvertor>();
    }
    public DbSet<Product> Products { get; set; }
}


public readonly struct Currency
{
    public decimal Amount { get; }
    public Currency(decimal amount) 
    { 
    this.Amount = amount;
    }
    public override string ToString()
    {
        return Amount.ToString();
    }
}
public class Product
{
    public int Id { get; set; }
    public Currency Price { get; set; }
}
public class CurrencyConvertor:ValueConverter<Currency,decimal>
{
    public CurrencyConvertor():base(v=>v.Amount,v=>new Currency(v))
    {
        
    }
}
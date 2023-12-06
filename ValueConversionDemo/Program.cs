class Program
{
    public static void Main(string[] args)
    {
        using (VBContext context = new VBContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
           
            var product = new Product { Price = new Currency(4.45m) };
            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("DB Creation done......."+product.Price.Amount);
        }
    }
}
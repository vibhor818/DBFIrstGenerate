using IndexInheritDemo.MyContexts;

class Program
{
    public static void Main(string[] args)
    {
        using(VBContext context=new VBContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Console.WriteLine("DB Creation done.......");
        }
    }
}


using DBFIrstGenerate.VBScaffoldContext;

class Program
{
    public static void Main(string[] args)
    {
        using(EmpdbContext context=new EmpdbContext())
        {
            var data = context.Emps.ToList();
            foreach(var item in data)
            {
                Console.WriteLine(item.Id+"   "+item.Name+"  "+item.Address);
            }
        }
    }
}

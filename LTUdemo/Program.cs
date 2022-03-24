// See https://aka.ms/new-console-template for more information
using LTUdemo;

public class Program
{
    List<SalesPerson> salesPersonList = new();
    List<string> message = new();
    List<int> levels = new();

    public Program()
    {
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("Please, enter how many sales persons you want to register");
        Console.WriteLine("---------------------------------------------------------");
        int numberOfInputs = Convert.ToInt32(Console.ReadLine());
        AddToList(numberOfInputs);
        AddLevels();
        AddMessage();
        Console.WriteLine(PrintHeader());
        Console.WriteLine();
        for (int i = 0; i < 4; i++)
        {
            var tmpList = PrintList(salesPersonList, levels.FirstOrDefault(), message.First());
            Remove(tmpList);
            message.RemoveAt(0);
            if (levels.Count > 0) levels.RemoveAt(0);
        }

    }

    public void AddToList(int numberOfInputs)
    {
        for (int i = 0; i < numberOfInputs; i++)
        {
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter social security number");
            var ssn = Console.ReadLine();
            Console.WriteLine("Enter district");
            var district = Console.ReadLine();
            Console.WriteLine("Enter sold articles");
            var soldArticles = Convert.ToInt32(Console.ReadLine());

            var salesPerson = new SalesPerson
            {
                Name = name,
                Ssn = ssn,
                District = district,
                SoldArticles = soldArticles
            };
            salesPersonList.Add(salesPerson);
        }
    }

    public List<SalesPerson> PrintList(List<SalesPerson> salePersonList, int? max, string message)
    {
        var tmpList = salePersonList.Where(a => a.SoldArticles < max)
                                   .OrderByDescending(a => a.SoldArticles)
                                   .ToList();

        foreach (var salesPerson in tmpList)
            Console.WriteLine($"{salesPerson.Name} {salesPerson.Ssn}  {salesPerson.District} {salesPerson.SoldArticles}");

        var tmpMessage = tmpList.Count > 0 ? $"{tmpList.Count} {message}" : $"Nivå {tmpList.Count} var tom";
        Console.WriteLine(tmpMessage);
        Console.WriteLine();

        return tmpList;
    }

    public void Remove(List<SalesPerson> list)
    {
        foreach (var p in list)
            salesPersonList.Remove(p);
    }

    public void AddLevels()
    {
        levels.Add(50);
        levels.Add(100);
        levels.Add(199);
        levels.Add(2147483647); //Hack
    }

    public void AddMessage()
    {
        message.Add("säljare har nått nivå 1: under 50 artiklar");
        message.Add("säljare har nått nivå 2: mellan 50-100 artiklar");
        message.Add("säljare har nått nivå 3: mellan 100-199 artiklar");
        message.Add("säljare har nått nivå 4: Över 200 artiklar");
    }

    public static string PrintHeader()
    {
        return "Namn Persnr Distrikt Antal";
    }
}
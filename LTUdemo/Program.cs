// See https://aka.ms/new-console-template for more information
using LTUdemo;


public class Program
{
    List<SalesPerson> salesPersonList = new();
    public Program()
    {
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("Please, enter how many sales persons you want to register");
        Console.WriteLine("---------------------------------------------------------");
        int numberOfInputs = Convert.ToInt32(Console.ReadLine());
        AddToList(numberOfInputs);
        Console.WriteLine(PrintHeader());
        PrintList(salesPersonList);
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

    public static void PrintList(List<SalesPerson> salePersonList)
    {
        var lvlOne = salePersonList.Where(a => a.SoldArticles < 50)
                                   .OrderByDescending(a => a.SoldArticles)
                                   .ToList();
        if (lvlOne.Count > 0)
        {
            foreach (var salesPerson in lvlOne)
                Console.WriteLine($"{salesPerson.Name} {salesPerson.Ssn}  {salesPerson.District} {salesPerson.SoldArticles}");

            Console.WriteLine($"{lvlOne.Count} säljare har nått nivå 1: under 50 artiklar");
        }

        var lvlTwo = salePersonList.Where(a => a.SoldArticles > 50 && a.SoldArticles < 100)
                                   .OrderByDescending(a => a.SoldArticles)
                                   .ToList();

        if (lvlTwo.Count > 0)
        {
            foreach (var salesPerson in lvlTwo)
                Console.WriteLine($"{salesPerson.Name} {salesPerson.Ssn}  {salesPerson.District} {salesPerson.SoldArticles}");

            if (lvlTwo.Count > 0) Console.WriteLine($"{lvlTwo.Count} säljare har nått nivå 2: mellan 50-100 artiklar");

        }
        var lvlThree = salePersonList.Where(a => a.SoldArticles >= 100 && a.SoldArticles <= 199)
                                     .OrderByDescending(a => a.SoldArticles)
                                     .ToList();

        if (lvlThree.Count > 0)
        {
            foreach (var salesPerson in lvlThree)
                Console.WriteLine($"{salesPerson.Name} {salesPerson.Ssn}  {salesPerson.District} {salesPerson.SoldArticles}");

            Console.WriteLine($"{lvlThree.Count} säljare har nått nivå 3: mellan 100-199 artiklar");
        }
        var lvlFour = salePersonList.Where(a => a.SoldArticles > 199)
                                    .OrderByDescending(a => a.SoldArticles)
                                    .ToList();
        if (lvlFour.Count > 0)
        {
            foreach (var salesPerson in lvlFour)
                Console.WriteLine($"{salesPerson.Name} {salesPerson.Ssn}  {salesPerson.District} {salesPerson.SoldArticles}");

            Console.WriteLine($"{lvlFour.Count} säljare har nått nivå 4: Över 200 artiklar");
        }
    }
    public static string PrintHeader()
    {
        return "Namn Persnr Distrikt Antal";
    }

}
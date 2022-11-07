namespace Lab1;

public class InputOutput
{
    public static void PrintMenu()
    {
        Console.WriteLine("1.  To backpack with undivided items only");
        Console.WriteLine("10. To backpack with divided and undivided items");
        Console.WriteLine("2.  To parenthesis");
        Console.WriteLine("31. To triangulation with area as value");
        Console.WriteLine("32. To triangulation with diagonal length as value");
        Console.WriteLine("4.  To print menu");
        Console.WriteLine("0.  To exit");
        BoldLine();
    }

    public static int Input(string message)
    {
        var value = 0;
        Console.WriteLine(message);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Wrong data. " + message);
        }

        return value;
    }
    
    public static double InputDouble(string message)
    {
        double value;
        Console.WriteLine(message);
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Wrong data. " + message);
        }

        return value;
    }
    
    public static void BoldLine()
    {
        Console.WriteLine("==========================================");
    }
}
namespace Lab2;

public class InputOutput
{
    public static void PrintMenu()
    {
        Console.WriteLine("1.  To schedule by max lateness");
        Console.WriteLine("2.  To schedule by total lateness");
        Console.WriteLine("3.  To schedule by start time without conflicts");
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
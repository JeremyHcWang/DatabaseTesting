namespace ConsoleApp1;

public class Methods
{
    public void OutputBytes()
    {
        Console.WriteLine("Data Type\t\tSize (bytes)\t\tMinimum Value\t\tMaximum Value");
        Console.WriteLine("---------------------------------------------------------------");

        Console.WriteLine($"sbyte\t\t\t{sizeof(sbyte)}\t\t\t{sbyte.MinValue}\t\t\t{sbyte.MaxValue}");
        Console.WriteLine($"byte\t\t\t{sizeof(byte)}\t\t\t{byte.MinValue}\t\t\t{byte.MaxValue}");
        Console.WriteLine($"short\t\t\t{sizeof(short)}\t\t\t{short.MinValue}\t\t\t{short.MaxValue}");
        Console.WriteLine($"ushort\t\t\t{sizeof(ushort)}\t\t\t{ushort.MinValue}\t\t\t{ushort.MaxValue}");
        Console.WriteLine($"int\t\t\t{sizeof(int)}\t\t\t{int.MinValue}\t\t\t{int.MaxValue}");
        Console.WriteLine($"uint\t\t\t{sizeof(uint)}\t\t\t{uint.MinValue}\t\t\t{uint.MaxValue}");
        Console.WriteLine($"long\t\t\t{sizeof(long)}\t\t\t{long.MinValue}\t\t\t{long.MaxValue}");
        Console.WriteLine($"ulong\t\t\t{sizeof(ulong)}\t\t\t{ulong.MinValue}\t\t\t{ulong.MaxValue}");
        Console.WriteLine($"float\t\t\t{sizeof(float)}\t\t\t{float.MinValue}\t\t\t{float.MaxValue}");
        Console.WriteLine($"double\t\t\t{sizeof(double)}\t\t\t{double.MinValue}\t\t{double.MaxValue}");
        Console.WriteLine($"decimal\t\t\t{sizeof(decimal)}\t\t\t{decimal.MinValue}\t\t{decimal.MaxValue}");
    }
    
    public void OutputCenturies()
    {
        Console.Write("Enter the number of centuries: ");
        int centuries = Convert.ToInt32(Console.ReadLine());

        int years = centuries * 100;
        int days = years * 365;
        int hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        long nanoseconds = microseconds * 1000;

        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} " +
                          $"hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = " +
                          $"{microseconds} microseconds = {nanoseconds} nanoseconds");
    }

    public void FizzBuzz()
    {   
        int limit = 100;

        for (int i = 1; i <= limit; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    public void PrintPyramid()
    {
        int rows = 5;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows - i - 1; j++)
            {
                Console.Write(" ");
            }
            for (int k = 0; k <= i; k++)
            {
                Console.Write("*");
            }
            for (int l = i - 1; l >= 0; l--)
            {
                Console.Write("*");
            }
            Console.WriteLine(); 
        }
    }

    public void GuessNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 4);
        Console.WriteLine("Guess a number between 1 and 3:");
        int guessedNumber = int.Parse(Console.ReadLine());

        if (guessedNumber == randomNumber)
        {
            Console.WriteLine("Your guess is correct!");
        }
        else if (guessedNumber < randomNumber)
        {
            Console.WriteLine("Your guess low.");
        }
        else
        {
            Console.WriteLine("Your guess high.");
        }
    }

    public void Greetings()
    {
        DateTime current = DateTime.Now;
        int currentHour = current.Hour;

        if (currentHour < 12)
        {
            Console.WriteLine("Good morning!");
        }

        if (currentHour >= 12 && currentHour < 18)
        {
            Console.WriteLine("Good afternoon!");
        }

        if (currentHour >= 18)
        {
            Console.WriteLine("Good evening!");
        }
    }

    public void Count24()
    {
        for (int increment = 1; increment <= 4; increment++)
        {
            for (int i = 0; i <= 23; i += increment)
            {
                Console.Write(i + ",");
            }
            Console.Write(24);
            Console.WriteLine();
        }
    }
}
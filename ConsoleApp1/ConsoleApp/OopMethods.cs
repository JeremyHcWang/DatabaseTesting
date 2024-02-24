namespace ConsoleApp1;

public static class OopMethods
{
    public static int[] GenerateNumbers(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }
    
    public static void Reverse(int[] array)
    {
        int left = 0;
        int right = array.Length - 1;
        while (left < right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            left++;
            right--;
        }
    }
    
    public static void PrintNumbers(int[] array)
    {
        Console.WriteLine("Reversed numbers:");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    } 
    
    public static int Fibonacci(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Input must be a positive integer.");
        }
        else if (n == 1 || n == 2)
        {
            return 1;
        }
        else
        {
            int a = 1, b = 1, c = 0;
            for (int i = 3; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}
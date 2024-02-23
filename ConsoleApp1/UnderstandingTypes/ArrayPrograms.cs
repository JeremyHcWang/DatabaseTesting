namespace ConsoleApp1;

public static class ArrayPrograms
{   
    public static void CopyArray()
    {
        int[] initArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] copyArray = new int[initArr.Length];

        for (int i = 0; i < initArr.Length; i++)
        {
            copyArray[i] = initArr[i];
        }

        Console.WriteLine("Original Array:");
        foreach (int num in initArr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine("\nCopied Array:");
        foreach (int num in copyArray)
        {
            Console.Write(num + " ");
        }
    }
    
    public static void ManageList()
    {
        List<string> itemList = new List<string>();

        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();

            if (input.StartsWith("+"))
            {
                string item = input.Substring(1);
                itemList.Add(item);
            }
            else if (input.StartsWith("-"))
            {
                string item = input.Substring(1);
                itemList.Remove(item);
            }
            else if (input == "--")
            {
                itemList.Clear();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
            
            Console.WriteLine("Current List:");
            foreach (string item in itemList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
    
    public static void RotateArray()
    {
        Console.WriteLine("Enter the array of integers (space-separated):");
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        Console.WriteLine("Enter the value of k:");
        int k = int.Parse(Console.ReadLine());
        int n = nums.Length;
        int[] sum = new int[n];
        
        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                rotatedArray[(i + r) % n] = nums[i];
            }
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotatedArray[i];
            }
        }
        
        Console.WriteLine("Sum of arrays after each rotation:");
        foreach (int s in sum)
        {
            Console.Write(s + " ");
        }
    }
    
    public static void Longest()
    {
        Console.WriteLine("Enter the array of integers (space-separated):");
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int maxLength = 1;  
        int start = 0;      
        int currentLength = 1; 
        int currentStart = 0;   
        
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                currentLength++;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    start = currentStart;
                }
            }
            else
            {
                currentLength = 1;
                currentStart = i;
            }
        }
        
        Console.WriteLine("Longest sequence of equal elements:");
        for (int i = start; i < start + maxLength; i++)
        {
            Console.Write(nums[i] + " ");
        }
    }
}
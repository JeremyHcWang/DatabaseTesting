namespace ConsoleApp1;
using System;
using System.Text;

public static class StringPrograms
{
    public static void ReverseString()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        
        string reversedString1 = ReverseString1(input);
        Console.WriteLine("Reversed string using char array:");
        Console.WriteLine(reversedString1);
        
        string reversedString2 = ReverseString2(input);
        Console.WriteLine("Reversed string using for-loop:");
        Console.WriteLine(reversedString2);
    }
    static string ReverseString1(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    
    static string ReverseString2(string input)
    {
        string reversedString = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedString += input[i];
        }
        return reversedString;
    }

    public static string ReverseWords(string sentence)
    {
        // Split the sentence into words using separators
        string[] words = sentence.Split(new char[] { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Split the sentence into separators
        string[] separators = sentence.Split(words, StringSplitOptions.RemoveEmptyEntries);

        // Reverse the words
        Array.Reverse(words);

        // Reconstruct the sentence with reversed words
        StringBuilder reversedSentence = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            reversedSentence.Append(words[i]);
            if (i < separators.Length)
            {
                reversedSentence.Append(separators[i]);
            }
        }

        return reversedSentence.ToString();
    }
    
    public static void ParseUrl(string url)
    {
        string[] parts = url.Split(new char[] { '/', ':' }, StringSplitOptions.RemoveEmptyEntries);
        string protocol = "";
        string server = "";
        string resource = "";

        if (parts.Length > 1 && parts[0].Contains('.'))
        {
            protocol = parts[0];
            server = parts[1];
            if (parts.Length > 2)
            {
                resource = string.Join("/", parts, 2, parts.Length - 2);
            }
        }
        else
        {
            server = parts[0];
            if (parts.Length > 1)
            {
                resource = string.Join("/", parts, 1, parts.Length - 1);
            }
        }

        Console.WriteLine($"URL: {url}");
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
        Console.WriteLine();
    }
}
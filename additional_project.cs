using System;

public class Add_project
{
    public int RomanToInt(string s)
    {
        int result = 0;
        string explanation = "";

        for (int i = 0; i < s.Length;)
        {
            if (i + 1 < s.Length && get_value(s[i]) < get_value(s[i + 1]))
            {
                result += get_value(s[i + 1]) - get_value(s[i]);
                explanation += $"{s[i]}{s[i + 1]} = {get_value(s[i + 1]) - get_value(s[i])}, ";
                i += 2;
            }
            else
            {
                result += get_value(s[i]);
                explanation += $"{s[i]} = {get_value(s[i])}, ";
                i++;
            }
        }
        explanation = explanation.Trim(' ', ',');

        if (result >= 4000)
        {
            Console.WriteLine("Диапазон [1, 3999]");
        }
        else
        {
            Console.WriteLine(result);

            if (s.Length > 1)
            {
                if (s.EndsWith("III"))
                {
                    explanation = explanation.Replace("I = 1,", "");
                    explanation = explanation.Replace("  I = 1", "");
                    Console.WriteLine(explanation + "III = 3");
                }
                else if (s.EndsWith("II"))
                {
                    explanation = explanation.Replace("I = 1,", "");
                    explanation = explanation.Replace(" I = 1", "");
                    Console.WriteLine(explanation + "II = 2");
                }
                else
                {
                    Console.WriteLine(explanation);
                }
            }
            else
            {
                Console.WriteLine($"{s} = {result}");
            }
        }

        return result;
    }

    private int get_value(char s)
    {
        switch (s)
        {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
            default:
                throw new ArgumentException("Этот символ отсутствует: " + s);
        }
    }

    public static void Main()
    {
        Console.Write("s = ");
        string user_input = Console.ReadLine();

        if (user_input.Length < 1 || user_input.Length > 15)
        {
            Console.WriteLine("Длина s вышла за ограничения");
        }
        else
        {
            Add_project solution = new Add_project();
            int result = solution.RomanToInt(user_input);
        }
    }
}
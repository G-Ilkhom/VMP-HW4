using System;

class Project3
{
    static bool check_brackets(string expression)
    {
        int count = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                count++;
            }
            else if (expression[i] == ')')
            {
                if (count == 0)
                {
                    Console.WriteLine($"нет\nЛишняя закрывающая скобка на позиции: {i + 1}");
                    return false;
                }
                count--;
            }
        }

        if (count > 0)
        {
            Console.WriteLine($"нет\nКоличество лишних открывающих скобок: {count}");
            return false;
        }

        return true;
    }
    static void Main()
    {
        string user_input = Console.ReadLine();
        if (check_brackets(user_input))
        {
            Console.WriteLine("да");
        }
    }
}
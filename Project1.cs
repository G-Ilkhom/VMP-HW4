using System;

namespace Project1
{
	public class Stack
	{
		int size_array;
		int[] array;
		int pointer;
		public Stack(int s)
		{
			size_array = s;
			array = new int[size_array];
			pointer = 0;
		}
		public void push(int num)
		{
			array[pointer++] = num;
			Console.WriteLine("ok");
		}
		public int pop()
		{
			return array[--pointer];
		}
		public int back()
		{
			return array[pointer - 1];
		}
		public int size()
		{
			return pointer;
		}
		public void clear()
		{
			pointer = 0;
			Console.WriteLine("ok");
		}
		public void exit()
		{
			Console.WriteLine("bye");
		}
	}

	class Project1
	{
		static void Main()
		{
			Stack stack = new Stack(100);

			while (true)
			{
				string user_input = Console.ReadLine();
				string num = "";
				string option = "";
				bool flag = false;
				int number = 0;
				for (int i = 0; i < user_input.Length; i++)
				{
					if (!flag && i == user_input.Length - 1)
					{
						option += user_input[i];
						break;
					}
					if (user_input[i] == ' ')
					{
						flag = true;
						continue;
					}
					if (!flag)
					{
						option += user_input[i];
					}
					else if (flag)
					{
						num += user_input[i];
					}
					if (i == user_input.Length - 1)
					{
						number = Convert.ToInt32(num);
					}
				}

				switch (option)
				{
					case "push":
						stack.push(number);
						break;
					case "pop":
						Console.WriteLine(stack.pop());
						break;
					case "back":
						Console.WriteLine(stack.back());
						break;
					case "size":
						Console.WriteLine(stack.size());
						break;
					case "clear":
						stack.clear();
						break;
					case "exit":
						stack.exit();
						return;
					default:
						Console.WriteLine("this command is missing");
						break;
				}
			}
		}
	}
}
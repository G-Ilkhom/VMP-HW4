using System;

namespace Project2
{
	public class Queue
	{
		int size_array;
		int[] array;
		int pointer;
		public Queue(int s)
		{
			size_array = s;
			array = new int[size_array];
			pointer = 0;
		}
		private void resize(int newSize)
		{
			int[] newArray = new int[newSize];
			for (int i = 0; i < pointer; i++)
				newArray[i] = array[i];
			array = newArray;
			size_array = newSize;
		}
		public void push(int num)
		{
			if (pointer + 1 == array.Length)
			{
				resize(size_array * 2);
			}
			array[pointer++] = num;
		}
		public object pop()
		{
			if (pointer == 0)
				return "error";
			int result = array[0];
			for (int i = 0; i < pointer; i++)
				array[i] = array[i + 1];
			pointer--;
			return result;
		}
		public object front()
		{
			if (pointer == 0)
				return "error";
			return array[0];
		}
		public int size()
		{
			return pointer;
		}
		public void clear()
		{
			pointer = 0;
		}
		public void exit()
		{
			Console.WriteLine("bye");
		}
	}
	class Project2
	{
		static void Main()
		{
			Queue queue = new Queue(3);

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
						queue.push(number);
						break;
					case "pop":
						Console.WriteLine(queue.pop());
						break;
					case "front":
						Console.WriteLine(queue.front());
						break;
					case "size":
						Console.WriteLine(queue.size());
						break;
					case "clear":
						queue.clear();
						break;
					case "exit":
						queue.exit();
						return;
					default:
						Console.WriteLine("this command is missing");
						break;
				}
			}
		}
	}
}
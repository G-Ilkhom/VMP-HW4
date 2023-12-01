using System;


public class DoublyNode<T>
{
	public DoublyNode(T data)
    {
		Data = data;
    }
	public T Data { get; set; }
	public DoublyNode<T> Previous { get; set; }
	public DoublyNode<T> Next { get; set; }
}

public class Deque<T>
{
	private DoublyNode<T> head;
	private DoublyNode<T> tail;
	public Deque(T inputData)
	{
		DoublyNode<T> node = new DoublyNode<T>(inputData);
		head = node;
		tail = node;
	}

	public string Find(T findData)
	{
		DoublyNode<T> i = head;
		string res = $"Номера позиций элемента {findData}: ";
		int index = 1;
		while (i != null)
		{
			if (i.Data.Equals(findData))
				res += index + " ";
			index++;
			i = i.Next;
		}
		return res;
	}

	public void AddFirst(T inputData)
	{
		DoublyNode<T> node = new DoublyNode<T>(inputData);
		node.Next = head;
		head.Previous = node;
		head = node;
	}

	public void AddLast(T inputData)
	{
		DoublyNode<T> node = new DoublyNode<T>(inputData);
		node.Previous = tail;
		tail.Next = node;
		tail = node;
	}

	public void RemoveByData(T deleteData)
	{
		for (DoublyNode<T> i = head; i != null; i = i.Next)
		{
			if (i.Data.Equals(deleteData))
			{
				if (i != head && i != tail)
				{
					i.Previous.Next = i.Next;
					i.Next.Previous = i.Previous;
				}
				else if (i == head)
				{
					RemoveFirst();
				}
				else if (i == tail)
				{
					RemoveLast();
				}
			}
		}
	}

	public void RemoveFirst()
	{
		head.Next.Previous = null;
		head = head.Next;
	}

	public void RemoveLast()
	{
		tail.Previous.Next = null;
		tail = tail.Previous;
	}

	public void Print() 
	{
		DoublyNode<T> i = head; 
		while (i != null) 
		{
			Console.Write($"{i.Data} ");
			i = i.Next; 
		} 
		Console.WriteLine(); 
	}
}

internal class Program4
{
	static int Main(string[] args)
	{
		Deque<int> deque = new Deque<int>(7);
		deque.AddFirst(3);
		deque.AddFirst(4);
		deque.AddLast(7);
		deque.AddLast(6);
		deque.AddFirst(8);
		deque.Print();
		deque.RemoveFirst();
		deque.RemoveLast();
		deque.Print();
		Console.WriteLine(deque.Find(3));
		deque.RemoveByData(7);
		deque.Print();
		deque.RemoveFirst();
		deque.Print();
		return 0;
	}
}
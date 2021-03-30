using System;

namespace genericList
{
	public class Node<T>
	{
		public Node<T> Next { get; set; } //下一个对象
		public T Data { get; set; }             //Data是T类数据

		public Node(T t)      
		{
			Next = null;
			Data = t;
		}
	}
}
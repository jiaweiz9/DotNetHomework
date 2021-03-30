using System;
namespace genericList
{
	public class GenericList<T> 
{
	private Node<T> head;
		private Node<T> tail;

		public GenericList()
        {
			tail = head = null;
        }
		public Node<T> Head { get => head; }
		public void Add(T t)
        {
			Node<T> n = new Node<T>(t);
			if(tail == null)
            {
				head = tail = n;
            }
            else
            {
				tail.Next = n;
				tail = n;
            }
        }
		public void ForEach(Action<T> action)
    {
		Node<T> p = head;
			for(; p.Next != null; p = p.Next)
			{ action(p.Data);
				Console.Write(p.Data+" ");
			}
    }

}
}

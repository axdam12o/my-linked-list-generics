using System.Text;

namespace MyLinkedListApp;

public class MyLinkedList<T>
{
    

    private Node<T> Head { get; set; }
    private Node<T> Tail { get; set; }

    public int Count
    {
        get
        {
            int cnt = 0;

            for (Node<T> node = Head; node != null; node = node.Next)
            {
                cnt++;
            }

            return cnt;
        }
    }

    public void AddAtStart(T data)
    {
        InsertAt(0, data);
    }

    public void AddAtEnd(T data)
    {
        InsertAt(Count, data);
    }

    public void InsertAt(int index, T data)
    {
        int count = Count;

        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node<T> newNode = new Node<T>(data);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        if (index == 0)
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
            return;
        }

        if (index == count)
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            return;
        }

        Node<T> current = GetNodeAt(index);

        newNode.Prev = current.Prev;
        newNode.Next = current;
        current.Prev.Next = newNode;
        current.Prev = newNode;
    }

    private Node<T> GetNodeAt(int index)
    {
        Node<T> current = Head;

        for (int i = 0; i < index && current != null; i++)
        {
            current = current.Next;
        }

        if (current == null)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return current;
    }

    #region ToString
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (Node node = Head; node != null; node = node.Next)
        {
            sb.AppendLine(node.Data.ToString());
        }
        return sb.ToString();
    }
    
    #endregion
}
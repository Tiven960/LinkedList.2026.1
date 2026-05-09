namespace double_list;

public class Node<T>
{
    public Node(T? data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
    public T? Data { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Prev { get; set; }   // Point to the previous node

}

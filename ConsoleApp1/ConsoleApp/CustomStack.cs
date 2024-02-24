namespace ConsoleApp1;

public class CustomStack<T>
{
    private List<T> items;

    public CustomStack()
    {
        items = new List<T>();
    }
    
    public int Count()
    {
        return items.Count;
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        T poppedItem = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return poppedItem;
    }
    
    public void Push(T item)
    {
        items.Add(item);
    }
}
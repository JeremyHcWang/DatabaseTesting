public class GenericList<T>
{
    private List<T> items;

    public GenericList()
    {
        items = new List<T>();
    }
    
    public void Add(T element)
    {
        items.Add(element);
    }
    
    public T Remove(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        T removedItem = items[index];
        items.RemoveAt(index);
        return removedItem;
    }
    
    public bool Contains(T element)
    {
        return items.Contains(element);
    }
    
    public void Clear()
    {
        items.Clear();
    }
    
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > items.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        items.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        items.RemoveAt(index);
    }
    
    public T Find(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        return items[index];
    }
}
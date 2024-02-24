// Define IEntity interface representing an entity with an Id property
public interface IEntity
{
    int Id { get; set; }
}

// Define IRepository<T> interface with CRUD operations
public interface IRepository<T> where T : IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

// Implement GenericRepository<T> class
public class GenericRepository<T> : IRepository<T> where T : class, IEntity
{
    private List<T> items;

    public GenericRepository()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        items.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        items.Remove(item);
    }

    public void Save()
    {
        // In a real implementation, you would save changes to the data source (e.g., database)
        Console.WriteLine("Changes saved successfully.");
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }

    public T GetById(int id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }
}

// Example entity class
public class Entity : IEntity
{
    public int Id { get; set; }
    // Additional properties...
}
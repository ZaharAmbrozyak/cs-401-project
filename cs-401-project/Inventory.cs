namespace cs_401_project;

public class Inventory<T> where T : Item
{
    private List<T> _inventory = [];

    public double MaxWeight
    {
        get;
        set
        {
            if (MaxWeight < 0)
            {
                throw new ArgumentException("Inventory weight should be positive!");
            }

            field = value;
        }
    }

    public Inventory(double maxWeight)
    {
        MaxWeight = maxWeight;
    }

    public void Add(T item)
    {
        _inventory.Add(item);
    }

    public void Remove(T item)
    {
        
    }

    public T GetByName(string name)
    {
        throw new NotImplementedException();
    }
}
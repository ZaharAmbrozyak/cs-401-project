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
        if (_inventory.Count < MaxWeight)
        {
            _inventory.Add(item);
        }
        else
        {
            throw new ArgumentException("Cannot add this item: inventory is full!");
        }
        
    }

    public void Remove(T item)
    {
        
    }

    public T GetByName(string name)
    {
        throw new NotImplementedException();
    }
}
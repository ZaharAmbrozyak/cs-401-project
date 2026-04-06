using System.Collections;

namespace cs_401_project;

public class Inventory<T> : IEnumerable<T> where T : Item
{
    private List<T> _inventory = [];
    
    public double InventoryWeight
    {
        get
        {
            var inventoryWeight = 0.0;
            foreach (var item in _inventory)
            {
                inventoryWeight += item.Weight;
            }

            return inventoryWeight;
        }
    }
    
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
        if (InventoryWeight + item.Weight > MaxWeight)
        {
            throw new ArgumentException("Cannot add this item: inventory is full!");
        }
        _inventory.Add(item);
        
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _inventory.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public void Remove(T item)
    {
        foreach (var inventoryItem in _inventory)
        {
            if (item.Equals(inventoryItem))
            {
                _inventory.Remove(item);
                return;
            }
        }
    }

    public T? GetByName(string name)
    {
        foreach (var item in _inventory)
        {
            if (item.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }

        return null;
    }

    public void SortByRarity()
    {
        _inventory.Sort();
    }

    public void PrintInventory()
    {
        foreach (var item in _inventory)
        {
            Console.WriteLine($"{item.Name}: {item.GetRarity()}");
        }
    }
}
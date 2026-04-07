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
            if (value < 0)
            {
                throw new ArgumentException("Місткість інвентаря має бути невід'ємним числом!");
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
            Console.WriteLine("Неможливо додати цей предмет: інвентар переповнений!");
            return;
        }
        _inventory.Add(item);
        
        Console.WriteLine("Предмет додано в інвентар.");
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
                Console.WriteLine("Предмет видалено з інвентаря.");
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

    public void Print()
    {
        if (_inventory.Count == 0)
        {
            Console.WriteLine("Тут порожньо!");
        }
        for (var i = 0; i < _inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_inventory[i].GetInfo()}");
        }
        Console.WriteLine($"Вага: {InventoryWeight} / {MaxWeight}");
    }
}
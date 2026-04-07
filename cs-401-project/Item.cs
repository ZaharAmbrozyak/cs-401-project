using System.Reflection.Metadata;

namespace cs_401_project;

public abstract class Item : IComparable<Item>
{
    public string Id
    {
        get;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Id cannot be empty!");
            }

            field = value;
        }
    }
    
    public string Name
    {
        get;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Item name cannot be empty!");
            }

            field = value;
        }
    }

    public double Weight
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Item weight cannot be empty!");
            }

            field = value;
        }
    }

    private Rarity _rarity;

    public Item(string id, string name, double weight, Rarity rarity)
    {
        Id = id;
        Name = name;
        Weight = weight;
        _rarity = rarity;
    }
    public abstract void Use(Hero hero);

    public string GetRarity()
    {
        return _rarity switch
        {
            Rarity.Common => "Common",
            Rarity.Rare => "Rare",
            Rarity.Epic => "Epic",
            Rarity.Legendary => "Legendary",
            _ => "Unknown"
        };
    }


    public virtual string GetInfo()
    {
        return $"[{GetRarity()}] {Name} (вага: {Weight})";
    }
    public int CompareTo(Item? other)
    {
        if (other == null)
        {
            return 1;
        }

        return this._rarity.CompareTo(other._rarity);
    }
}
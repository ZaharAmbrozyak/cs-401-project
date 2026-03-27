using System.Reflection.Metadata;

namespace cs_401_project;

public abstract class Item
{
    public string Name
    {
        get;
        set
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

    private Rarity rarity;

    public abstract void Use(Hero hero);
}
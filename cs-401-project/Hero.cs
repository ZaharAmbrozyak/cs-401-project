namespace cs_401_project;

public class Hero
{
    public string Tag
    {
        get;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Tag cannot be empty!");
            }

            if (value.Length != 4)
            {
                throw new ArgumentException("Tag size should be exactly 4 characters!");
            }

            field = value;
        }
    }
    public string Name
    {
        get;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Hero name cannot be empty!");
            }

            field = value;
        }
    }

    public int Level
    {
        get;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hero level should be positive!");
            }
        }
    }

    public double MaxHp
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Max hp should be positive!");
            }

            field = value;
        }
    }
    
    public double CurrentHp
    {
        get;
        set
        {
            if (value < 0)
            {
                field = 0;
            }
            else if (value + CurrentHp > MaxHp)
            {
                field = MaxHp;
            }
            
            field = value;
        }
    }

    public Armor CurrentArmor { get; set; }
    public Weapon CurrentWeapon { get; set; }
    public double ArmorAmount => CurrentArmor.ArmorAmount;
    public double DamageAmount => CurrentWeapon.DamageAmount;
    public string Nickname => Name + "#" + Tag;
    
    private Inventory<Item> _inventory = new(10);
    
    public Hero(string name, string tag = "0000")
    {
        Name = name;
        Tag = tag;
        Level = 0;
        MaxHp = 100;
        CurrentArmor = (Armor)Items.AllItems["shirt_1"];
        CurrentWeapon = (Weapon)Items.AllItems["heavy_branch"];

    }
    
    public string GetStats()
    {
        return $"{Nickname}: Lvl {Level},  Armor {ArmorAmount}, Damage {DamageAmount}";
    }

    public void PrintStats()
    {
        Console.WriteLine(GetStats());
    }
    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _inventory.Remove(item);
    }

    public void SortInventory()
    {
        _inventory.SortByRarity();
    }

    public void PrintInventory()
    {
        Console.WriteLine($"Інвентар героя {Name} (HP: {CurrentHp}, ATK: {DamageAmount}), DEF: {ArmorAmount}");
        _inventory.Print();
    }
    
}
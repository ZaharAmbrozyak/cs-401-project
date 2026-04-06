namespace cs_401_project;

public class Potion : Item
{
    public double HealAmount
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Potion heal should be positive!");
            }

            field = value;
        }
    }
    
    public Potion(string name, double weight, Rarity rarity, double healAmount) : base(name, weight, rarity)
    {
        HealAmount = healAmount;
    }

    public override void Use(Hero hero)
    {
        var previousHp = hero.CurrentHp;
        hero.CurrentHp += HealAmount;
        Console.WriteLine($"{hero.Name} used {Name}. HP: {previousHp} -> {hero.CurrentHp + HealAmount}");
    }
}
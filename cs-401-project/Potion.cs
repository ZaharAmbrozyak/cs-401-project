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
                throw new ArgumentException("Показник відновлення має бути не від'ємним!");
            }

            field = value;
        }
    }
    
    public Potion(string id, string name, double weight, Rarity rarity, double healAmount) : base(id, name, weight, rarity)
    {
        HealAmount = healAmount;
    }
    
    public override string GetInfo()
    {
        return $"[{GetRarity()}] {Name} (вага: {Weight}, +{HealAmount} HP)";
    }
    
    public override void Use(Hero hero)
    {
        var previousHp = hero.CurrentHp;
        hero.CurrentHp += HealAmount;

        var difference = hero.CurrentHp - previousHp;
        
        Console.WriteLine($"{hero.Name} випив {Name}. HP: {previousHp} -> {hero.CurrentHp} (зміна {difference})");
        hero.RemoveItem(this);
    }
}
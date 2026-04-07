namespace cs_401_project;

public class Armor : Item
{
    public double ArmorAmount
    {
        get;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Armor amount should be positive!");
            }

            field = value;
        }
    }
    public Armor(string id, string name, double weight, Rarity rarity, double armorAmount) : base(id, name, weight, rarity)
    {
        ArmorAmount = armorAmount;
    }

    public override string GetInfo()
    {
        return $"[{GetRarity()}] {Name} (вага: {Weight}, захист: +{ArmorAmount})";
    }
    
    public override void Use(Hero hero)
    {
        var previousArmor = hero.ArmorAmount;
        hero.CurrentArmor = this;
        var difference = ArmorAmount - previousArmor;
        var sign = string.Empty;
        if (difference > 0)
        {
            sign = "+";
        }

        Console.WriteLine($"{hero.Name} одягнув {Name}. DEF: {previousArmor} -> {ArmorAmount} (зміна {sign}{difference})");
    }
}
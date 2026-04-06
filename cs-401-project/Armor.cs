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
    public Armor(string name, double weight, Rarity rarity, double armorAmount) : base(name, weight, rarity)
    {
        ArmorAmount = armorAmount;
    }

    public override string GetInfo()
    {
        return $"[{GetRarity()}] {Name} (вага: {Weight}, захист: +{ArmorAmount})";
    }
    
    public override void Use(Hero hero)
    {
        hero.CurrentArmor = this;
    }
}
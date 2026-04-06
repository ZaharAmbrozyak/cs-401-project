namespace cs_401_project;

public class Weapon : Item
{
    public double DamageAmount
    {
        get;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Damage should be positive!");
            }

            field = value;
        }
    }
    public Weapon(string name, double weight, Rarity rarity, double damageAmount) : base(name, weight, rarity)
    {
        DamageAmount = damageAmount;
    }

    public override string GetInfo()
    {
        return $"[{GetRarity()}] {Name} (вага: {Weight}, атака: +{DamageAmount})";
    }

    public override void Use(Hero hero)
    {
        hero.CurrentWeapon = this;
    }
}
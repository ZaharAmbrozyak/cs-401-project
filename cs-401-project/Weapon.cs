namespace cs_401_project;

public class Weapon : Item
{
    public Weapon(string name, double weight, Rarity rarity) : base(name, weight, rarity)
    {
        
    }

    public override void Use(Hero hero)
    {
        throw new NotImplementedException();
    }
}
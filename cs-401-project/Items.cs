namespace cs_401_project;

public static class Items
{
    public static Dictionary<string, Item> AllItems = new()
    {
        {"shirt_1", new Armor("shirt_1", "Біла сорочка", 0.2, Rarity.Common, 0.0)},
        {"leather_armor_1", new Armor("leather_armor_1", "Легкі шкіряні обладунки", 1.0, Rarity.Common, 10)},
        {"leather_armor_2", new Armor("leather_armor_2", "Шкіряні обладунки гільдії", 1.5, Rarity.Rare, 20)},
        
        {"heavy_branch", new Weapon("heavy_branch", "Важка палиця", 3.0, Rarity.Common, 10)},
        {"rusty_sword", new Weapon("rusty_sword", "Ржавий меч", 10.0, Rarity.Common, 15)},
        {"basic_sword_1", new Weapon("basic_sword_1", "Стандартний меч", 10.0, Rarity.Common, 20)},
        
        {"potion_1", new Potion("potion_1", "Мале зілля здоров'я", 3.0, Rarity.Common, 25)},
        {"potion_2", new Potion("potion_2", "Зілля здоров'я", 4.0, Rarity.Common, 50)},
        {"potion_3", new Potion("potion_3", "Велике зілля здоров'я", 4.0, Rarity.Common, 100)},
    };
}
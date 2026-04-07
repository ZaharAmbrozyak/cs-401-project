namespace cs_401_project;

public class Menu
{

    public void Run(Hero hero)
    {
        Console.WriteLine("Меню героя. Команди:");
        Console.WriteLine("1. Показати інвентар");
        Console.WriteLine("""2. Додати "[предмет]" (до інвентаря) """);
        Console.WriteLine("""3. Використати "[предмет]" (за назвою)""");
        Console.WriteLine("4. Відсортувати інвентар (за рідкістю)");
        Console.WriteLine("5. Показати характеристики (героя)");
        while (true)
        {
            Console.Write("> ");
            var heroInput = Console.ReadLine();

            if (string.IsNullOrEmpty(heroInput))
            {
                Console.WriteLine("Команду не знайдено");
                continue;
            }

            var spaceIndex = heroInput.IndexOf(' ');
            if (spaceIndex == -1)
            {
                if (heroInput == "Вийти")
                {
                    Console.WriteLine("Вихід з меню");
                    return;
                }
                Console.WriteLine($"Невідома команда: {heroInput}");
                continue;
            }
            
            
            var command = heroInput.Substring(0, spaceIndex).Trim();
            var argument = heroInput.Substring(spaceIndex + 1).Trim();
            
            switch (command.ToLower())
            {
                case "показати":
                    switch (argument.ToLower())
                    {
                        case "інвентар":
                            hero.PrintInventory();
                            break;
                        case "характеристики":
                            hero.PrintStats();
                            break;
                        default:
                            Console.WriteLine("Невідомий аргумент: " + argument);
                            break;
                    }
                    break;
                case "відсортувати":
                    switch (argument)
                    {
                        case "інвентар":
                            hero.SortInventory();
                            break;
                        default:
                            Console.WriteLine("Невідомий аргумент: " + argument);
                            break;
                    }
                    break;
                case "додати":
                    if (!argument.StartsWith('"') || !argument.EndsWith('"'))
                    {
                        Console.WriteLine($"""Очікувано "[name]" але отримано {argument}""");
                        continue;
                    }
                    
                    var itemName = argument.Substring(1, argument.Length - 2);
                    var item = Items.GetByName(itemName);
                    if (item == null)
                    {
                        Console.WriteLine($"Невідомий предмет: {itemName}");
                        continue;
                    }
                    hero.AddItem(item);
                    
                    break;
                case "використати":
                    if (!argument.StartsWith('"') || !argument.EndsWith('"'))
                    {
                        Console.WriteLine($"""Очікувано "[name]" але отримано {argument}""");
                        continue;
                    }
                    var name = argument.Substring(1, argument.Length - 2);
                    hero.UseItem(name);
                    break;
                default:
                    Console.WriteLine("Невідома команда: " + argument);
                    break;
            }
        }
    }
}
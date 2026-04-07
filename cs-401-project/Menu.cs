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
            var tokens = heroInput.Split();
            if (tokens.Length != 2)
            {
                throw new ArgumentException("Неправильна команда!");
            }
            var (command, argument) = (tokens[0], tokens[1]);
            
            switch (command)
            {
                case "Показати":
                    switch (argument)
                    {
                        case "інвентар":
                            hero.PrintInventory();
                            break;
                        case "характеристики":
                            hero.PrintStats();
                            break;
                        default:
                            throw new ArgumentException("Невідомий аргумент: " + argument);
                    }
                    break;
                case "Відсортувати":
                    switch (argument)
                    {
                        case "інвентар":
                            hero.SortInventory();
                            break;
                        default:
                            throw new ArgumentException("Невідомий аргумент: " + argument);
                    }

                    break;
                case "Додати":
                    if (argument[0] != '"' || argument[^1] != '"')
                    {
                        throw new ArgumentException($"""Expected "[name]" but got {argument}""");
                    }
                    
                    var name = argument.Substring(1, argument.Length - 2);
                    break;
                default:
                    throw new ArgumentException("Невідома команда: " + argument);
            }
        }
    }
}
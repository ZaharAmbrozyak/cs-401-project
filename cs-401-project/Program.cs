namespace cs_401_project;

class Program
{
    static void Main(string[] args)
    {
        var myHero = new Hero("Funyusha", "6479");
        var menu = new Menu();
        menu.Run(myHero);
    }
}
using Models;
using SpaceInvadersArmory;

namespace TP1;

public class SpaceInvaders
{
    private readonly List<Player> players = new List<Player>();
    private readonly Armory armory;

    public SpaceInvaders()
    {
        armory = new Armory();
        init();
    }

    static void Main(string[] args)
    {
        SpaceInvaders game = new SpaceInvaders();
        game.Run();
    }

    private void init()
    {
        players.Add(new Player("bertin","oce","oce"));
        players.Add(new Player("toussaint","jeans matth","jm"));
        players.Add(new Player("chapuis","maxime","max"));
    }

    private void Run()
    {
        foreach (var player in players)
        {
            Console.WriteLine(player.ToString());
        }
        Console.WriteLine();

        armory.ViewArmory();
        Console.WriteLine();

        Spaceship ship = players[0].BattleShip;
        ship.AddWeapon(armory.Weapons[0]);
        ship.AddWeapon(armory.Weapons[1]);
        ship.ViewShip();
        Console.WriteLine();

        try
        {
            ship.AddWeapon(armory.Weapons[2]);
            ship.AddWeapon(armory.Weapons[0]);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Erreur : {e.Message}");
        }
    }
}

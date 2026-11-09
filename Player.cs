namespace Models;

public class Player
{
    private readonly string FirstName;
    private readonly string LastName;
    private string Alias;
    public Spaceship BattleShip { get; }
    public Player(string firstName, string lastName, string alias)
    {
        FirstName = firstName;
        LastName = lastName;
        Alias = alias;
        BattleShip = new Spaceship("ViperMKII ", 10, 15);
    }

    public override string ToString()
    {
        return $"{Alias} ({FirstName} {LastName})";
    }

    public override bool Equals(object? obj)
    {
        return obj is Player other && Alias == other.Alias;
    }

    public override int GetHashCode()
    {
        return Alias.GetHashCode();
    }
}

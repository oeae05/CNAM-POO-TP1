using SpaceInvadersArmory;

namespace Models;

public class Spaceship : ISpaceship
{
    public string Name { get; }
    public double MaxStructure { get; }
    public double MaxShield { get; }

    public double CurrentStructure { get; private set; }
    public double CurrentShield { get; private set; }

    public bool IsDestroyed => CurrentStructure <= 0;

    private readonly List<Weapon> weapons = new List<Weapon>();
    public IReadOnlyList<Weapon> Weapons => weapons;
    public int MaxWeapons { get; } = 3;
    public double AverageDamages
    {
        get
        {
            double total = 0;
            foreach (Weapon weapon in weapons)
            {
                total += weapon.AverageDamage;
            }
            return total;
        }
    }

    public Spaceship(string name, double maxStructure, double maxShield)
    {
        Name = name;
        MaxStructure = maxStructure;
        MaxShield = maxShield;
        CurrentStructure = maxStructure;
        CurrentShield = maxShield;
    }

    public void AddWeapon(Weapon weapon)
    {
        if (weapons.Count >= MaxWeapons)
        {
            throw new InvalidOperationException($"Le vaisseau {Name} ne peut pas porter plus de {MaxWeapons} armes.");
        }
        weapons.Add(weapon);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if (weapons.Contains(weapon))
        {
            weapons.Remove(weapon);
        }
    }


    public void ClearWeapons()
    {
        weapons.Clear();
    }

    public void ViewWeapons()
    {
        foreach (var weapon in weapons)
        {
            Console.WriteLine(weapon.ToString());
        }
    }
    
    public void ViewShip()
    {
        Console.WriteLine($"=== {Name} ===");
        Console.WriteLine($"Structure : {CurrentStructure} / {MaxStructure}");
        Console.WriteLine($"Bouclier  : {CurrentShield} / {MaxShield}");
        Console.WriteLine($"Armes ({weapons.Count} / {MaxWeapons}) :");
        ViewWeapons();
        Console.WriteLine($"Dégâts moyens : {AverageDamages}");
    }
    

}

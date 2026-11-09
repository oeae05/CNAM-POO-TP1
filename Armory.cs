namespace SpaceInvadersArmory;

public class Armory
{
    private readonly List<Weapon> weapons = new List<Weapon>();

    public IReadOnlyList<Weapon> Weapons => weapons;

    public Armory()
    {
        Init();
    }

    private void Init()
    {
        weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
        weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 2));
        weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
        weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
        weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 2));
        weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public bool RemoveWeapon(Weapon weapon)
    {
        return weapons.Remove(weapon);
    }

    public bool Contains(Weapon weapon)
    {
        return weapons.Contains(weapon);
    }

    public void ViewArmory()
    {
        Console.WriteLine($"Armurerie ({weapons.Count} armes) :");
        foreach (Weapon weapon in weapons)
        {
            Console.WriteLine($"  - {weapon}");
        }
    }
}

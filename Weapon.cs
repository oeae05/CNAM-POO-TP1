namespace SpaceInvadersArmory;

public class Weapon : IWeapon
{
    private static readonly Random random = new Random();

    public string Name { get; }
    public double MinDamage { get; }
    public double MaxDamage { get; }
    public EWeaponType Type { get; }
    public int ReloadTime { get; }
    public int TimeBeforeReload { get; private set; }

    public bool IsReady => TimeBeforeReload == 0;

    public double AverageDamage => (MinDamage + MaxDamage) / 2;

    public Weapon(string name, double minDamage, double maxDamage, EWeaponType type, int reloadTime)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Type = type;
        // Une arme explosive met deux fois plus de temps à recharger
        ReloadTime = type == EWeaponType.Explosive ? reloadTime * 2 : reloadTime;
        TimeBeforeReload = ReloadTime;
    }

    public void DecrementReload()
    {
        if (TimeBeforeReload > 0)
        {
            TimeBeforeReload--;
        }
    }

    public double Shoot()
    {
        if (!IsReady)
        {
            return 0;
        }

        // Après un tir, l'arme doit recharger
        TimeBeforeReload = ReloadTime;

        switch (Type)
        {
            case EWeaponType.Direct:
                // 1 chance sur 10 de rater
                if (random.Next(10) == 0)
                {
                    return 0;
                }
                return RandomDamage();

            case EWeaponType.Explosive:
                // 1 chance sur 4 de rater, dégâts doublés sinon
                if (random.Next(4) == 0)
                {
                    return 0;
                }
                return RandomDamage() * 2;

            case EWeaponType.Guided:
                // Touche toujours, avec les dégâts minimums
                return MinDamage;

            default:
                return 0;
        }
    }

    private double RandomDamage()
    {
        return MinDamage + random.NextDouble() * (MaxDamage - MinDamage);
    }

    public override string ToString()
    {
        return $"{Name} ({Type}) : {MinDamage} - {MaxDamage} dégâts (moy. {AverageDamage}), recharge {ReloadTime} tour(s)";
    }
}

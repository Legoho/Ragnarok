using UnityEngine;
public enum DamageType
{
    // Physical
    Bludgeoning,
    Piercing,
    Slashing,

    // Energy
    Acid,
    Cold,
    Electricity,
    Fire,
    Sonic,

    // Other
    Force,
    NegativeEnergy, // For inflict spells, etc.
    PositiveEnergy, // For cure spells, etc.
    Nonlethal,
    Precision      // Sneak attack, etc.

}

[System.Serializable]
public class Damage 
{
    public DamageType damageType;
    public int damageDie; // e.g., 6 for 1d6
    public int damageDieCount; // e.g., 1 for 1d6, 2 for 2d6
    public int bonusDamage; // e.g., +2 for 1d6+2
    public int CriticalMultiplier = 2; // e.g., 2 for x2, 3 for x3
    public int CriticalThreshold = 20; // e.g., 20 for crit on 20, 19-20 for crit on 19-20
}

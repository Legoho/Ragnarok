using UnityEngine;
public enum AttackType
{
    Melee,
    Ranged,
    AltMelee,
    AltRanged,
    Custom
}

public enum DrBypass
{
    Chaotic,
    Evil,
    Good,
    Lawful,
    Magic,          // For DR/magic
    Silver,
    ColdIron,
    Adamantine
}

    [System.Serializable]
public class Attack
{
    public string attackName;
    public AttackType attackType;
    public Damage[] damages;

}

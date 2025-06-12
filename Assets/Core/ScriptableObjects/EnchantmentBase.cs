using UnityEngine;

public enum EnchantmentType
{
    Enhancement,   // e.g., +1, +2, etc.
    SpecialAbility, // e.g., Flaming, Frost, Keen
    Cursed,
    Custom
}

[CreateAssetMenu(menuName = "Ragnarok/Enchantment")]
public class EnchantmentBase : ScriptableObject
{
    public string enchantmentName;
    [TextArea]
    public string description;
    public EnchantmentType enchantmentType;
    public int bonusValue; // e.g., +1 for enhancement, or 0 if not applicable

    // Example: for special abilities, you might want to specify the effect
    public string effectSummary; // e.g., "Adds 1d6 fire damage on hit"

    // You can extend this with more fields as needed, such as:
    // public DamageType additionalDamageType;
    // public int additionalDamageDice;
    // public bool isStackable;
}

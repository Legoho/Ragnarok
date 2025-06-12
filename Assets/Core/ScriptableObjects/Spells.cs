using UnityEngine;

public enum SpellSchool
{
    Abjuration,
    Conjuration,
    Divination,
    Enchantment,
    Evocation,
    Illusion,
    Necromancy,
    Transmutation,
    Universal
}

public enum SpellComponent
{
    Verbal,
    Somatic,
    Material,
    Focus,
    DivineFocus
}
[CreateAssetMenu(menuName = "Ragnarok/Spells")]
public class Spells : ScriptableObject
{
    public string spellName;
    [TextArea]
    public string description;
    public int level; // Spell level (0-9)
    public SpellSchool school;
    public SpellComponent[] components;
    public string castingTime;
    public string range;
    public string target; // or "Area" or "Effect"
    public string duration;
    public string savingThrow; // e.g., "Will negates"
    public bool spellResistance;
    public Sprite icon; // Optional: for UI

    // You can add more fields as needed, 
}

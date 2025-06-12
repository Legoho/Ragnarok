using UnityEngine;

public enum baseAttackBonus
{
    Full=4, // +1 per level
    ThreeQuarters=3, // +0.75 per level
    Half=2, // +0.5 per level
    None=0 // No BAB progression
}
public enum Savebonus
{
    Good = 2, //  per level
    Poor = 3 // 1/3 per level
}
public enum SpellLearningType
{
    Spontaneous, // e.g., Sorcerer
    Prepared // e.g., Wizard
}
public enum SpellCastingAbility
{
    Intelligence, // e.g., Wizard
    Wisdom, // e.g., Cleric
    Charisma // e.g., Sorcerer
}

public enum SpellSelectionType
{
    Known, // e.g., Sorcerer
    Prepared, // e.g., Wizard
    Automatic, // e.g., Cleric with domain spells
    AllSpells // e.g., Druid
}


[CreateAssetMenu(menuName = "Ragnarok/Class")]
public class ClassBase : ScriptableObject
{
    public string className;
    [TextArea]
    public string description;
    public int hitDie; // e.g., 8 for d8
    public int[] skillRanksPerLevel; // e.g., [2] for 2+INT
    public Skills[] classSkills;
    public Abilities[] classFeatures; // Base class features
    public baseAttackBonus baseAttackBonusPerLevel; // BAB progression per level
    public int[,] SpellsPerDay; // Number of spells per day per level, e.g., [level, spellLevel] = number of spells
    public Spells[] spellsKnown; // Array of spells known by the class
    public Savebonus fortitudeSave; // Fortitude save progression
    public Savebonus reflexSave; // Reflex save progression
    public Savebonus willSave; // Will save progression
    // Add more fields as needed (BAB progression, saves, spellcasting, etc.)
}

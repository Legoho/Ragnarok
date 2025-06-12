using UnityEngine;

public enum CreatureSize
{
    Fine=8,
    Diminutive=6,
    Tiny =4,
    Small=2,
    Medium=0,
    Large=-2,
    Huge=-4,
    Gargantuan=-8,
    Colossal=-10
}
public enum Senses
{
    Normal,
    LowLightVision,
    Darkvision,
    Blindsight,
    Tremorsense,
    Truesight
}
public enum movementType
{
    Walk,
    Fly,
    Swim,
    Climb,
    Burrow
}
public enum Skills
{
    Acrobatics,
    Appraise,
    Bluff,
    Climb,
    Diplomacy,
    DisableDevice,
    Disguise,
    EscapeArtist,
    Fly,
    HandleAnimal,
    Heal,
    Intimidate,
    KnowledgeArcana,
    KnowledgeDungeoneering,
    KnowledgeEngineering,
    KnowledgeGeography,
    KnowledgeHistory,
    KnowledgeLocal,
    KnowledgeNature,
    KnowledgeNobility,
    KnowledgePlanes,
    KnowledgeReligion,
    Linguistics,
    Perception,
    Perform,
    Profession,
    Ride,
    SenseMotive,
    SleightOfHand,
    Spellcraft,
    Stealth,
    Survival,
    Swim
}
public enum Alignment
{
    LawfulGood,
    NeutralGood,
    ChaoticGood,
    LawfulNeutral,
    TrueNeutral,
    ChaoticNeutral,
    LawfulEvil,
    NeutralEvil,
    ChaoticEvil
}

[CreateAssetMenu(menuName = "Ragnarok/Characters")]
public class Character : ScriptableObject
{
    //Base Information
    public string characterName;
    public Race race;
    public ClassEntry[] classes; // Array of classes the character has
    public string AlignmentText;
    public float level;
    public int experiencePoints;
    public CreatureSize size;
    public Senses[] senses;
    public int Initiative;
    public Sprite characterIcon;

    //Defensive information
    public int SpellResistance; // Spell Resistance
    public int HitPoints; // Total Hit Points
    public int Fortitude; // Fortitude Save
    public int Reflex;    // Reflex Save
    public int Will;      // Will Save
    public int AC;
    public int TouchAC;  // Touch AC
    public int FlatFootedAC; // Flat-Footed AC
    public int CMD; // Combat Maneuver Defense

    //Offensive information
    public int[] Speeds;
    public movementType[] movementTypes;
    public Attack[] attacks; // Array of attacks available to the character
    public int BaseAttackBonus; // Base Attack Bonus (BAB)
    public int CMB; // Combat Maneuver Bonus

    //Spellcasting information
    public int[] spellsPerDay; // Array of spells per day for each spell level
    public Spells[] spellsKnown; // Array of spells known by the character
    public Spells[] spellsPrepared; // Array of spells prepared by the character


    //Statistics
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;

    public int[] skillRanks; // Array of skill ranks for each skill defined in the Skills enum

    public Abilities[] abilities; // Array of feats available to the character

    public ItemInstance[] inventory; // Array of items in the character's inventory
    public EquippedItem[] equippedItems;

}

using UnityEngine;

public class CharacterSeriali : MonoBehaviour
{

    public Character character; // Reference to the character ScriptableObject


    //Set at creation,immutable during play
    public string characterName; // Character's name

    // Mutable stats (set at creation, change during play)
    public int currentStrength;
    public int currentDexterity;
    public int currentConstitution;
    public int currentIntelligence;
    public int currentWisdom;
    public int currentCharisma;
    public Alignment alignment; // Character's alignment

    // Derived stats (calculated from base and mutable stats)
    public int currentAC; // Armor Class
    public int currentBab; // Base Attack Bonus
    public int CurrentFort;
    public int currentReflex;
    public int currentWill; // Saves against Fortitude, Reflex, and Will
    public int[] currentSpeed; // Speed in feet
    public movementType[] movementTypes; // Types of movement available (e.g., walk, fly, swim, etc.)

    public int currentCMB; // Combat Maneuver Bonus
    public int currentCMD; // Combat Maneuver Defense

    public int currentInitiative; // Initiative modifier
    public int currentSpellResistance; // Spell Resistance
    public int currentHitPoints; // Current hit points
    public int maxHitPoints; // Maximum hit points
    public int[] currentSpellsPerDay; // Current spells per day
    public int[] currentSkills; // Array of current skill rank values, indexed by Skills enum
    public int currentgold; // Current gold amount
    public ItemInstance[] currentInventory;
    public Abilities[] currentAbilities; // Array of feats available to the character



    void Start()
    {
        currentStrength = character.Strength;
        currentDexterity = character.Dexterity;
        currentConstitution = character.Constitution;
        currentIntelligence = character.Intelligence;
        currentWisdom = character.Wisdom;
        currentCharisma = character.Charisma;
        alignment = character.alignment;

        currentAC = character.AC;
        
        currentBab = character.BaseAttackBonus;
        CurrentFort = character.Fortitude;
        currentReflex = character.Reflex;
        currentWill = character.Will;

        currentSpeed = new int[character.Speeds.Length];
        movementTypes = new movementType[character.movementTypes.Length];
        for (int i = 0; i < currentSpeed.Length; i++)
        {
            currentSpeed[i] = character.Speeds[i];
            movementTypes[i] = character.movementTypes[i];
        }

        currentCMB = character.CMB;
        currentCMD = character.CMD;

        currentInitiative = character.Initiative;
        currentSpellResistance = character.SpellResistance;
        maxHitPoints = character.HitPoints;
        currentHitPoints = maxHitPoints; // Initialize current hit points to max


        currentSpellsPerDay = new int[character.spellsPerDay.Length];
        for (int i = 0; i < currentSpellsPerDay.Length; i++)
        {
            currentSpellsPerDay[i] = character.spellsPerDay[i];
        }

        currentSkills = new int[character.skillRanks.Length];
        for (int i = 0; i < currentSkills.Length; i++)
        {
            currentSkills[i] = character.skillRanks[i];
        }

        currentgold = 0; // Initialize current gold amount

        for (int i = 0; i < character.inventory.Length; i++)
        {
            currentInventory[i] = character.inventory[i]; // Initialize empty inventory

        }

        for (int i = 0; i < character.abilities.Length; i++)
        {
            currentAbilities[i] = character.abilities[i];
        } // Initialize feats available to the character
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Example: Calculate AC dynamically
    public virtual int CalculateAC()
    {
        int baseAC = 10;
        int dexMod = (currentDexterity - 10) / 2;
        int armorBonus = 0;
        int shieldBonus = 0;
        // ...calculate bonuses from equipment, spells, etc.
        currentAC = baseAC + dexMod + armorBonus + shieldBonus;
        return baseAC + dexMod + armorBonus + shieldBonus;
    }
    public virtual int CalculateBab()
    {
        
        return character.BaseAttackBonus;

    }
    public virtual int CalculateCMB()
    {
        int baseAttackBonus = CalculateBab();
        int strengthMod = (currentStrength - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        currentCMB = baseAttackBonus + strengthMod;
        return baseAttackBonus + strengthMod;
    }
    public virtual int CalculateStrengthBasedAttackModifier()
    {
        int baseAttackBonus = CalculateBab();

        int strengthMod = (currentStrength - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        return baseAttackBonus + strengthMod;
    }
    public virtual int CalculateDexBasedAttackModifier()
    {

        int baseAttackBonus = CalculateBab();
        int DexMod = (currentDexterity - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        return baseAttackBonus + DexMod;
    }
    public virtual int CalculateFortitudeSave()
    {
        
        int fortitudeSave = CurrentFort;
        
        return fortitudeSave;
    }
    public virtual int CalculateReflexSave()
    {
        
        int reflexSave = currentReflex;

        return reflexSave;
    }
    public virtual int CalculateWillSave()
    {
        int willSave = currentWill;
        
        return willSave;
    }
}

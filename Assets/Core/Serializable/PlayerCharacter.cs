using UnityEngine;

[System.Serializable]
public class PlayerCharacter
{
    public Character character; // Reference to the character ScriptableObject


    //Set at creation,immutable during play
    public string characterName; // Character's name
    public string playerName; // Player's name

    // Mutable stats (set at creation, change during play)
    public int currentStrength;
    public int currentDexterity;
    public int currentConstitution;
    public int currentIntelligence;
    public int currentWisdom;
    public int currentCharisma;
    public ClassEntry[] classes;
    public Race race;
    public Alignment alignment; // Character's alignment

    // Derived stats (calculated from base and mutable stats)
    public int currentAC; // Armor Class
    public int currentBab; // Base Attack Bonus
    public int CurrentFort;
    public int currentReflex;
    public int currentWill; // Saves against Fortitude, Reflex, and Will
    public int currentSpeed; // Speed in feet

    public int currentCMB; // Combat Maneuver Bonus
    public int currentCMD; // Combat Maneuver Defense

    public int currentInitiative; // Initiative modifier
    public int currentSpellResistance; // Spell Resistance
    public int currentHitPoints; // Current hit points
    public int maxHitPoints; // Maximum hit points
    public int currentSpellsPerDay; // Current spells per day
    public int currentHP;
    public int[] currentSkills; // Array of current skill rank values, indexed by Skills enum
    public int currentgold; // Current gold amount
    public ItemInstance[] currentInventory;
    public EquippedItem[] currentEquipment;

    // Example: Calculate AC dynamically
    public int CalculateAC()
    {
        int baseAC = 10;
        int dexMod = (currentDexterity - 10) / 2;
        int armorBonus = 0;
        int shieldBonus = 0;
        // ...calculate bonuses from equipment, spells, etc.
        currentAC = baseAC + dexMod + armorBonus + shieldBonus;
        return baseAC + dexMod + armorBonus + shieldBonus;
    }
    public int CalculateBab()
    {
        int baseAttackBonus = 0;
        foreach (ClassEntry classEntry in classes)
        {
            if (classEntry.characterClass == null)
            {
                Debug.LogError("Class entry is null for one of the classes.");
                continue; // Skip null class entries
            }
            baseAttackBonus += (int)classEntry.characterClass.baseAttackBonusPerLevel / 4 * (int)classEntry.classLevel;
        }
        currentBab = baseAttackBonus;
        return baseAttackBonus;

    }
    public int CalculateCMB()
    {
        if (classes == null || classes.Length == 0)
        {
            Debug.LogError("No classes defined for the character.");
            return 0; // No CMB if no classes are defined
        }
        int baseAttackBonus = CalculateBab();
        int strengthMod = (currentStrength - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        currentCMB = baseAttackBonus + strengthMod;
        return baseAttackBonus + strengthMod;
    }
    public int CalculateStrengthBasedAttackModifier()
    {
        if(classes == null || classes.Length == 0)
        {
            Debug.LogError("No classes defined for the character.");
            return 0; // No attack modifier if no classes are defined
        }
        int baseAttackBonus = CalculateBab();

        int strengthMod = (currentStrength - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        return baseAttackBonus + strengthMod;
    }
    public int CalculateDexBasedAttackModifier()
    {
        if (classes == null || classes.Length == 0)
        {
            Debug.LogError("No classes defined for the character.");
            return 0; // No attack modifier if no classes are defined
        }

        int baseAttackBonus = CalculateBab();
        int DexMod = (currentDexterity - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        return baseAttackBonus + DexMod;
    }
    public int CalculateFortitudeSave()
    {
        if (classes == null || classes.Length == 0)
        {
            Debug.LogError("No classes defined for the character.");
            return 0; // No Fortitude save if no classes are defined
        }
        int fortitudeSave = 0;
        foreach (ClassEntry classEntry in classes)
        {
            if (classEntry.characterClass == null)
            {
                Debug.LogError("Class entry is null for one of the classes.");
                continue; // Skip null class entries
            }
            if (classEntry.characterClass.fortitudeSave == Savebonus.Good)
                fortitudeSave += (int)(classEntry.classLevel/2) + 2;
            else if (classEntry.characterClass.fortitudeSave == Savebonus.Poor)
                fortitudeSave += (int)classEntry.classLevel / 3;
        }
        CurrentFort = fortitudeSave + ((currentConstitution - 10) / 2);
        return fortitudeSave + ((currentConstitution - 10) / 2);
    }
    public int CalculateReflexSave()
    {
        if (classes == null || classes.Length == 0)
        {
            Debug.LogError("No classes defined for the character.");
            return 0; // No Reflex save if no classes are defined
        }
        int reflexSave = 0;
        foreach (ClassEntry classEntry in classes)
        {
            if (classEntry.characterClass == null)
            {
                Debug.LogError("Class entry is null for one of the classes.");
                continue; // Skip null class entries
            }
            if (classEntry.characterClass.reflexSave == Savebonus.Good)
                reflexSave += (int)(classEntry.classLevel / 2) + 2;
            else if (classEntry.characterClass.reflexSave == Savebonus.Poor)
                reflexSave += (int)classEntry.classLevel / 3;
        }
        currentReflex = reflexSave + ((currentDexterity - 10) / 2);
        return reflexSave + ((currentDexterity - 10) / 2);
    }
    public int CalculateWillSave()
    {
        if (classes == null || classes.Length == 0)
        {
            Debug.LogError("No classes defined for the character.");
            return 0; // No Will save if no classes are defined
        }
        int willSave = 0;
        foreach (ClassEntry classEntry in classes)
        {
            if (classEntry.characterClass == null)
            {
                Debug.LogError("Class entry is null for one of the classes.");
                continue; // Skip null class entries
            }
            if (classEntry.characterClass.willSave == Savebonus.Good)
                willSave += (int)(classEntry.classLevel / 2) + 2;
            else if (classEntry.characterClass.willSave == Savebonus.Poor)
                willSave += (int)classEntry.classLevel / 3;
        }
        currentWill = willSave + ((currentWisdom - 10) / 2);
        return willSave + ((currentWisdom - 10) / 2);
    }
}

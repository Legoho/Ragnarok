using UnityEngine;

[System.Serializable]
public class PlayerCharacter : CharacterSeriali
{
    public ClassEntry[] classes;
    public Race race;


    public EquippedItem[] currentEquipment;

    public Spells[] spellsKnown; // Array of spells known by the character
    public Spells[] spellsPrepared; // Array of spells prepared by the character

    public override int CalculateBab()
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
    public override int CalculateCMB()
    {
        int baseAttackBonus = CalculateBab();
        int strengthMod = (currentStrength - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        currentCMB = baseAttackBonus + strengthMod;
        return baseAttackBonus + strengthMod;
    }
    public override int CalculateStrengthBasedAttackModifier()
    {
        int baseAttackBonus = CalculateBab();

        int strengthMod = (currentStrength - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        return baseAttackBonus + strengthMod;
    }
    public override int CalculateDexBasedAttackModifier()
    {

        int baseAttackBonus = CalculateBab();
        int DexMod = (currentDexterity - 10) / 2;
        // ...calculate other modifiers from feats, spells, etc.
        return baseAttackBonus + DexMod;
    }
    public override int CalculateFortitudeSave()
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
                fortitudeSave += (int)(classEntry.classLevel / 2) + 2;
            else if (classEntry.characterClass.fortitudeSave == Savebonus.Poor)
                fortitudeSave += (int)classEntry.classLevel / 3;
        }
        CurrentFort = fortitudeSave + ((currentConstitution - 10) / 2);
        return fortitudeSave + ((currentConstitution - 10) / 2);
    }
    public override int CalculateReflexSave()
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
    public override int CalculateWillSave()
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

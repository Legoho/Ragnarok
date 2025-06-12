using UnityEngine;

public enum AbilityType
{
    ClassFeature,
    Feat,
    Trait,
    SpecialAttack,
    SpecialAbility,
    SpellLike,
    SpecialQuality,
    Misc
}
[CreateAssetMenu(menuName = "Ragnarok/Abilities")]
public class Abilities : ScriptableObject
{
    public string abilityName;
    public string description;
    public AbilityType abilityType;
}

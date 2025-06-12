using UnityEngine;

[CreateAssetMenu(menuName = "Ragnarok/Race")]
public class Race : ScriptableObject
{
    public string raceName;
    public string description;
    public CreatureSize size;
    public int baseSpeed;
    public Senses[] senses;
    public int[] abilityModifiers = new int[6]; // STR, DEX, CON, INT, WIS, CHA
    public RacialAbilities[] racialTraits;
    // Add more fields as needed (languages, resistances, etc.)
}
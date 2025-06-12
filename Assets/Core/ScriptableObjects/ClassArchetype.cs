using UnityEngine;

[CreateAssetMenu(menuName = "Ragnarok/Archetype")]
public class ClassArchetype : ScriptableObject
{
    public string archetypeName;
    [TextArea]
    public string description;
    public ClassBase baseClass; // Reference to the class this archetype modifies
    public Abilities[] replacedFeatures; // Features replaced by this archetype
    public Abilities[] newFeatures;      // New features granted by this archetype
    // Optionally: public int[] replacedLevels; // Levels at which features are replaced
}

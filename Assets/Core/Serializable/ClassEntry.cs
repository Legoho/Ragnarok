using UnityEngine;

[System.Serializable]
public class ClassEntry
{
    public ClassBase characterClass;      // Reference to the class ScriptableObject
    public int classLevel;                // Level in this class
    public ClassArchetype classArchetype;      // Optional: archetype for this class (can be null)
}
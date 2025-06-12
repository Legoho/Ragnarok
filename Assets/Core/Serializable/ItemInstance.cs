using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemBase baseItem; // Reference to the SO
    public EnchantmentInstance[] enchantments; // Array of enchantments applied to this instance
    public int currentCharges;
    // Add other per-instance fields as needed
}

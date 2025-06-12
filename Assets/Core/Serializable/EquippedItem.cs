using UnityEngine;


[System.Serializable]
public class EquippedItem
{
    public EquipmentSlot slot;
    public ItemInstance item; // Reference to the equipped item instance
}
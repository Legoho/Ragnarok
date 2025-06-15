using UnityEngine;


[System.Serializable]
public class EquippedItem: MonoBehaviour
{
    public EquipmentSlot slot;
    public ItemInstance item; // Reference to the equipped item instance
}
using UnityEngine;
public enum ItemType
{
    Consumable,
    Equipment,
    Material,
    QuestItem,
    Miscellaneous
}
public enum EquipmentSlot
{
    Head,
    Headband,
    Eyes,
    Neck,
    Shoulders,
    Body,
    Chest,
    Belt,
    Wrists,
    Hands,
    Ring1,
    Ring2,
    Feet,
    Armor,
    Shield
}



[CreateAssetMenu(menuName = "Ragnarok/Item")]
public class ItemBase : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public ItemType itemType;
}

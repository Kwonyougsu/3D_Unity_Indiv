using UnityEngine;


public enum ItemType
{
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType
{
    Health,
    Hunger
}
[SerializeField]
public class ItemConsumableType
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item",menuName = "New Item")]

public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string DisplayName;
    public string Discruption;
    public ItemType itemType;
    public Sprite icon;
    public GameObject dropRate;

    [Header("Stacking")]
    public bool Canstack;
    public int maxStackamount;

    [Header("Consumable")]
    public ItemConsumableType[] consumableTypes;
}

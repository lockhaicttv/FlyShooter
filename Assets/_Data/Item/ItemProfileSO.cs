using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "Scriptable Objects/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public ItemType itemType = ItemType.NoType;
}

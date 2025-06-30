using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName = "Item";
    public string itemCode = "code";
}

using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    protected static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Cannot have more than one ItemDropSpawner instance");
        ItemDropSpawner.instance = this;
       }

    public virtual void Drop(List<DropRate> dropList, Vector3 position, Quaternion rotation)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), position, rotation);
        if (itemDrop == null) return;
        
            itemDrop.gameObject.SetActive(true);
    }
}

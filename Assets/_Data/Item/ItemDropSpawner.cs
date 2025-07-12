using UnityEngine;

public class ItemDropSpawner: Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (this.instance != null) Debug.LogError("More than one item drop spawner in scene!");
        this.instance = this;
    }

    public virtual void Drop(List<DropRate> droplist, Vector3 pos, Quaternion rot)
    {
        ItemCode.itemCode = droplist[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(ItemCode.ToString(), pos, rot)
        itemDrop.gameObject.SetActive(true);
    }
}
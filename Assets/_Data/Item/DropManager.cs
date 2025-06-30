using System.Collections.Generic;
using UnityEngine;

public class DropManager : CMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("Only 1 DropManager allow to exist");
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log("Drop: " + dropList);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : CMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected ItemDespawn itemDespawn;

    public Transform Model
    {
        get => model;
    }

    public ItemDespawn ItemDespawn
    {
        get => itemDespawn;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadItemDespawn();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
    }
}
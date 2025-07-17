using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupAble : ItemAbstract
{
    protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = false;
        this.sphereCollider.radius = 0.2f;
    }

    protected void OnMouseDown()
    {
        PlayerController.Instance.PlayerPickup.ItemPickup(this);
    }

    public virtual ItemCode GetItemCode()
    {
        string itemName = transform.parent.name;
        return GetItemCodeFromString(itemName);
    }

    protected virtual ItemCode GetItemCodeFromString(string itemName)
    {
        try
        {
            return (ItemCode)Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    } 

    public virtual void Picked()
    {
        this.itemController.ItemDespawn.DespawnObject();
    }
}
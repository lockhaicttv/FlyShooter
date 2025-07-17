using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        Debug.Log("PlayerPickup");
        
        ItemCode itemCode =  itemPickupAble.GetItemCode();
        Debug.Log("ItemCode: " + itemCode);
        if (this.playerController.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Picked();
        }
    }
}

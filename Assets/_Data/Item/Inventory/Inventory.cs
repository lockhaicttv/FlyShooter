using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : CMonoBehaviour
{
    private protected int maxAddCount = 999;
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items =>  items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.GoldOre, 24);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        if (addCount >= maxAddCount)
        {
            Debug.Log("Cannot add to many items");
            return false;
        }
        
        int itemAddRemain = addCount;
        ItemInventory existedItem;
        
        for (int i = 0; i < this.maxSlot; i++)
        {
            if (itemAddRemain <= 0) break;
            
            existedItem = this.GetItemIsNotFullStack(itemCode);
            if (existedItem != null)
            {
                int remainingStack = this.GetMaxStack(existedItem) - existedItem.itemCount;
                int totalAdd = itemAddRemain > remainingStack ? remainingStack : itemAddRemain;
                existedItem.itemCount += totalAdd;
                itemAddRemain -= totalAdd;
            }
            else
            {
                existedItem = this.AddEmptyProfile(itemCode);
                existedItem.itemCount = itemAddRemain > this.GetMaxStack(existedItem) ? this.GetMaxStack(existedItem) :  itemAddRemain;
                itemAddRemain -= this.GetMaxStack(existedItem);
            }
        }
        
        return true;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        
        return itemInventory.maxStack;
    }

    protected virtual ItemInventory GetItemIsNotFullStack(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find(item => item.itemProfile.itemCode == itemCode && item.itemCount < item.maxStack);

        if (IsFullStack(itemInventory)) return null;
        
        return itemInventory;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;
        
        return itemInventory.itemCount >= this.GetMaxStack(itemInventory);
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }

        return null;
    }
    
    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }
    
    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }

        return totalCount;
    }
    
    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count-1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }
    }
}


// {
//     [SerializeField] protected int maxSlot = 70;
// [SerializeField] protected List<ItemInventory> items;
//
// protected override void Start()
// {
//     base.Start();
//     this.AddItem(ItemCode.GoldOre, 4);
// }
//
// public virtual bool AddItem(ItemCode itemCode, int addCount)
// {
//     ItemInventory itemInventory = this.GetItemByCode(itemCode);
//
//     int newCount = itemInventory.itemCount + addCount;
//     if (newCount > itemInventory.maxStack) return false;
//
//     itemInventory.itemCount = newCount;
//     return true;
// }
//
// public virtual ItemInventory GetItemByCode(ItemCode itemCode)
// {
//     ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
//     if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
//     return itemInventory;
// }
//
// protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
// {
//     var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
//     foreach(ItemProfileSO profile in profiles)
//     {
//         if (profile.itemCode != itemCode) continue;
//         ItemInventory itemInventory = new ItemInventory
//         {
//             itemProfile = profile,
//             maxStack = profile.defaultMaxStack
//         };
//         this.items.Add(itemInventory);
//         return itemInventory;
//     }
//
//     return null;
// }

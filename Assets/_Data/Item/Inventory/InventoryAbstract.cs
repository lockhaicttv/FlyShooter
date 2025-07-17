using UnityEngine;

public abstract class InventoryAbstract : CMonoBehaviour
{
    [Header("Inventory Abstract")]
    protected Inventory inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) Debug.LogWarning("Only one inventory is allowed.");
        this.inventory = transform.parent.GetComponent<Inventory>();
    }
}

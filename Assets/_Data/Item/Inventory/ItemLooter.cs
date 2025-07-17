using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class ItemLooter : CMonoBehaviour
{
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] Rigidbody rigidbody;

    [SerializeField] Inventory inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidBody();
        this.LoadTrigger();
        this.LoadInventory();
    }

    protected virtual void LoadRigidBody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = transform.GetComponent<Rigidbody>();
        this.rigidbody.isKinematic = true;
        this.rigidbody.useGravity = false;
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
    }

    protected virtual void LoadTrigger()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.5f;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupAble itemPickupAble = other.GetComponent<ItemPickupAble>();
        if (itemPickupAble == null) return;
        
        ItemCode itemCode = itemPickupAble.GetItemCode();
        
        if (itemCode == ItemCode.NoItem) return;
        if (this.inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Picked();
        }
    }
}

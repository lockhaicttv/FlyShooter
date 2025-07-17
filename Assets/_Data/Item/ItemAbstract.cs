using UnityEngine;
using UnityEngine.Serialization;

public abstract class ItemAbstract : CMonoBehaviour
{
     [SerializeField] protected ItemController itemController;
    [SerializeField] public ItemController ItemController {get => itemController;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemController();
    }

    protected virtual void LoadItemController()
    {
        if (this.itemController != null) return;
        this.itemController = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": LoadItemController", gameObject);
    }
}

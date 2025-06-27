using UnityEngine;

public abstract class BulletAbstract : CMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField]  protected BulletController bulletController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
    }
}

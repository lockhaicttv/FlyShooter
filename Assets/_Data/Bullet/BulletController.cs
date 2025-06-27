using UnityEngine;

public class BulletController : CMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected BulletDespawn bulletDespawn;
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    
    public Transform Model { get => model; }
    public BulletDespawn BulletDespawn { get => bulletDespawn; }
    public BulletDamageSender BulletDamageSender { get => bulletDamageSender; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadBulletDespawn();
        this.LoadBulletSender();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    protected virtual void LoadBulletSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + ": LoadBulletDamageSender", gameObject);
    }
}

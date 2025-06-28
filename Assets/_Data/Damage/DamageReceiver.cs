using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : CMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int hp = 0;
    [SerializeField] protected bool isDead = false;


    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    public virtual void Reborn()
    {
        this.hp = this.maxHp;
    }

    public virtual void Deduct(int damage)
    {
        this.hp -= damage;
        if (this.hp <= 0) this.hp = 0;
        this.CheckIsDead();
    }

    public virtual void AddHp(int hp)
    {
        this.hp += hp;
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        // For override
    }
}

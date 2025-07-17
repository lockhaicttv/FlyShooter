using UnityEngine;

public class DamageSender : CMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
    
    protected virtual void CreateImpactFX()
    {
        string impactFxName = this.GetFXName();
        Vector3 hitPosition = transform.position;
        Quaternion hitRotation = transform.rotation;
        
        Transform impactFxPrefab = FXSpawner.Instance.Spawn(impactFxName, hitPosition, hitRotation);
        impactFxPrefab.gameObject.SetActive(true);
    }

    protected virtual string GetFXName()
    {
        return FXSpawner.impactOne;
    }
}

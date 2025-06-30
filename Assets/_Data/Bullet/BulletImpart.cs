using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = this.GetComponent<Rigidbody>();
        this.rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        this.bulletController.BulletDamageSender.Send(other.transform);
        this.CreateImpactFX(other);
    }

    protected virtual void CreateImpactFX(Collider other)
    {
        string impactFxName = this.GetFXName();
        Vector3 hitPosition = other.transform.position;
        Quaternion hitRotation = other.transform.rotation;
        
        Transform impactFxPrefab = FXSpawner.Instance.Spawn(impactFxName, hitPosition, hitRotation);
        impactFxPrefab.gameObject.SetActive(true);
    }

    protected virtual string GetFXName()
    {
        return FXSpawner.impactOne;
    }
}

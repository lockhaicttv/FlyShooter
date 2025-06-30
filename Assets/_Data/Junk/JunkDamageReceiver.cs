using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }
    

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
    }

    protected override void OnDead()
    {
        this.junkController.JunkDespawn.DespawnObject();
        this.OnDeadFX();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }

    public override void Reborn()
    {
        this.maxHp = this.junkController.JunkSO.maxHP;
        base.Reborn();
    }
}

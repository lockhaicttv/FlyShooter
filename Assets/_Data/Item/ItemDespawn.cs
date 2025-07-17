using UnityEngine;

public class ItemDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timer = 0f;
        this.delay = 10f;
    }
}

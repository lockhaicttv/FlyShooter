using System;
using UnityEngine;

public abstract class Despawn : CMonoBehaviour
{
    protected void FixedUpdate()
    {
        this.Despawning();
    }

    private void Despawning()
    {
     this.DespawnObject();   
    }

    protected virtual void DespawnObject()
    {
        if (!this.CanDespawn()) return;
        Destroy(this.gameObject);
    }
    
    protected abstract bool CanDespawn();
}

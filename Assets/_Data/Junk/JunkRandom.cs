using System;
using Unity.VisualScripting;
using UnityEngine;

public class JunkRandom : CMonoBehaviour
{
    [SerializeField] protected JunkController junkController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected void Start()
    {
        this.RandomJunk();
    }

    protected virtual void RandomJunk()
    {
        Vector3 spawnPos = this.junkController.JunkSpawnPoints.RandomSpawnPoint().position;
        Quaternion rotation = transform.rotation;
        
        this.junkController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, spawnPos, rotation);
        Invoke(nameof(this.RandomJunk), 1f);
    }
}

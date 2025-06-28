using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class JunkSpawnerRandom : CMonoBehaviour
{
    [SerializeField] protected JunkSpawnerController junkSpawnerController;
    [SerializeField] protected float randomDelay = 4f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 9;
        
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerController();
    }

    protected virtual void LoadJunkSpawnerController()
    {
        if (this.junkSpawnerController != null) return;
        this.junkSpawnerController = GetComponent<JunkSpawnerController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.RandomJunk();
    }

    protected virtual void RandomJunk()
    {
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay || this.ReachLimit()) return;
        
        this.randomTimer = 0;
        Vector3 spawnPos = this.junkSpawnerController.JunkSpawnPoints.RandomSpawnPoint().position;
        Quaternion rotation = transform.rotation;
        Transform junkPrefab = this.junkSpawnerController.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, spawnPos, rotation);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool ReachLimit()
    {
        return  this.junkSpawnerController.JunkSpawner.SpawnAmount >= this.randomLimit;
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class JunkRandom : CMonoBehaviour
{
    [SerializeField] protected JunkSpawnerController junkSpawnerController;
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

    protected void Start()
    {
        this.RandomJunk();
    }

    protected virtual void RandomJunk()
    {
        Vector3 spawnPos = this.junkSpawnerController.JunkSpawnPoints.RandomSpawnPoint().position;
        Quaternion rotation = transform.rotation;
        Transform obj = this.junkSpawnerController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, spawnPos, rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.RandomJunk), 1f);
    }
}

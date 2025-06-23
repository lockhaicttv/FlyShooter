using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : CMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObject;
    [SerializeField] protected List<Transform> prefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    private void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(this.holder.name);
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        
        Transform prefabObject = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObject)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();
        
        Debug.Log(transform.name + "has been loaded", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName,Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }
        
        Transform newPrefab = this.GetPrefabFromPool(prefab);
        newPrefab.parent = this.holder;
        newPrefab.SetPositionAndRotation(spawnPosition, spawnRotation);
        
        return newPrefab;
    }

    public void Despawn(Transform obj)
    {
        this.poolObject.Add(obj);
        obj.gameObject.SetActive(false);
    }

    private Transform GetPrefabFromPool( Transform prefab)
    {
        foreach (Transform obj in this.poolObject)
        {
            if (obj.name == prefab.name)
            {
                this.poolObject.Remove(obj);
                return obj;
            }
        }
        
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    
    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            Debug.Log(prefab.name);
            if (prefab.name == prefabName) return prefab;
        }
        
        return null;
    }
}

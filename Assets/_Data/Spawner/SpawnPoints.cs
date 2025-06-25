using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : CMonoBehaviour
{
    [SerializeField] List<Transform> points;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }

    public Transform RandomSpawnPoint()
    {
        return this.points[Random.Range(0, this.points.Count)];
    }
}

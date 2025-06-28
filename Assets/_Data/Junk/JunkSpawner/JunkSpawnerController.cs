using UnityEngine;

public class JunkSpawnerController : CMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    
    public JunkSpawner JunkSpawner { get => junkSpawner; }
    public JunkSpawnPoints JunkSpawnPoints { get => junkSpawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        this.junkSpawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
    }
}
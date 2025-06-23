using UnityEngine;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }
    
    [SerializeField] public string bulletOne = "Bullet_1" ;

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("More than one BulletSpawner in scene!");
        BulletSpawner.instance = this;
    }
}

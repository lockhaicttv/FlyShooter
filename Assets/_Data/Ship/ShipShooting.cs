using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float timeDelay = 0.1f;
    [SerializeField] protected float timer = 0f;
    void Update()
    {
       this.Shooting();
       this.IsShooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) return;
     
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return;
        this.timer = 0f;
        
        Vector3 spawnPos = this.transform.parent.position;
        Quaternion spawnRot = this.transform.parent.rotation;
        
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.bulletOne,spawnPos, spawnRot);

        if (newBullet == null)
        {
            Debug.LogWarning("Prefab not found: " + BulletSpawner.Instance.bulletOne);
            return;
        }

        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}

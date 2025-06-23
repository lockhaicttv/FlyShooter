using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected Transform mainCamera;
    [SerializeField] protected float distance;


    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    private void LoadCamera()
    {
        if (this.mainCamera != null) return;
        
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log("Load main camera");
    }
    
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.position);
        
        return this.distance > this.disLimit;
    }
}

using UnityEngine;

public abstract class PlayerAbstract : CMonoBehaviour
{

    [Header("Player Abstract")]
    [SerializeField] protected PlayerController playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = transform.GetComponentInParent<PlayerController>();
    }
}

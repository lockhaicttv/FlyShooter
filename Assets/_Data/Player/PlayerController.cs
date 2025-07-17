using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : CMonoBehaviour
{
    static PlayerController instance;
    public static PlayerController Instance => instance;
    
    [SerializeField] protected ShipController currentShip;
    public ShipController CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;
    
    protected override void Awake()
    {
        base.Awake();
        if (PlayerController.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerController.instance = this;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected void LoadPlayerPickup()
    {
        if (playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
    }
}


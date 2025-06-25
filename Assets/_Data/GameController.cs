using UnityEngine;

public class GameController : CMonoBehaviour
{
    [SerializeField] protected Camera mainCam;
    private static GameController instance;
    
    public static GameController Instance { get => instance; }
    public Camera MainCam { get => mainCam; }

    protected override void Awake()
    {
        base.Awake();
        if (GameController.instance != null) Debug.LogError("Only 1 GameController allow to exist");
        GameController.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = GameController.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
}

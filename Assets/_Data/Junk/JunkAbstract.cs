using UnityEngine;

public abstract class JunkAbstract : CMonoBehaviour
{
    [SerializeField] protected JunkController junkController;
    [SerializeField] public JunkController JunkController {get => junkController;}

    protected virtual void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }
}

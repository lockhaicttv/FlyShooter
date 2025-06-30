using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : CMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected JunkDespawn junkDespawn;

    public Transform Model
    {
        get => model;
    }

    public JunkDespawn JunkDespawn
    {
        get => junkDespawn;
    }

    [SerializeField] protected JunkSO junkS0;

    [SerializeField]
    public JunkSO JunkSO
    {
        get => junkS0;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
    }

    protected virtual void LoadJunkSO()
    {
        if (this.junkS0 != null) return;
        this.junkS0 = Resources.Load<JunkSO>("Junk/" + transform.name);
    }
}
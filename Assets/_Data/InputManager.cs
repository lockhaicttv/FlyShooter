using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    
    [SerializeField] protected Vector3 mouseWorldPos;
    [SerializeField] protected float onFiring;
    
    [SerializeField] public Vector3 MouseWorldPos { get => mouseWorldPos; }
    [SerializeField] public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one input manager in scene!");
        InputManager.instance = this;
    }

    void Update()
    {
        this.GetMouseDown();
    }

    void FixedUpdate()
    {
        this.GetWorldPos();
    }

    protected virtual void GetWorldPos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mouseWorldPos.z = 0;
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring =  Input.GetAxis("Fire1");
    }
}
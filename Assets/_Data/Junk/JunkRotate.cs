using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float rotateSpeed;

    protected void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0, 1);
        this.JunkController.Model.Rotate(eulers * this.rotateSpeed * Time.fixedDeltaTime);
    }
}

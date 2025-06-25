using UnityEngine;

public class ParentFly : CMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(direction * Time.deltaTime * this.moveSpeed);
    }
}

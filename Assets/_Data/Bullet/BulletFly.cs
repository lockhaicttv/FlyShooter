using UnityEngine;

public class BulletFly : MonoBehaviour
{
   [SerializeField] protected int moveSpeed = 10;
   [SerializeField] protected Vector3 direction = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(direction * Time.deltaTime * this.moveSpeed);
    }
}

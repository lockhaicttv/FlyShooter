using UnityEngine;

public class BulletFly : MonoBehaviour
{
   [SerializeField] protected int moveSpeed = 1;
   [SerializeField] protected Vector3 direction = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(direction * Time.deltaTime * moveSpeed);
    }
}

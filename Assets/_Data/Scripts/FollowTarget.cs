using UnityEngine;

public class FollowTarget : CMonoBehaviour
{
   [SerializeField] protected Transform target;
   [SerializeField] protected float speed = 2f;

   protected virtual void FixedUpdate()
   {
      this.Following();
   }

   protected virtual void Following()
   {
      if (this.target == null) return;
      Vector3 targetPos = this.target.position;
      transform.position = Vector3.Lerp(transform.position, targetPos, this.speed * Time.fixedDeltaTime);
   }
}

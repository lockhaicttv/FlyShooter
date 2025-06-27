using UnityEngine;

public class BulletDamageSender : DamageSender
{
   [Header("Bullet Damage Sender")]
   [SerializeField] protected BulletController bulletController;

   protected override void LoadComponents()
   {
      base.LoadComponents();
      this.LoadBulletController();
   }

   protected virtual void LoadBulletController()
   {
      if (this.bulletController != null) return;
      this.bulletController = transform.parent.GetComponent<BulletController>();
   }

   public override void Send(DamageReceiver damageReceiver)
   {
      base.Send(damageReceiver);
      this.DestroyBullet();
   }

   protected virtual void DestroyBullet()
   {
      this.bulletController.BulletDespawn.DespawnObject();
   }
}

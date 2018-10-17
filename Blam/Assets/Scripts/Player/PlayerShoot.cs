using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [Header("Current Gun Equipped")]
    public GunData GunData;

    public void Shoot(Vector3 StartPosition, Vector3 Direction) {
        RaycastHit raycastHit;

        if(Physics.SphereCast(StartPosition, GunData.BulletSize, Direction, out raycastHit, GunData.Range)) {
            InitateDamage(raycastHit, Direction);
        }
    }

    private void Reload() {

    }

    private void InitateDamage(RaycastHit raycastHit, Vector3 Direction) {
        ITakeDamage takeDamage = raycastHit.collider.GetComponent<ITakeDamage>();
        Rigidbody rigidbody = raycastHit.collider.GetComponent<Rigidbody>();

        if (takeDamage != null) {
            takeDamage.TakeDamage(GunData.DamagePoints);
            rigidbody.AddForce(Direction * GunData.ForcePushback, ForceMode.Impulse);
        }
    }
}

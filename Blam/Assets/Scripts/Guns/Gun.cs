using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GunData gunData;

	public void Shoot(Vector3 StartPosition, Vector3 Direction) {
        Ray ray = new Ray(StartPosition, Direction);
        RaycastHit raycastHit;

        if(Physics.Raycast(ray, out raycastHit, gunData.Range)) {
            InitateDamage(raycastHit, Direction);
        }
    }

    public void Reload() {

    }

    private void InitateDamage(RaycastHit raycastHit, Vector3 Direction) {
        ITakeDamage takeDamage = raycastHit.collider.GetComponent<ITakeDamage>();
        Rigidbody rigidbody = raycastHit.collider.GetComponent<Rigidbody>();
        if (takeDamage != null) {
            takeDamage.TakeDamage(gunData.DamagePoints);
            rigidbody.AddForce(Direction * gunData.ForcePushback, ForceMode.Impulse);
        }
    }
}

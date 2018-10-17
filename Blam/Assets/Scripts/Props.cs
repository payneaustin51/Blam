using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour, ITakeDamage {
    [SerializeField] private float Health;
    [SerializeField] private ParticleSystem ExplosionSystem;

    public void TakeDamage(int DamagePoints) {
        Health -= DamagePoints;
        if (Health < 0.0f) {
            Destroy(this.gameObject);
        }
    }
}

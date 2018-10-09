using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {

    public float DamagePoints;
    public float RateOfFire;
    public float ReloadTime;
    public float AmmoCapacity;
    public float Range;
    public float SplashDamage;

	public virtual void Shoot()
    {

    }

    public virtual void Reload()
    {

    }
}

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New_Gun", menuName = "Guns", order = 1)]
public class GunData : ScriptableObject {
    public float DamagePoints;
    public float RateOfFire;
    public float ReloadTime;
    public float AmmoCapacity;
    public float Range;
    public float SplashDamage;
}

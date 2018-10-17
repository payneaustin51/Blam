using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New_Gun", menuName = "Guns", order = 1)]
public class GunData : ScriptableObject {
    [Header("General Settings")]
    public int DamagePoints;
    public int RateOfFire;
    public float ReloadTime;
    public int MaxAmmoCapacity;
    public int AmmoClipSize;
    public float Range;

    [Header("Physics Settings")]
    public float ForcePushback;
    public float BulletSize;

    [Header("Geometry/Animation Settings")]
    public GameObject GunGeo;
    public Vector3 Position;
}

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New_Gun", menuName = "Guns", order = 1)]
public class GunData : ScriptableObject {
    [Header("General Settings")]
    public int DamagePoints;
    public float RateOfFire;
    public float ReloadTime;
    public int AmmoCapacity;
    public float Range;

    [Header("Physics Settings")]
    public float ForcePushback;

    [Header("Geometry/Animation Settings")]
    public GameObject GunGeo;
    public Vector3 Position;
}

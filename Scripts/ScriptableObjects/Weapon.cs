using UnityEngine;

public enum WeaponType
{
    PRIMARY,
    SECONDARY
}
[CreateAssetMenu(fileName = "New Weapon",menuName ="Weapon")]
public class Weapon:ScriptableObject {
    public float damage;
    public WeaponType weaponType;
    public float speed;
    public int clip;
    public int ammo; 
    public float fireRate;
    public float range;
}
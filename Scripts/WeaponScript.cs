using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Weapon weapon; 
    public bool isTaken = false; 
    public bool isSelected = false;
    public float currentAmmo;
    public float currentClip; 
    

    private void Start() {
        currentAmmo = weapon.ammo; 
        currentClip = weapon.clip;     
    }
}

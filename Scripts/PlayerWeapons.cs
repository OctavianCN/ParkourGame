using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject weaponHolder; 
    public bool havePrimaryWeapon = false;
    public bool haveSecondaryWeapon = false; 
    public int weaponSelected = 0; 
    public WeaponScript primaryWeapon; 
    public WeaponScript secondaryWeapon;



    private void Update() {
        if(DeathScript.isDeath == false && PauseScript.isPaused == false && FinishScript.isFinised == false){
            WeaponSelect();
            if(havePrimaryWeapon||haveSecondaryWeapon){
                if(Input.GetMouseButton(0)){
                    if((weaponSelected == 1)&&primaryWeapon.gameObject.GetComponent<RaycastWeapon>().allowFire){
                        primaryWeapon.GetComponent<Animator>().enabled = true;
                        StartCoroutine(primaryWeapon.gameObject.GetComponent<RaycastWeapon>().StartFiring());
                    }
                    else
                    {
                        if((weaponSelected == 2)&&secondaryWeapon.gameObject.GetComponent<RaycastWeapon>().allowFire)
                        {   
                            secondaryWeapon.GetComponent<Animator>().enabled = true;
                            StartCoroutine(secondaryWeapon.gameObject.GetComponent<RaycastWeapon>().StartFiring());
                        }
                    }
                }
            }
        }
    }
    private void WeaponSelect(){
        if(Input.GetKeyDown(KeyCode.Alpha1)&&havePrimaryWeapon){
            weaponSelected = 1; 
            if(secondaryWeapon.gameObject != null){
                 secondaryWeapon.isSelected = false;
                secondaryWeapon.gameObject.SetActive(false);
            }
            primaryWeapon.gameObject.SetActive(true);
            primaryWeapon.isSelected = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)&&haveSecondaryWeapon){
            weaponSelected = 2;
             if(primaryWeapon.gameObject != null){
                primaryWeapon.isSelected = false;
                primaryWeapon.gameObject.SetActive(false);
            }
            secondaryWeapon.gameObject.SetActive(true);
            secondaryWeapon.isSelected = true;
        }
        if(havePrimaryWeapon == false && haveSecondaryWeapon == false){
            weaponSelected = 0; 
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Gun"){
            WeaponScript weaponCol = other.gameObject.GetComponent<WeaponScript>();
            if((weaponCol.weapon.weaponType == WeaponType.PRIMARY)&&(havePrimaryWeapon == false)){
                 if(haveSecondaryWeapon == true){
                        secondaryWeapon.gameObject.SetActive(false);
                        secondaryWeapon.isSelected = false;
                    }
                other.transform.parent = weaponHolder.transform; 
                havePrimaryWeapon = true;
                weaponCol.isTaken = true;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.localPosition = Vector3.zero; 
                other.transform.localRotation = Quaternion.identity;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                primaryWeapon = other.gameObject.GetComponent<WeaponScript>(); 
                primaryWeapon.isSelected = true;
                weaponSelected = 1;  
            }
             if((weaponCol.weapon.weaponType == WeaponType.SECONDARY)&&(haveSecondaryWeapon == false)){
                 if(havePrimaryWeapon == true){
                        primaryWeapon.gameObject.SetActive(false);
                        primaryWeapon.isSelected = false;
                    }
                other.transform.parent = weaponHolder.transform; 
                haveSecondaryWeapon = true;
                weaponCol.isTaken = true;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.localPosition = Vector3.zero; 
                other.transform.localRotation = Quaternion.identity;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                secondaryWeapon = other.gameObject.GetComponent<WeaponScript>();
                secondaryWeapon.isSelected = true;
                weaponSelected = 2;
            }
            
        }    
    }
}

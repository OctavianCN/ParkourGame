using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastWeapon : MonoBehaviour
{
   public bool isFiring = false; 
   public bool isReloading = false; 
   public ParticleSystem[] muzzleFlash; 
   public bool allowFire; 
   public ParticleSystem hitEffect; 
   public ParticleSystem hitEnemyEffect;
   public Text outOfRangeTip;
   public TrailRenderer tracerEffect;
   public PlayerWeapons playerWeapons; 
   public Transform bulletOrigin;
   public Transform bulletDestination;
   private Camera camera; 
   private Cinemachine.CinemachineImpulseSource cameraShake;
   public Animator animator;
   private WeaponScript weaponScript;
   RaycastHit hitInfo;
   private void Start() {
       camera = Camera.main; 
       allowFire = true; 
       cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
       weaponScript = GetComponent<WeaponScript>();
   }
    public IEnumerator StartFiring()
    {   
        
        allowFire = false;
        foreach(var particle in muzzleFlash)
        {
            particle.Emit(1);
        }
        isFiring = true;
        var tracer = Instantiate(tracerEffect,bulletOrigin.position,Quaternion.identity);
        tracer.AddPosition(bulletOrigin.position);
        if(Physics.Raycast(bulletOrigin.position,(bulletDestination.position-bulletOrigin.position).normalized,out hitInfo))
        {
            float distance = hitInfo.distance;
            if(distance <= weaponScript.weapon.range)
            {
                outOfRangeTip.enabled = false;
                if(hitInfo.transform.tag == "Enemy")
                {  
                    hitEnemyEffect.transform.position = hitInfo.point;
                    hitEnemyEffect.transform.forward = hitInfo.normal;
                    hitEnemyEffect.Emit(1);
                    hitInfo.transform.gameObject.GetComponent<EnemyScript>().GetDamage(this.GetComponent<WeaponScript>().weapon.damage);
                }
                else
                {
                    hitEffect.transform.position = hitInfo.point;
                    hitEffect.transform.forward = hitInfo.normal;
                    hitEffect.Emit(1);
                }
                tracer.transform.position = hitInfo.point;
            }
            else
            {
                outOfRangeTip.enabled = true;
            }
            
           animator.SetBool("Shooting",true);
           Debug.DrawLine(bulletOrigin.position,(bulletDestination.position-bulletOrigin.position).normalized*1f,Color.blue);
        }
       
        cameraShake.GenerateImpulse(Camera.main.transform.forward);
        if(playerWeapons.weaponSelected == 1)
            yield return new WaitForSeconds(playerWeapons.primaryWeapon.weapon.fireRate);
        else
            yield return new WaitForSeconds(playerWeapons.secondaryWeapon.weapon.fireRate);
        allowFire = true;
        StopFiring();
    }
    public void StopFiring()
    {   
        isFiring = false;
        animator.SetBool("Shooting",false);
        animator.enabled = false;
    }
}

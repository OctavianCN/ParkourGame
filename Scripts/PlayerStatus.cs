using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    public GameObject pannel;
    public Image image;

    public Enemy enemy1; 
    private float health = 100f; 
    private float currentHealth; 
    
    private void Start() {
        currentHealth = health;
    }
    private void Update() {
        if(currentHealth<=0){
            Die();
        }
    }
    public void GetDamage(float amount){
        currentHealth -= amount;
        if(!image.gameObject.active)
            StartCoroutine(LateCall(image.gameObject));
    }
    
    public void Die()
    {       
            image.gameObject.SetActive(true);
            DeathScript.isDeath = true;
            pannel.SetActive(true);
    }
     IEnumerator LateCall(GameObject obj)
     {
        obj.SetActive(true);
        yield return new WaitForSeconds(.2f);
        obj.SetActive(false);
     }
     private void OnTriggerEnter(Collider other) {
         if((other.transform.tag == "Projectile")&&(DeathScript.isDeath == false)){
             GetDamage(enemy1.damage);
         }
     }
}

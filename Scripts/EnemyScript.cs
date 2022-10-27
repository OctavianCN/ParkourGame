using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{
    float currentHealth;
    public Enemy enemy;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public int enemyNumber;
    public void Init() {
        currentHealth = enemy.health;
        animator = GetComponent<Animator>();
    }
    private void Update() {
        IsDead();
    }
    public void GetDamage(float amount){
        animator.SetTrigger("Hit");
        currentHealth -= amount;
    }

    public abstract void Attack();

    public bool IsDead(){
        if(currentHealth <= 0)
        {
            animator.SetBool("Dead",true);
            return true;
        }
       return false;
    }


    
}

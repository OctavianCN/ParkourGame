using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : EnemyScript
{
    public GameObject projectilePrefab;
    void Start() {

        Init();
        enemyNumber = 1;     
    }

    public override void Attack(){
        animator.SetTrigger("Attack");
        
    }

    public void ShootProjectile(){
        GameObject projectile  = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
        Rigidbody rb 
                = projectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f,ForceMode.Impulse);
        rb.AddForce(transform.up * 8f,ForceMode.Impulse);
        Destroy(projectile,1f);
        }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyAi : MonoBehaviour
{
  public LayerMask playerMask; 
  public LayerMask groundMask; 
  public Transform player; 

  public float DistanceToPlayer(){
     float distance = Vector3.Distance(this.transform.position,player.position);
     return distance; 
  }
  public Vector3 DirectionToPlayer(){
      Vector3 direction = (this.transform.position - player.position).normalized;
      return direction;
  }
  public void RotateToPlayer(){
        float rotationSmooth = 5f;
        Vector3 direction = -DirectionToPlayer();
        Quaternion lookRotation = 
                Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = 
                Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * rotationSmooth);
  }
  public void DrawEnemyTriggerSphere(float radius)
  {
      Gizmos.color = Color.red; 
      Gizmos.DrawWireSphere(transform.position,radius);
  }
  public void AttackState(float radius,Action AttackMethod){
      if(DistanceToPlayer() <= radius){
          RotateToPlayer();
          AttackMethod();
      }
  }
}

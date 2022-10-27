using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy1Ai : EnemyAi
{
    private Enemy1Script enemy1;
    void Start()
    {
        enemy1 = GetComponent<Enemy1Script>();
    }


    void Update()
    {
        if(!enemy1.animator.GetBool("Dead"))
        {  
            if(!FinishScript.isFinised&&!PauseScript.isPaused&&!DeathScript.isDeath)
            {
                enemy1.animator.speed = 1f;
                AttackState(enemy1.enemy.lookRadius,enemy1.Attack);
            }
            else
            {
                enemy1.animator.speed = 0f;
            }
        }
    }
    private void OnDrawGizmosSelected() {
        if(Application.isPlaying) 
            DrawEnemyTriggerSphere(enemy1.enemy.lookRadius);
    } 
}

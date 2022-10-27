using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public ButtonPlatform buttonPlatform;
    public List<GameObject> waypoints; 
    public float speed = 2.0f;
    private int counter = 0;
    void Update()
    {
        if((buttonPlatform.isPressed)&&(!PauseScript.isPaused&&!DeathScript.isDeath))
        {
            Move();
        }
    }
    void Move(){
        
        this.transform.position += GetPlatformMovement();
    }
    public Vector3 GetPlatformMovement(){
        Vector3 direction = (waypoints[counter].transform.position - this.transform.position).normalized;
        return direction * speed * Time.deltaTime;
    }
  void OnTriggerEnter(Collider other) 
  {
        if(other.transform.tag == "Waypoint")
        {
            
            if(counter + 1 < waypoints.Count){
                counter += 1;    
            }
            else
            {
               counter = 0;
            }
        }
    }
}

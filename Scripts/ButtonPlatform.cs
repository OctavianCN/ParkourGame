using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonPlatform : MonoBehaviour
{
    
    public Text text;
    public bool isPressed = false; 
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player")
        {
            text.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.transform.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F)){
                isPressed = true; 
                text.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if(text.enabled == true)
            text.enabled = false;
    }
}

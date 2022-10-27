using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField] private float sensitivity = 100.0f;
    [SerializeField] private Transform playerTransform;
    private PlayerWeapons playerWeapons;
    private float xRotation;
    private float yRotation;
    private void Start() {
        playerWeapons = playerTransform.gameObject.GetComponent<PlayerWeapons>();    
    }
    void Update()
    {
        if (PauseScript.isPaused == false)
        {
            float InputX = Input.GetAxis("Mouse X");
            float InputY = Input.GetAxis("Mouse Y");

            xRotation -= InputY;
            yRotation += InputX;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
            playerTransform.Rotate(Vector3.up * InputX);
           
        }
    }
}

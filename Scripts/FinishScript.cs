using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public static bool isFinised = false;
    public GameObject pannel;
    void Start()
    {
        isFinised = false;
        pannel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFinised = true;
            pannel.SetActive(true);
        }
    }
}

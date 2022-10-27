using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausePannel;
    void Start()
    {
        isPaused = false;
        pausePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            pausePannel.SetActive(true);

        }
    }

    public void Resume()
    {
        pausePannel.SetActive(false) ;
        isPaused = false;
    }
}

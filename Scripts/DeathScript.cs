using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject pannel;
    public static bool isDeath = false;

    void Start()
    {
        isDeath = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDeath = true;
            pannel.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1, LoadSceneMode.Single);
    }
    public void menu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0, LoadSceneMode.Single);
    }
}

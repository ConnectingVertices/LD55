using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;


    }

    void Update()
    {
        
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



}

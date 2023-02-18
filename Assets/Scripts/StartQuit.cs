using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuit : MonoBehaviour
{

    [SerializeField] AudioClip _backgroundMusic;

    public void Awake()
    {
        
    }


    public void StartGame()
    {
        

        //DontDestroyOnLoad(_backgroundMusic);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}

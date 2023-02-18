using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevelChanger : MonoBehaviour
{
    GameObject _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter(Collision Player)
    {
        if (GameManager.IsCompleted == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}

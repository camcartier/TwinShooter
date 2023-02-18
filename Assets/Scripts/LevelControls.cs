using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelControls : MonoBehaviour
{

    [SerializeField] protected int _totalNumberOfMobInLevel = 100;
    [SerializeField] protected int _totalNumberOfPirangnaInLevel =0;
    [SerializeField] protected int _totalNumberOfTurretsInLevel =0;
    [SerializeField] protected int _totalNumberOfSwordfishInLevel =0;

    private int _totalNumberOfMobKilled = 0;

    [SerializeField] public TextMeshPro _remainingToKill;

    private string _nextLevelName;


    void Start()
    {
        
    }


    void Update()
    {
         if (_totalNumberOfMobKilled == _totalNumberOfMobInLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }


}

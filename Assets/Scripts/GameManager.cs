using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region newCode
    [Header("Initialize Player")]
    [SerializeField] FloatVariables _playerMana;
    [SerializeField] IntVariables _playerHealth;
    private int _maxHealth;
    [SerializeField] IntVariables _livesNumber;
    [SerializeField] IntVariables _deathCounter;
    [SerializeField] IntVariables _scoreCounter;
    private GameObject _player;

    #region Sounds
    [SerializeField] AudioClip _backgroundMusic;
    [SerializeField] AudioClip _bossMusic;
    [SerializeField] AudioClip _clickButton;
    #endregion

    #region FX
    #endregion
    #endregion



    [SerializeField] int _enemyCount;

    public static bool IsCompleted;
    public static int lvl1PirangnaNumber = 10;

    public GameObject _gameManager;

    TextMeshPro endText;
    TextMeshPro victoryText;
    TextMeshPro defeatText;

    TextMeshPro _numberKilled;

    Transform _playerTransform;

    void Awake()
    {
        _playerHealth.value = 100;
        _playerMana.value = 0f;

        _gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(_gameManager);
    }

    // Start is called before the first frame update
    void Start()
    {
        //_enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        _playerTransform = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("EscapeQuit");
        }

    }

    public void EnemiesDecrease()
    {

        _enemyCount--;
        if (_enemyCount == 0)
        {
            Victory();   
        }
    }

    public void Victory()
    {
        //_numberKilled.text = _enemyCount.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Defeat()
    {
        SceneManager.LoadScene("EndSceneLoose");
    }

}

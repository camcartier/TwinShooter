using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _playerHP;

    [SerializeField] private GameManager _gameManager;

    [SerializeField]
    Image _healthbarGreen;

    [SerializeField]
    Image _healthbarRed;

    private float originHealth;
    

    void Awake()
    {
       _playerHP= 10;
    }


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        originHealth = _playerHP;

    }

    // Update is called once per frame
    void Update()
    {


        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {

            _playerHP= _playerHP -1;

            float coef = _playerHP / originHealth;

            _healthbarGreen.rectTransform.sizeDelta = new Vector2(_healthbarRed.rectTransform.sizeDelta.x * coef, _healthbarRed.rectTransform.sizeDelta.y );

            if (_playerHP <= 0)
            {

                _gameManager.Defeat();
                //rigidbodyPlayer = GetComponent<Rigidbody>();
                //rigidbodyPlayer.transform.Translate(0, 0, 0); 
            }

        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            _playerHP = _playerHP - 1;

            float coef = _playerHP / originHealth;

            _healthbarGreen.rectTransform.sizeDelta = new Vector2(_healthbarRed.rectTransform.sizeDelta.x * coef, _healthbarRed.rectTransform.sizeDelta.y);

            if (_playerHP <= 0)
            {

                _gameManager.Defeat();
                //rigidbodyPlayer = GetComponent<Rigidbody>();
                //rigidbodyPlayer.transform.Translate(0, 0, 0); 
            }
        }
    }







}

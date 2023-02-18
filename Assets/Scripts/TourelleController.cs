using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class TourelleController : MonoBehaviour
{
    [SerializeField]
    int _enemyHealth = 1;

    [SerializeField]
    public GameObject _enemyBullet;

    [SerializeField]
    float _rotateSpeed = 5f;

    [SerializeField]
    public Transform _canon;


    private float _nextTimeToShoot;

    private Transform _playerTransform;

    private Rigidbody _rigidbody;

    private GameManager _gameManager;


    private int _counter;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _playerTransform = GameObject.Find("Player").transform;

        InvokeRepeating("FireBullet", 1, 3);

        

    

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void FixedUpdate()
    {
        Vector3 directionToPlayer = _playerTransform.position - transform.position;

        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, _rotateSpeed);

        _rigidbody.MoveRotation(rotation);

        //_rigidbody.Moveposition(transform.position )

    }



    void FireBullet()
    {
        Instantiate(_enemyBullet, _canon.transform.position, _canon.transform.rotation);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemyHealth--;
            if (_enemyHealth <= 0)
            {
                _gameManager.EnemiesDecrease();
                Destroy(gameObject);

            }

        }
    }

}

using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    [SerializeField]
    float _rotateSpeed = 10f;

    [SerializeField]
    float n_speed = 5;

    Rigidbody _rigidbody;

    //private Vector2 _direction = new Vector2();

    private Renderer _pirangnaMat;

    private Transform _playerTransform;

    [SerializeField]
    int _enemyHealth = 2;

    private GameManager _gameManager;

    public global::System.Single RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _playerTransform = GameObject.Find("Player").transform;
        //_playerTransform = GameObject.Find("Player").GetComponent<Transform>();



        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        _pirangnaMat = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime = temps ecoulé en secondes depuis la derniere frame

        _rigidbody.velocity = transform.forward * n_speed;

    }

    private void FixedUpdate()
    {
        //Time.fixedDeltaTime = temps ecoulé ne secondes depuis la derniere frame



        Vector3 directionToPlayer = _playerTransform.position - transform.position;

        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

        Quaternion rotation= Quaternion.RotateTowards(transform.rotation, rotationToPlayer, RotateSpeed );

        _rigidbody.MoveRotation(rotation);


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            

            _enemyHealth --;
            _pirangnaMat.material.color = Color.red;

            if (_enemyHealth <= 0)
            {
                _gameManager.EnemiesDecrease();
                Destroy(gameObject);
            }

        }
    }




}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ET3Controller : MonoBehaviour
{
    

    [SerializeField]
    float _rotateSpeed = 150f;

    [SerializeField]
    public float _maxRotateTime = 1000f;



    [SerializeField] public float _espadonMaxMoveSpeed = 9f;
    [SerializeField] public float _espadonMaxAcceleration = 5;

    [SerializeField, Range(0f, 10f)] public float _espadonMoveSpeed;
    [SerializeField] public float _timeFromZeroToMaxSpeed = 1.5f;
    float _acceleratePerSec;
    float _currentAcc;

    //private int _collisionCounter;


    Rigidbody _rigidbody;

    Transform _playerTransform;

    public bool _boing = false;

    public bool _isDead = false;


    private void Awake()
    {
        _acceleratePerSec = _espadonMaxMoveSpeed / _timeFromZeroToMaxSpeed;
        _currentAcc = 0f;
        _currentAcc = Mathf.Min(_currentAcc, _espadonMaxMoveSpeed);

        //_collisionCounter = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine (Charge());

        if (_currentAcc > _espadonMaxAcceleration)
        {
            _currentAcc= _espadonMaxAcceleration; 
        }


    }







    public void OnCollisionEnter(Collision collision)
    {
        _currentAcc = 0f;

        StartCoroutine(rotateTowardsPlayer());
    }


    IEnumerator Charge()
    {
        yield return new WaitForSeconds(2);

        _playerTransform = GameObject.Find("Player").transform;

        _currentAcc += _acceleratePerSec * Time.deltaTime; 

        _rigidbody.velocity = transform.forward * _currentAcc;

    }



    IEnumerator rotateTowardsPlayer()
    {
        yield return new WaitForSeconds(3);

        Vector3 directionToPlayer = _playerTransform.position - transform.position;

        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, _rotateSpeed);


        _rigidbody.MoveRotation(rotation);
    }



}

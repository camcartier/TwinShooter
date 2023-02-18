using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadon : EnemiesBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;

    private GameObject _player;
    private float _playerAttPower;


    private void Awake()
    {
        _maxhp = 50f;
        _hp = _maxhp;

        _rb = GetComponent<Rigidbody>();

        _player = GameObject.Find("Player");
        _playerAttPower = _player.GetComponent<PlayerMovement>()._attPower;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            Move();
        }
        if (_hp <= 0)
        {
            AddScore(300);
            Death();
        } 
    }

    void Move()
    {

    }

    void Sprint()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            TakeDamage(_playerAttPower);
        }
    }
}

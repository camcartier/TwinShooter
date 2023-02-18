using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    int _healthbar;

    float _movespeed;

    float _shootRate;

    Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    public void Follow(GameObject followed)
    {
        Vector3 directionToPlayer = _playerTransform.position - transform.position;

        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, _rotateSpeed);

        _rigidbody.MoveRotation(rotation);
    }

*/

    public void Charge()
    {

    }

    public void Shoot()
    {

    }



}




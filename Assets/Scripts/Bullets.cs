using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [Header ("bulletStats")]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;
    [Header ("Prefabs")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletFX;

    #region private
    private Vector3 _direction;
    private Rigidbody _rb;
    private GameObject _player;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

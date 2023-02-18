using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mvt_EBullet : MonoBehaviour
{

    [SerializeField] float m_speed = 20f;
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.velocity = transform.forward * m_speed;
        Destroy(gameObject, 5f);
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

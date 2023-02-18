using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private Rigidbody _rb;
    private float _knockbackForce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Knockback()
    {
        //_rb.AddForce();
    }
}

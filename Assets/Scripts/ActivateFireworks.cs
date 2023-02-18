using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFireworks : MonoBehaviour
{
    [SerializeField]
    GameObject _fireworks;

    void Start()
    {
    }
    void Update()
    {
    }

    public void Explode()
    {
        GameObject Boom = Instantiate(_fireworks);
        Boom.GetComponent<ParticleSystem>().Play();
       
    }

}

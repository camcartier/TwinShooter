using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField]
    float m_speed = 30f;

    private Rigidbody _rigidbody;

    [SerializeField]
    public GameObject _impact;
    


    #region Unity Lifecycle
    //cette fonction est lue avant le Start
    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody>();
        //_impact = GameObject.Find("Impact").GetComponent<ActivateFireworks>();
        //celle la ne marchait pas, la bullet ne bougeait plus (on allait chercher le scritp)
        //ici on recupere plutot l'objet
    }



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.velocity = -transform.right * m_speed;
        // z = forward
        // y = up
        // x (positif) = right

        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Instantiate(_impact, transform.position, transform.rotation);
       
        Destroy(gameObject);


        //_impact.Explode();
        

        
    }




    #endregion
}

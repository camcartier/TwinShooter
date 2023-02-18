using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    Vector3 objectpos;
    TextMeshPro testText;
    GameObject testObject;
    GameObject testO2;

    // Start is called before the first frame update
    void Start()
    {
        testObject = GameObject.Find("testempty");
          
        testObject.AddComponent<Rigidbody>();


  
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log (gameObject.transform.position);
        gameObject.transform.position = new Vector3(0, 0, 0);

    }
}

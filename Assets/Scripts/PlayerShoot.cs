using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    #region Exposed

    [SerializeField]
    GameObject _bulletPrefab;

    [SerializeField]
    Transform _canon;

    [SerializeField]
    float _firerate = 0.35f;

    #endregion


    #region Private & Protected

    private float _nextTimeToShoot;

    public AudioSource FireSound;

    #endregion

    #region Methods
    #endregion

    #region Unity Lifecycle


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Shoot"));
        void FireBullet()
        {
            Instantiate(_bulletPrefab, _canon.transform.position, _canon.transform.rotation);
            //Quaternion.identity correspond a la rotation d'origine du prefab
            //(rotation a l'interieur du prefab)

        }

        if (Input.GetAxisRaw("Shoot") != 0 && Time.timeSinceLevelLoad > _nextTimeToShoot)
        {
            _nextTimeToShoot = Time.timeSinceLevelLoad + _firerate;
            FireBullet();


        }


    }

    #endregion
}

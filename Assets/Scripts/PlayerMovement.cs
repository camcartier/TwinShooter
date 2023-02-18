using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Stats")]
    [SerializeField] public float _attPower = 20f;
    [SerializeField] public float _fireRate = 0.25f;
    [SerializeField] public float _moveSpeed = 5f;
    [Header("Player Health&Mana")]
    [SerializeField] public int _maxhealth = 100;
    [SerializeField] IntVariables _currentHealth;
    [HideInInspector] public int _storedHealth;
    [SerializeField] public float _maxMana = 20f;
    [SerializeField] FloatVariables _currentMana;

    private float _acceleration;
    private float _maxSpeed = 5f;
    private float _dashForce;
    private float _dashCooldown = 2f;
    private float _manaDecayValue = 2f;
    private float _manaIncreaseValue = 1f;

    private bool _canTakeHit = true;
    private bool _canFire = true;
    private bool _canMove = true;
    private bool _canShield = false;
    private bool _isUsingShield = false;
    private bool _isActive = true;

    private float _knockbackForce;

    private Rigidbody _rb;

    #region Sounds
    [Header ("Sounds")]
    [SerializeField] AudioSource _firingSound;
    [SerializeField] AudioSource _hitSound;
    [SerializeField] AudioSource _dashingSound;
    [SerializeField] AudioSource _shieldSound;
    #endregion

    #region FX
    #endregion


    #region Exposed
    [SerializeField] 
    private float n_speed = 5;

    [SerializeField]
    Transform _playerTransform;

 #endregion

    #region Private & Protected
    private Vector2 _direction = new Vector2();
    private Vector3 _orientationInput = new Vector3();
    Rigidbody _rigidbody;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _storedHealth = _currentHealth.value;
        _rb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //sinon on fait un serialzedfield.... drag&drop 



    }


    // Update is called once per frame
    void Update()
    {

        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //pour ne pas avoir d'interpolation on ecrit comme ci dessous
        //float horizontal = Input.GetAxisRaw("Horizontal")
        //le Raw vire l'interpolation, on passe de 0 a 1 immediatement

        _direction.x = horizontal;
        _direction.y = vertical;
        //on pourrait directement ecrire
        //_direction.y = Input.GetAxis("Vertical");
        
        
        //Debug.Log(horizontal + "." + vertical);


        //recuperation des inputs pour la rotation
        _orientationInput.x = Input.GetAxis("RightStickX");
        _orientationInput.z = Input.GetAxis("RightStickY");

        if(_currentMana.value < _maxMana)
        {
            _currentMana.value += _manaIncreaseValue * Time.deltaTime;
        }

        if (_storedHealth > _currentHealth.value)
        {
            Knockback(); 
            _storedHealth = _currentHealth.value;
        }

        if (_isUsingShield && _currentMana.value > 0)
        {
            _canTakeHit= false;
            Shield();
        }

        if (_currentHealth.value <= 0)
        {
            Death();
        }

    }



    private void FixedUpdate()
    {
        //Mouvement
        Vector3 movement = new Vector3(_direction.x, 0, _direction.y);
        //ici le direction y est une valeur de z

        movement.Normalize();

        _rigidbody.velocity = movement * n_speed;

        //Rotation
        Quaternion rotation = Quaternion.LookRotation(_orientationInput);

        if (_orientationInput != Vector3.zero)
        {
            _rigidbody.MoveRotation(rotation);
        }

        

    }

    void TakeDamage(int _enemyAttackPower)
    {
        _currentHealth.value -= _enemyAttackPower;
    }

    void Shield()
    {
        _shieldSound.Play();
    }

    void Death()
    {
        _isActive= false;
    }

    void Knockback()
    {

    }



    #endregion

}

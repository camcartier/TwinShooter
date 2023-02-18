using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    [Header("Health")]
    protected float _hp;
    protected float _maxhp;

    [Header("MoveStats")]
    [SerializeField] protected float _moveSpeed = 20f;
    [SerializeField] protected float _maxMoveSpeed = 20f;
    [SerializeField] protected float _minMoveSpeed = 20f;

    [Header("AttackStats")]
    [SerializeField] protected float _attackPower = 10f;
    [SerializeField] protected float _attackCooldown;
    [SerializeField] protected float _kbDuration = 2f;
    [SerializeField] protected float _kbDelay;
    [SerializeField] protected float _kbStrength;

    [Header("bools")]
    protected bool _canMove = true;
    protected bool _canTurn = true;
    protected bool _canFollow = true;
    protected bool _canDamage = true;
    protected bool _canBeDamaged = true;
    protected bool _canDie = true;

    protected GameObject _canon;

    [SerializeField] IntVariables _scoreCount;

    protected void TakeDamage(float damage)
    {
        _hp -= damage;  
    }

    protected void Death()
    {
        Destroy(this.gameObject);
    }

    protected void Shoot(GameObject bullet)
    {
        Instantiate(bullet, _canon.transform.position, Quaternion.identity);
    }

    protected void AddScore(int scoreGain)
    {
        _scoreCount.value += scoreGain;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health;
    public float speed;
    public float attackDamage;
    
    private float timeStamp;

    private bool isAlive = true;

    private GameObject player;
    public GameObject enemyToControl;
    private Animator _animator;
    
    public GameObject attackPoint;
    public LayerMask playerLayer;
    
    private float attackRange = 0.1f;

    private EnemyAttackPoint checkAttackable;
    
    private static readonly int Death = Animator.StringToHash("death");
    private static readonly int Attack = Animator.StringToHash("attack");


    private void Start()
    {
        timeStamp = Time.time + 3;
        player = GameObject.FindWithTag("Player");
        _animator = enemyToControl.GetComponent<Animator>();

        checkAttackable = attackPoint.GetComponent<EnemyAttackPoint>();
    }

    private void Update()
    {
        if (isAlive)
        {
            FollowPlayer();
        }
        
        if (checkAttackable.canAttack) //legg til timer
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 3;
                Hit();
            }
        }

    }

    void Hit()
    { 
        _animator.SetTrigger(Attack);
        
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.transform.position, attackRange, playerLayer);
        
        hitEnemies[0].GetComponent<CharacterStats>().TakeDamage(attackDamage);

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        _animator.SetTrigger("isDamaged");

        if (health <= 0)
        {
            Die();
        }
    }

    void FollowPlayer()
    {
        Vector3 lookPos = player.transform.position - enemyToControl.transform.position;
        lookPos.y = 0;
        enemyToControl.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    void Die()
    {
        isAlive = false;
        _animator.SetTrigger(Death); 
        gameObject.tag = "deadEnemy";
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}

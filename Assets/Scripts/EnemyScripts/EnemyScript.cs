using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health;
    public float speed;
    public int attackDamage;

    public bool isBossDead = false;
    
    private float timeStamp;

    private bool isAlive = true;

    private GameObject player;
    public GameObject enemyToControl;
    private Animator _animator;
    
    public GameObject attackPoint;
    public LayerMask playerLayer;
    
    private float attackRange = 0.5f;
    private float attackRangeRayCast = 0.5f;


    private EnemyAttackPoint checkAttackable;
    
    private static readonly int Death = Animator.StringToHash("death");
    private static readonly int Attack = Animator.StringToHash("attack");
    private static readonly int IsDamaged = Animator.StringToHash("isDamaged");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");


    private void Start()
    {
        timeStamp = Time.time + 1;
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
        
        CheckIfAttackable();
        Debug.DrawRay(attackPoint.transform.position, transform.forward * attackRangeRayCast, Color.red);

    }

    void Hit()
    { 
        _animator.SetTrigger(Attack);
        
    }

    void AnimationHit()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.transform.position, attackRange, playerLayer);

        try
        {
            hitEnemies[0].GetComponent<CharacterStats>().TakeDamage(attackDamage);
        }
        catch (IndexOutOfRangeException e)
        {
            
        }
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        _animator.SetTrigger(IsDamaged);

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
        isBossDead = true;
        isAlive = false;
        _animator.SetTrigger(Death); 
        gameObject.tag = "deadEnemy";
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

    void CheckIfAttackable()
    {
        // Cast a ray in front of the character
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.transform.position, transform.forward, out hit, attackRangeRayCast, playerLayer))
        {
            Debug.Log("hitting player");
            
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 1;
                Hit();
            }
            
            Debug.Log("Attacking player!");
        }

    }
    
    
}

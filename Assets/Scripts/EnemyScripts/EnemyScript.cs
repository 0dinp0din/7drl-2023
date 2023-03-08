using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health;
    public float speed;
    public float attackDamage;

    private bool isWalking = false;
    
    private GameObject player;
    public GameObject enemyToControl;
    private Animator _animator;
    
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int Death = Animator.StringToHash("death");
    private static readonly int Attack = Animator.StringToHash("attack");


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _animator = enemyToControl.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isWalking)
        {
            FollowPlayer();
        }
        //if player is in range, attack
        
        //if player is in lookrange, walk towards player

    }

    void Hit()
    {
     _animator.SetTrigger(Attack);   
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

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
        _animator.SetTrigger(Death); 
        gameObject.tag = "deadEnemy";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("InArea");
            _animator.SetBool(IsWalking, true);
            isWalking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Not InArea");
            _animator.SetBool(IsWalking, false);
            isWalking = false;
        }
    }
}

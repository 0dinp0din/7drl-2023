using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    private Animator weapon;
    private float timeStamp;
    public LayerMask enemyLayer;
    public AudioSource audio;

    public AudioClip hitSound;
    public AudioClip missSound;

    public Transform attackPoint;
    private float attackRange = 0.5f;

    private float attackDamage = 10.0f;


    private void Start()
    {
        weapon = transform.GetChild(0).GetComponent<Animator>();
        timeStamp = Time.time + 1;
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + 1;
                Attack();
            }
        }

    }

    void Attack()
    {
        weapon.SetTrigger("attack");
        

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);


        try
        {
            hitEnemies[0].GetComponent<EnemyScript>().TakeDamage(attackDamage);
            audio.PlayOneShot(hitSound);
        }
        catch (IndexOutOfRangeException e)
        {
            audio.PlayOneShot(missSound);
        }

    }

}

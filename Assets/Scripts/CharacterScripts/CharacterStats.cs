using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    private int _health = 100;
    private int _maxHealth = 100;
    private int _speed;
    private int healthPotions = 3;
    
    [SerializeField] public HealthContainer hc;
    
    public GameObject textObject;
    private TextMeshProUGUI text;


    private void Start()
    {
        hc.setMaxHealth(_health);
        text = textObject.GetComponent<TextMeshProUGUI>();
        setPotions(healthPotions);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UsePotion();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        hc.setHealth(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    //potion functionality
    public void AddPotion()
    {
        healthPotions += 1;
        setPotions(healthPotions);
    }
    
    public void setPotions(int healthPots)
    {
        text.text = healthPots + " x";
    }

    void UsePotion()
    {
        if (healthPotions >= 1)
        {
            if (_health <= _maxHealth-1)
            {
                if (_health+20 >= _maxHealth)
                {
                    _health = _maxHealth;
                }
                else
                {
                    _health += 20;
                }
                
                healthPotions -= 1;
                setPotions(healthPotions);
                hc.setHealth(_health);
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2 );
    }

}

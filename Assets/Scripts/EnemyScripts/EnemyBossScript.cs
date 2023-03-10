using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBossScript : MonoBehaviour
{

    public EnemyScript enemy;

    private void Update()
    {
        if (enemy.isBossDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }

        
    }
}

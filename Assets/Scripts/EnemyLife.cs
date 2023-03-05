using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{   //enemy
    public GameObject explosion;
    public int scorePoints;
    public int healthEnemy = 2;
    public bool isDead = false;
    public Image barOflifeEnemy;

    //stages enemy
    public GameObject fullLife;
    public GameObject littleLife;

    void Start()
    {
       
    }


    void Update()
    {
        if (healthEnemy == 2)
        {
            this.barOflifeEnemy.fillAmount = 1f;
        }
        if (healthEnemy == 1)
        {
            this.barOflifeEnemy.fillAmount = 0.5f;
            littleLife.SetActive(true);
        }
        if (healthEnemy == 0)
        {
            this.barOflifeEnemy.fillAmount = 0f;
            littleLife.SetActive(false);
        }
    }


    public void TakeDamageEnemy(int damage)
    {
        if (!isDead)
        {

            healthEnemy -= damage;
            if (healthEnemy <= 0)
            {
                isDead = true;
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    LevelController.levelController.SetScore(scorePoints);
                    Destroy(gameObject);
                }

            }

        }
    }


   
}

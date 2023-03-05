using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour
{
    public GameObject explosion;
    public int scorePoints;
    public int health = 3;
    public bool isDead = false;
    public Image barOflife;

    //stages player
    public GameObject fullLife;
    public GameObject lessLife;
    public GameObject littleLife;




    void Start()
    {
        barOflife = GameObject.Find("LifePlayer").GetComponent<Image>();
    }


    void Update()
    {
        barOflife = GameObject.Find("LifePlayer").GetComponent<Image>();



        //bar life and stages 
        if (health == 3)
        {
            barOflife.fillAmount = 1;
        }
        if (health == 2)
        {
            barOflife.fillAmount = 0.66f;
            fullLife.SetActive(false);
            lessLife.SetActive(true);
        }
        if (health == 1)
        {
            barOflife.fillAmount = 0.33f;
            lessLife.SetActive(false);
            littleLife.SetActive(true);
        }
        if (health == 0)
        {
            barOflife.fillAmount = 0f;
            littleLife.SetActive(false);
        }



    }


    public void TakeDamage(int damage)
    {
        if (!isDead)
        {

            health -= damage;
            if (health <= 0)
            {
                isDead = true;
                if (explosion != null)
                    Instantiate(explosion, transform.position, transform.rotation);

                if (this.GetComponent<Player>() != null)
                {
                    GetComponent<Player>().Respawn();
                    StartCoroutine(helthing());
                }
                else
                {
                                      
                    LevelController.levelController.SetScore(scorePoints);
                    
                }
            }
            
        }
    }


    IEnumerator helthing()
    {
        yield return new WaitForSeconds(3);
        health = 3;
        fullLife.SetActive(true);
        littleLife.SetActive(false);
        isDead = false;
    }


}

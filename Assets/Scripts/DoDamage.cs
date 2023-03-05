using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 1;

    public GameObject explosionContact;

    public bool destroyByContact = true;
   



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (damage >= 1)
        {
            EnemyLife characterEnemy = other.GetComponent<EnemyLife>();
            if (characterEnemy != null)
            {
                characterEnemy.TakeDamageEnemy(damage);
                if (destroyByContact)
                Instantiate(explosionContact, transform.position, transform.rotation);
                Destroy(gameObject);
            }

                      
        }

        if(damage >= 1)
        {
            CharacterLife character = other.GetComponent<CharacterLife>();
            if (character != null)
            {
                character.TakeDamage(damage);
                if (destroyByContact)
                Instantiate(explosionContact, transform.position, transform.rotation);
                Destroy(gameObject);
            }


        }
    }
}

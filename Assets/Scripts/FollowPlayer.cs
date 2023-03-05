using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }





























    /* private Rigidbody2D rb;
     private Player player;
     private float moveSpeed;
     private Vector3 directionToPlayer;
     private Vector3 localScale;

     private void Start()
     {
         rb = GetComponent<Rigidbody2D>();
         player = FindObjectOfType(typeof(Player)) as Player;
         moveSpeed = 1;
         localScale = transform.localScale;
     }


     private void Update()
     {

     }

     private void FixedUpdate()
     {
         MoveEnemy();
     }

     private void MoveEnemy()
     {
         directionToPlayer = (player.transform.position - transform.position).normalized;
         rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
         float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
         rb.rotation = angle;

     }

     private void LateUpdate()
     {
         if (rb.velocity.x > 0)
         {
             transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
         }
         else if (rb.velocity.x < 0)
         {
             transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
         }
     }*/
}

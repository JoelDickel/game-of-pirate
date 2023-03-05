using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour
{
    
    //Fire layer
    public float fireRate;
    private float nextFire;
    public GameObject Bullet;
    public Transform[] shotSpawns;

    //Player lives
    private bool isDead = false;
    public float spawnTime;
    private Vector3 startPosition;
    public float invencibilityTime;

    //Realy move
    public GameObject btn;
    public GameObject btnL;
    public GameObject btnR;
    public ForwardPlayer forward;
    public ForwardPlayer rotateL;
    public ForwardPlayer rotateR;
    public float speed = 1000;
    public float speedRotateL;
    public float speedRotateR;
    private Rigidbody2D rb;
    public Boundary boundary;
    

    void Start()
    {
        btn = GameObject.Find("MoveToFront");
        btnL = GameObject.Find("Left");
        btnR = GameObject.Find("Right");

        forward = btn.GetComponent<ForwardPlayer>();
        rotateL = btnL.GetComponent<ForwardPlayer>();
        rotateR = btnR.GetComponent<ForwardPlayer>();

        startPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


    }

    private void FixedUpdate()
    {

        if (!isDead)
        {
            
            transform.Translate(0, speed * forward.input * Time.deltaTime, 0);
            transform.Rotate(0f, 0f, speedRotateR * rotateR.input * Time.deltaTime);
            transform.Rotate(0f, 0f, speedRotateL * rotateL.input * Time.deltaTime);
        }


        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
    }


    [SerializeField]
    public void FrontFire()
    {
         if (!isDead)
         {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(Bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
         }
    }
    [SerializeField]
    public void SideFire()
    {

        if (!isDead)
        {
            if (Time.time > nextFire)

            {
                nextFire = Time.time + fireRate;
                Instantiate(Bullet, shotSpawns[1].position, shotSpawns[1].rotation);
                Instantiate(Bullet, shotSpawns[2].position, shotSpawns[2].rotation);
                Instantiate(Bullet, shotSpawns[3].position, shotSpawns[3].rotation);
                Instantiate(Bullet, shotSpawns[4].position, shotSpawns[4].rotation);
                Instantiate(Bullet, shotSpawns[5].position, shotSpawns[5].rotation);
                Instantiate(Bullet, shotSpawns[6].position, shotSpawns[6].rotation);

            }
        }
    }

    public void Respawn()
    {
      StartCoroutine(Spawning());
    }

   IEnumerator Spawning()
   {
      isDead = true;
      yield return new WaitForSeconds(spawnTime);
      transform.position = startPosition;
      isDead = false;
   }



}

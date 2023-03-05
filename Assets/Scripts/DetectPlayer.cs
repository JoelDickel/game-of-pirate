using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
     public float range;
     public Transform target;
     private Vector2 direction;
     public bool detected = false;
     public GameObject cannon;
     public float nextFire;
     public float fireRate;
     public GameObject Bullet;
     public Transform[] shotSpawns;

     [SerializeField] private LayerMask layerMask;


     void Start()
     {
         target = FindObjectOfType<RealPlayer>().transform;
     }

     // Update is called once per frame
     void Update()
     {

         Vector2 targetPos = target.position;
         direction = targetPos - (Vector2)transform.position;
         RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);

         if (rayInfo)
         {
             if(rayInfo.collider.gameObject.tag == "RealPlayer")
             {
                 if(detected == false)
                 {
                     detected = true;
                 }

             }
            else
             {
                 if(detected == true)
                 {
                     detected = false;
                 }
             }
         }

         if (detected)
         {
             cannon.transform.up = direction;
             if(Time.time > nextFire)
             {
                 nextFire = Time.time + fireRate;
                 Instantiate(Bullet, shotSpawns[0].position, shotSpawns[0].rotation);
             }
         }
     }

     void OnDrawGizmosSelected()
     {
         Gizmos.DrawWireSphere(transform.position, range);
     }
    
}

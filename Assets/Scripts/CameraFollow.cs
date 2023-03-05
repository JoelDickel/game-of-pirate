using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform targetPlayer;
    public float timeLerp;

    void Start()
    {
        targetPlayer = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        Vector3 newPosition = targetPlayer.position + new Vector3(0, 0, -10);
        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
       
    }
}

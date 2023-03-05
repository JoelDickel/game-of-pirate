using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    //Move Player
    public float moveSpeed = 0.1f;
    public float moveRotateR = -1f;
    public float moveRotateL = 1f;
    public float input;
    public float sensibility = 100;
    bool pression;
    


    void Update()
    {
        if (pression)
        {
            input += Time.deltaTime * sensibility;
        }
        else
        {
            input -= Time.deltaTime * sensibility;
        }
        input = Mathf.Clamp(input, 0, 1);
    }

    public void MoveToFront()
    {
        if (pression)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    public void MoveToLeft()
    {
        if(pression)
        {
            transform.Rotate(0f, 0f, moveRotateL * input * Time.deltaTime);
        }
    }

    public void MoveToRight()
    {
        if (pression)
        {
            transform.Rotate(0f, 0f, moveRotateR * input * Time.deltaTime);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        pression = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pression = false;
    }
}

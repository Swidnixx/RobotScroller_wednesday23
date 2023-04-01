using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    public SpriteRenderer sr;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f, groundMask);
            
        if(hit.collider != null)
        {
            //zmieniamy kolor gracza na zielony przy trafieniu
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }

        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.9f);
        Debug.DrawRay(transform.position, Vector3.down * 0.9f);
    }
}

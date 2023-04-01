using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100;
    public LayerMask groundMask;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;

    bool grounded;

    private void Update()
    {
        GroundCheck();
        JumpLogic();
    }

    void JumpLogic()
    {
        bool jumpInput = Input.GetMouseButtonDown(0);
        if(jumpInput)
        {
            if(grounded)
            {
                Vector2 force = new Vector2(0, jumpForce);
                rb.AddForce( force );
            }
        }
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundMask);
        grounded = hit.collider != null;

        if ( grounded )
        {
            //zmieniamy kolor gracza na zielony przy trafieniu
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }

        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.9f);
        //Debug.DrawRay(transform.position, Vector3.down * 0.9f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube( transform.position + Vector3.down * 0.1f, boxCollider.bounds.size );
    }
}

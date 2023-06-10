using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100;
    public float jumpVel = 10;
    public LayerMask groundMask;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;

    bool grounded;
    bool doubleJump;

    private void Update()
    {
        GroundCheck();
        JumpLogic();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Battery"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.CollectBattery();
        }

        if (collision.CompareTag("Magnet") )
        {
            Destroy(collision.gameObject);
            GameManager.Instance.CollectMagnet();
        }
    }


    void JumpLogic()
    {
        bool jumpInput = Input.GetMouseButtonDown(0);
        if(jumpInput)
        {
            if(grounded)
            {
                doubleJump = true;
                Vector2 force = new Vector2(0, jumpForce);
                rb.AddForce( force );
            }
            else if( doubleJump )
            {
                doubleJump = false;
                Vector2 vel = new Vector2(0, jumpVel);
                rb.velocity = vel;
            }
        }
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast( boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundMask);
        grounded = hit.collider != null;

        //if ( grounded )
        //{
        //    //zmieniamy kolor gracza na zielony przy trafieniu
        //    sr.color = Color.green;
        //}
        //else
        //{
        //    sr.color = Color.red;
        //}

        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.9f);
        //Debug.DrawRay(transform.position, Vector3.down * 0.9f);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireCube( boxCollider.bounds.center + Vector3.down * 0.1f, boxCollider.bounds.size );
    }
}

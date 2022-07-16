using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movingSpeed = 4f;
    public float jumpPower;
    private Rigidbody2D rb;
    private bool _facingRight;
    private bool _isJumping = false;
    private bool _inAir = false;
    private float dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        _facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = 1;
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 2;
        }
        dir = Input.GetAxisRaw("Horizontal");
        if ((dir < 0 && _facingRight) ||
            dir > 0 && !_facingRight)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _isJumping = true;
        }
        else _isJumping = false;
    }

    private void FixedUpdate()
    {
        if (dir != 0)
            transform.Translate(new Vector2(movingSpeed * dir * Time.deltaTime,0));
        if (_isJumping && !_inAir)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }
    public void Flip()
    {
        _facingRight = !_facingRight;
        transform.localScale =
            new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0 && collision.gameObject.CompareTag("Ground"))
        {
            _inAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _inAir = true;
        }
    }
}
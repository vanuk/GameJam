using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool _facingRight;
    private bool _isJumping = false;
    private bool _inAir = true;
    public float dir = 0;

    private Player stats;

    public bool FacingRight => _facingRight;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Player>())
            stats = GetComponent<Player>();
        _facingRight = false;
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
            rb.gravityScale = 3;
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
            transform.Translate(new Vector2(stats.movingSpeed * dir * Time.deltaTime, 0));
        if (_isJumping && !_inAir)
        {
            rb.AddForce(Vector2.up * stats.jumpPower, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    public void Flip()
    {
        _facingRight = !_facingRight;
        var locScale = transform.localScale;
        locScale.x *= -1;
        transform.localScale = locScale;
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
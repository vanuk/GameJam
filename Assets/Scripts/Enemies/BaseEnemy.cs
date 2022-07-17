using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public float viewDistance;
    public float damage;
    public float hp;
    public float movementSpeed;

    public bool facingRight;
    public int dir;
    public EnemyState currentState;
    public GameObject player;
    public LayerMask wallLayer;
    private float reloadTime = 1, reloadCounter = 0;

    private void Awake()
    {
        facingRight = true;
        wallLayer = LayerMask.GetMask("Wall");
        if (FindObjectOfType<Player>())
            player = FindObjectOfType<Player>().gameObject;
    }

    public void Flip()
    {
        facingRight = !facingRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() && Time.time - reloadCounter > reloadTime)
        {
            var pl = other.gameObject.GetComponent<Player>();
            reloadCounter = Time.time;
            pl.hp -= damage;
            Debug.Log(pl.hp);
            if (pl.hp <= 0)
                Destroy(pl.gameObject);
        }
        else if (other.gameObject.GetComponent<Bullet>())
        {
            hp = -player.GetComponent<Player>().damage;
            Destroy(other.gameObject);
            if (hp <= 0)
                Destroy(this.gameObject);
        }
    }
}

public enum EnemyState
{
    Idle,
    Chase
}
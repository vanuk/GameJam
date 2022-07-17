using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeTime = 2, counter = 0;
    private int speed = 12;
    private bool right;

    private void Update()
    {
        if (counter != 0 && Time.time - counter <= 2)
        {
            transform.Translate(new Vector3(right? speed * Time.deltaTime: -speed * Time.deltaTime, 0,0));
        }
        else if (counter != 0 && Time.time - counter > 2)
        {
            Destroy(gameObject);
        }
        
    }

    public void Instantiate(bool facingRight)
    {
        counter = Time.time;
        right = facingRight;
    }
}

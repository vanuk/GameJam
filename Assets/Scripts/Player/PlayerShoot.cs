using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject gun, bullet;
    public Player stats;
    public PlayerController controller;
    private float reloadCounter = 0;
    void Start()
    {
        if (GetComponent<Player>())
            stats = GetComponent<Player>();
        if (GetComponent<PlayerController>())
            controller = GetComponent<PlayerController>();
        reloadCounter = Time.time;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && Time.time - reloadCounter > stats.reloadSpeed)
        {
            reloadCounter = Time.time;
            Shoot();
        }
    }

    public void Shoot()
    {
        var bulletObj = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        if (!controller.FacingRight)
        {
            var locScale = bulletObj.transform.localScale;
            locScale.x *= -1;
            bulletObj.transform.localScale = locScale;
        }

        var scr = bulletObj.GetComponent<Bullet>();
        if(scr)
            scr.Instantiate(controller.FacingRight);


    }
}

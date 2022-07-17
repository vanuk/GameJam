using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : BaseEnemy
{
    private void Start()
    {
        dir = 1;
    }

    private void Update()
    {
        CheckWall();

        if (SearchPlayer())
        {
            var origin = transform.position;
            var destination = player.transform.position;
            if(origin.x > destination.x && facingRight || origin.x < destination.x && !facingRight)
                Flip();
            ChasePlayer();

        }
        else
        {
            if ((dir == -1 && facingRight) || (dir == 1 && !facingRight))
                Flip();
            Idle();
            
        }
    }

    public void CheckWall()
    {
        var origin = transform.position;
        if (Physics2D.Raycast(origin, Vector2.left, 0.7f, wallLayer) && CompareFloat(dir, -1))
            dir = 1;
        else if (Physics2D.Raycast(origin, Vector2.right, 0.7f, wallLayer) && CompareFloat(dir, 1))
           dir = -1;
    }
    public void Idle()
    {
        transform.Translate(new Vector3(dir * movementSpeed, 0, 0) * Time.deltaTime);
    }

    public bool SearchPlayer()
    {
        if (player)
        {
            var origin = transform.position;
            var destination = player.transform.position;
            var direction = destination - origin;
            if ((origin - destination).magnitude < viewDistance)
            {
                return !Physics2D.Raycast(origin, direction, (origin - destination).magnitude, wallLayer);
            }
        }

        return false;
    }

    public void ChasePlayer()
    {
        var origin = transform.position;
        var destination = player.transform.position;
        destination.y = origin.y;
        transform.position = Vector3.MoveTowards(origin, destination, movementSpeed * Time.deltaTime);
    }

    public bool CompareFloat(float a, float b)
    {
        var numb = 0.0001;
        return (a < b + numb && a > b - numb);

    }
}

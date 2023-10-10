using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform player;

    public float speed;
    public float agroRange;

    void Start() => physic = GetComponent<Rigidbody2D>();

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange - 0.2)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }

   // private int dx = player.position.x - transform.position.x;
   //private int dy = player.position.y - transform.position.y;

    void StartHunting()
    {
        if ((player.position.x < transform.position.x) && (player.position.y < transform.position.y))
        {
            physic.velocity = new Vector2(-speed, -speed);
            transform.localScale = new Vector2(1, 1);
        }
        else if ((player.position.x < transform.position.x) && (player.position.y > transform.position.y))
        {
            physic.velocity = new Vector2(-speed, speed);
            transform.localScale = new Vector2(1, 1);
        }
        else if ((player.position.x > transform.position.x) && (player.position.y < transform.position.y))
        {
            physic.velocity = new Vector2(speed, -speed);
            transform.localScale = new Vector2(-1, 1);
        }
        else if ((player.position.x > transform.position.x) && (player.position.y > transform.position.y))
        {
            physic.velocity = new Vector2(speed, speed);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
}

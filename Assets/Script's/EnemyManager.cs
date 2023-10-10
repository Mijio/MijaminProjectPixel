using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] Points;
    private int randomSpot;
    private float waitTime;
    private float Startwaittime;

    private Rigidbody2D physic;

    public Transform player;

    public Animator goblin_animator;

    public float speed;
    public float agroRange;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        waitTime = Startwaittime;
        randomSpot = Random.Range(0, Points.Length);
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if ((distToPlayer < agroRange) && (distToPlayer > 0.1))
        {
            goblin_animator.SetFloat("HorizontalMove", 1);
            StartHunting();
        }
        else if ((distToPlayer > agroRange))
        {
            goblin_animator.SetFloat("HorizontalMove", 1);
            StopHunting();
            Walking();
        }
        else
        {
            goblin_animator.SetFloat("HorizontalMove", 0);
            StopHunting();
        }

    }

    void StartHunting()
    {
        if ((player.position.x < transform.position.x) && (player.position.y < transform.position.y))
        {
            physic.velocity = new Vector2(-speed, -speed);
            transform.localScale = new Vector2(-1, 1);
        }
        else if ((player.position.x < transform.position.x) && (player.position.y > transform.position.y))
        {
            physic.velocity = new Vector2(-speed, speed);
            transform.localScale = new Vector2(-1, 1);
        }
        else if ((player.position.x > transform.position.x) && (player.position.y < transform.position.y))
        {
            physic.velocity = new Vector2(speed, -speed);
            transform.localScale = new Vector2(1, 1);
        }
        else if ((player.position.x > transform.position.x) && (player.position.y > transform.position.y))
        {
            physic.velocity = new Vector2(speed, speed);
            transform.localScale = new Vector2(1, 1);
        }
        else if((player.position.x == transform.position.x) && (player.position.y < transform.position.y))
        {
            physic.velocity = new Vector2(0, -speed);
        }
        else if((player.position.x == transform.position.x) && (player.position.y > transform.position.y))
        {
            physic.velocity = new Vector2(0, speed);
        }
    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }

    void Walking()
    {
        transform.position = Vector2.MoveTowards(transform.position, Points[randomSpot].position, (speed/2) * Time.deltaTime);
        if (Vector2.Distance(transform.position, Points[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = Startwaittime;
                randomSpot = Random.Range(0, Points.Length);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

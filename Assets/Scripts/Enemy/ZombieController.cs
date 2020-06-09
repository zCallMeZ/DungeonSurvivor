﻿using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] float speed = 3f;

    // Variables for waypoint graph
    [SerializeField] Transform[] waypoints;
    int waypointIndex = 0;

    Animator animator;

    // Bool for animations
    bool isFollowingPlayer = false;
    enum State
    {
        WALK,
        ALERT,
        PURSUIT,
        ATTACKPLAYER,
        DEATH
    }

    State state = State.WALK;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        if (!isFollowingPlayer)
        {
            Move();
        }

        if (isFollowingPlayer)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        Vector3 direction = transform.position - waypoints[waypointIndex].transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void ZombieBehavior()
    {
        //TODO(@Solange) Where is the code?
        switch (state)
        {
            case State.WALK:
            
                break;

            case State.ALERT:

                break;

            case State.PURSUIT:

                break;

            case State.ATTACKPLAYER:
                //Alert other zombien
                
                
                //Attack Player
                break;

            case State.DEATH:
                Destroy(gameObject);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isFollowingPlayer = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            animator.SetBool("IsAttackPlayer", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isFollowingPlayer = false;
        }
    }
}

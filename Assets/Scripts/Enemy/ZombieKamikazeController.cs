using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKamikazeController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 4f;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;
    Vector3 initialPosition;

    bool isAttack = false;
    bool isFollowingPlayer = false;

    enum State
    {
        IDLE,
        FOLLOW,
        ATTACK,
        DEAD
    }

    State state = State.IDLE;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    void Update()
    {
        switch (state)
        {
            case State.IDLE:

                transform.position = initialPosition;

                if (isFollowingPlayer)
                {
                    state = State.FOLLOW;
                }

                break;

            case State.FOLLOW:

                moveCharacter();

                if (!isFollowingPlayer)
                {
                    state = State.IDLE;
                }

                if (isAttack)
                {
                    state = State.ATTACK;
                }

                break;

            case State.ATTACK:

                break;

            case State.DEAD:

                break;
        }
    }

    private void moveCharacter()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isFollowingPlayer = true;
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

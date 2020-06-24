using System.Collections.Generic;
using UnityEngine;

//TODO Mettre des commentaires + Ranger le code + Attention nombres magiques

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private Transform player;
    private SpriteRenderer colorZombieState;
    private ZombieHealth zombieHealth;
    private Rigidbody2D rb;
    private Animator animator;
    private Pathfinding pathfinding;

    private Vector2 movement;

    private Vector3 target;
    private Vector3 initialPosition;

    private bool isAttack = false;
    private bool isFollowingPlayer = false;

    enum State
    {
        IDLE,
        FOLLOW,
        RETURN_INITIALPOSITION,
        ATTACK,
        DEAD,
    }

    State state = State.IDLE;

    private void Start()
    {
        colorZombieState = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        player = FindObjectOfType<PlayerController>().transform;
        zombieHealth = GetComponent<ZombieHealth>();
        pathfinding = FindObjectOfType<Pathfinding>();
    }

    private void Update()
    {
        if (!zombieHealth.IsAlive())
        {
            state = State.DEAD;
        }
        switch (state)
        {
            case State.IDLE:

                colorZombieState.color = Color.white;

                if (isFollowingPlayer)
                {
                    state = State.FOLLOW;
                }
                break;

            case State.FOLLOW:

                {
                    colorZombieState.color = Color.red;

                    List<Node> path = pathfinding.FindPath(transform.position, player.position);
                    if (path != null)
                    {
                        target = path[0].worldPos;
                        MoveCharacter();
                    }

                    if (!isFollowingPlayer)
                    {
                        rb.velocity = Vector2.zero;
                        state = State.IDLE;
                    }

                    if (isAttack)
                    {
                        state = State.ATTACK;
                    }
                }

                break;

            case State.RETURN_INITIALPOSITION:

                {
                    List<Node> path = pathfinding.FindPath(transform.position, initialPosition);
                    if (path != null)
                    {
                        target = path[0].worldPos;
                        MoveCharacter();
                    }
                }

                break;

            case State.ATTACK:

                colorZombieState.color = Color.blue;

                MoveCharacter();

                animator.SetBool("IsAttackPlayer", true);

                if (!isAttack)
                {
                    rb.velocity = Vector2.zero;
                    state = State.IDLE;
                    animator.SetBool("IsAttackPlayer", false);
                }

                break;

            case State.DEAD:

                animator.SetBool("isDead", true);
                Destroy(this);
                Destroy(gameObject, 1.0f);

                break;
        }
    }

    private void MoveCharacter()
    {
        Vector2 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        rb.velocity = movement * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isFollowingPlayer = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isFollowingPlayer = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isAttack = false;
        }
    }
}

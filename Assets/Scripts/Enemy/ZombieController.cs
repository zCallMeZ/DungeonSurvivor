using UnityEngine;

public class ZombieController : MonoBehaviour
{
    Transform player;
    [SerializeField] private float speed = 3f;

    private SpriteRenderer colorZombieState;

    ZombieHealth zombieHealth;
    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;
    Vector3 initialPosition;

    private bool isAttack = false;
    private bool isFollowingPlayer = false;

    enum State
    {
        IDLE,
        RETURN_IDLE,
        FOLLOW,
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

                colorZombieState.color = Color.red;

                moveCharacter();

                if (!isFollowingPlayer)
                {
                    rb.velocity = Vector2.zero;
                    state = State.IDLE;
                }

                if (isAttack)
                {
                    state = State.ATTACK;
                }

                break;

            case State.ATTACK:

                colorZombieState.color = Color.blue;

                moveCharacter();

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

    private void moveCharacter()
    {
        Vector2 direction = player.position - transform.position;
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

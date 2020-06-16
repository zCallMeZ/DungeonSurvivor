using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] private float speed = 3f;
    Animator animator;

    Vector3 initialPosition;


    private bool isAttack = false;

    // Bool for animations
    private bool isFollowingPlayer = false;

    enum State
    {
        IDLE,
        FOLLOW,
        ATTACK,
        DEAD,
    }

    State state = State.IDLE;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    private void Update()
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

                moveCharacter();

                animator.SetBool("IsAttackPlayer", true);

                if (!isAttack)
                {
                    state = State.IDLE;
                    animator.SetBool("IsAttackPlayer", false);
                }

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

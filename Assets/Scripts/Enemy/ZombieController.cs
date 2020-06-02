using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] float speed = 3f;

    bool isFollow = false;
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
    }

    void Update()
    {
        if (isFollow)
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
        if (other.tag == "player")
        {
            isFollow = true;
        }
    }
}

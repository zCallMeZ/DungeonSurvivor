using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float speed;
    private Transform target;
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
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        if(isFollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
      
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

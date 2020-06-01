using UnityEngine;

public class ZombieController : MonoBehaviour
{
    enum State
    {
        WALK,
        ALERT,
        ATTACKPLAYER,
        DEATH
    }

    State state = State.WALK;

    private void Update()
    {
        //TODO(@Solange) Where is the code?
        switch (state)
        {
            case State.WALK:
            
                break;

            case State.ALERT:

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
}

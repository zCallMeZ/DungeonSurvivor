using UnityEngine;

public class ZombieController : MonoBehaviour
{
    enum State
    {
        PATROL,
        SEARCH,
        ALERT,
        ATTACKPLAYER,
        DEATH
    }

    State state = State.PATROL;

    private void Update()
    {
        //TODO(@Solange) Where is the code?
        switch (state)
        {
            case State.PATROL:
            
                break;

            case State.SEARCH:
                    
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

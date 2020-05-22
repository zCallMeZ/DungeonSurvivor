using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    enum State
    {
        PATROL,
        SEARCH,
        ATTACK,
        DEATH
    }

    State state = State.PATROL;

    void Start() //TODO(@Solange) Remove this function because it's still called on start eventhough nothing happen. 
    {
        
    }

    private void Update()
    {
        //TODO(@Solange) Where is the code?
        switch (state)
        {
            case State.PATROL:
            
                break;

            case State.SEARCH:
                    
                break;

            case State.ATTACK:
                //Alert other zombien
                
                
                //Attack Player
                break;

            case State.DEATH:
                Destroy(gameObject);
                break;
        }
    }
}

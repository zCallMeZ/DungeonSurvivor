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

    void Start()
    {
        
    }

    private void Update()
    {
        
        switch (state)
        {
            case State.PATROL:

                break;

            case State.SEARCH:

                break;

            case State.ATTACK:

                break;

            case State.DEATH:
                Destroy(gameObject);
                break;
        }

    }
}

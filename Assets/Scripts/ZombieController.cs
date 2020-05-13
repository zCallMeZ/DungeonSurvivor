using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    void Start()
    {
        
    }

    enum State
    {
        PATROLL,
        SEARCH,
        ATTACK,
        DEATH
    }

    State state = State.PATROLL;

    private void Update()
    {
        
        switch (state)
        {
            case State.PATROLL:

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

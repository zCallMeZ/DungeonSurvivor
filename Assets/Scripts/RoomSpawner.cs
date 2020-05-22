using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] int openingDirection;
    //TODO(@Bryan) Instead of writing it here do a enum! It is way easier to read an enum than to come up here to remember what value is which direction.
    // 0 --> need bottom door
    // 1 --> need top door
    // 2 --> need left door
    // 3 --> need right door

    List<Vector2> spawner;

    enum DirectionRoom
    {
        BOTTOM,
        TOP,
        LEFT,
        RIGHT,
        LENGHT
    }

    DirectionRoom state = DirectionRoom.BOTTOM;

    [SerializeField] private GameObject roomTR;
    [SerializeField] private GameObject roomTL;
    [SerializeField] private GameObject roomTB;
    [SerializeField] private GameObject roomT;
    [SerializeField] private GameObject roomRB;
    [SerializeField] private GameObject roomR;
    [SerializeField] private GameObject roomLR;
    [SerializeField] private GameObject roomL;
    [SerializeField] private GameObject roomB;

    bool canSpawn = true;
    int spawnCounter = 0;
    int maxRoom = 5;

    private void Start() //TODO(@Bryan if you're not using this function then delete it, otherwise this function is still called
    {
        if (spawner.Contains(transform.position))
        {
            Destroy(gameObject);
        }
    }

    void Spawner()
    {
        //TODO(@Bryan) This scope is useless
        
            //TODO(@Bryan) Use a switch with the enum for the direction.
           
           
           
           
        
        
        //TODO(@All) A big part is missing, you don't where or which rooms have already been instanciated. You muste fix this. I see two solutions
        /*
         * Solution 1:
         *     The Idea is to have somewhere an array containing all spawn point position and when adding a new one, a check must be done to
         *     see if the point is "free". This array must also be used to check if direction for a new room is possible.
         * Solutions 2:
         *     Use a grid (array 2x2), create the maze inside this grid (DFS, MST, Backtracking, ...) the once you have generated all connections
         *     inside the grid you can start spawning rooms
         */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag ("room")) //TODO(@Bryan) Use modern version (cf PlayerHealth)
        {
            canSpawn = false;
        }
    }
    private void Update()
    {
        //if (canSpawn)
        //{
        //    Spawner();
        //}

        switch (state)
        {
            case DirectionRoom.BOTTOM:

                break;

            case DirectionRoom.TOP:

                if (openingDirection == 1)
                {
                    int rand = Random.Range(0, 4);
                    Debug.Log(rand);
                    if (rand == 0)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomT, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 1)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomTB, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 2)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomTL, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 3) //TODO(@Bryan) You still using Random.Range in the wrong way as 3 is not a possibility with your Random.Range.
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomTR, transform.position, Quaternion.identity);
                        }
                    }
                    canSpawn = false;

                }

                break;

            case DirectionRoom.LEFT:

                if (openingDirection == 2)
                {
                    int rand = Random.Range(0, 3);
                    Debug.Log(rand);
                    if (rand == 0)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomL, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 1)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomLR, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 2) //TODO(@Bryan) Still wrong.
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomTL, transform.position, Quaternion.identity);
                        }
                    }
                    canSpawn = false;

                }

                break;

            case DirectionRoom.RIGHT:

                if (openingDirection == 3)
                {
                    int rand = Random.Range(0, 3);
                    Debug.Log(rand);
                    if (rand == 0)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomR, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 1)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomLR, transform.position, Quaternion.identity);
                        }
                    }
                    else if (rand == 2) //TODO(@Bryan) Still wrong. 
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomRB, transform.position, Quaternion.identity);
                        }
                    }
                    canSpawn = false;

                }

                break;

            case DirectionRoom.LENGHT:

                break;
        }
    }
}


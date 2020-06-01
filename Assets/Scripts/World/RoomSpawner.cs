using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] int openingDirection;
    // 0 --> need bottom door
    // 1 --> need top door
    // 2 --> need left door
    // 3 --> need right door

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
    int maxRoom = 20;

    public static int roomIndex = 0;

    void Start()
    {
        roomIndex++;
    }

    //enum Direction
    //{
    //    BOTTOM = 0,
    //    TOP = 1,
    //    LEFT = 2,
    //    RIGHT = 3
    //}

    void Spawner()
    {
            {
                int rand = Random.Range(0, 3);
                Debug.Log(rand);
                if (rand == 0)
                {
                    if (canSpawn)
                    {
                        Instantiate(roomB, transform.position, Quaternion.identity);
                    }
                }
                else if (rand == 1)
                {
                    if (canSpawn)
                    {
                        Instantiate(roomRB, transform.position, Quaternion.identity);
                    }
                }
                else if (rand == 2)
                {
                    if (canSpawn)
                    {
                        Instantiate(roomTB, transform.position, Quaternion.identity);
                    }
                }
                canSpawn = false;
            }
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
                else if (rand == 3)
                {
                    if (canSpawn)
                    {
                        Instantiate(roomTR, transform.position, Quaternion.identity);
                    }
                }
                canSpawn = false;

            }
            if (openingDirection == 2)
            {
                int rand = Random.Range(0, 2);
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
                else if (rand == 3)
                {
                    if (canSpawn)
                    {
                        Instantiate(roomTL, transform.position, Quaternion.identity);
                    }
                }
                canSpawn = false;

            }
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
                else if (rand == 2)
                {
                    if (canSpawn)
                    {
                        Instantiate(roomRB, transform.position, Quaternion.identity);
                    }
                }
                canSpawn = false;

            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canSpawn = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        canSpawn = true;
    }

    void Update()
    {
        if(roomIndex <= maxRoom)
        {
            if (canSpawn)
            {
                Spawner();
            }
        }
    }
}


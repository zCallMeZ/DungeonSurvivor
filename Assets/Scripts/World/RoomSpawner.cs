using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class RoomSpawner : MonoBehaviour
{
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
    int maxRoom = 20;

    static int roomIndex = 0;
    [SerializeField] Direction openingDirection;

    void Start()
    {
        roomIndex++;
        Debug.Log(roomIndex);
        //StartCoroutine("Coroutine");
    }

    void Update()
    {
       if (canSpawn)
       {
           SpawningRoom();
       }
    }

    enum Direction
    {
        BOTTOM = 0,
        TOP = 1,
        LEFT = 2,
        RIGHT = 3
    }

    void SpawningRoom()
    {
        switch (openingDirection)
        {
            case Direction.BOTTOM:
                {
                    {
                        int rand = Random.Range(0, 3);
                        if (roomIndex < 10)
                        {
                            rand = Random.Range(1, 3);
                        }
                        if (roomIndex >= maxRoom)
                        {
                            rand = 0;
                        }
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
                    break;
                }
            case Direction.TOP:
                {
                    int rand = Random.Range(0, 4);
                    if (roomIndex < 10)
                    {
                        rand = Random.Range(1, 4);
                    }
                    if (roomIndex >= maxRoom)
                    {
                        rand = 0;
                    }
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
                break;
            case Direction.LEFT:
                {
                    int rand = Random.Range(0, 3);
                    if (roomIndex < 10)
                    {
                        rand = Random.Range(1, 3);
                    }
                    if (roomIndex >= maxRoom)
                    {
                        rand = 0;
                    }
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
                    else if (rand == 2)
                    {
                        if (canSpawn)
                        {
                            Instantiate(roomTL, transform.position, Quaternion.identity);
                        }
                    }
                    canSpawn = false;

                }
                break;
            case Direction.RIGHT:
                {
                    int rand = Random.Range(0, 3);
                    if (roomIndex < 10)
                    {
                        rand = Random.Range(1, 3);
                    }
                    if (roomIndex >= maxRoom)
                    {
                        rand = 0;
                    }
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
                break;
        }
    }

    void SpawnEnnemy()
    {

    }

    void SpawnHealthObject()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canSpawn = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject.transform.parent);
        }    
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        canSpawn = true;
    }



    //IEnumerator Coroutine()
    //{
    //    while (roomIndex <= maxRoom)
    //    {
    //        yield return new WaitForSeconds(1);
    //        if (canSpawn)
    //        {
    //            Spawner();
    //        }
    //    }
    //}
}


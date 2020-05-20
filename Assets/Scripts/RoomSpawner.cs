using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int maxRoom = 5;

    private void Start()
    {

    }
    private void Update()
    {
        Spawner();
    }

    void Spawner()
    {
        if (canSpawn)
        {
            if (openingDirection == 0)
            {
                int rand = Random.Range(0, 2);
                Debug.Log(rand);
                if (rand == 0)
                {
                    Instantiate(roomB, transform.position, Quaternion.identity);
                }
                else if (rand == 1)
                {
                    Instantiate(roomRB, transform.position, Quaternion.identity);
                }
                else if (rand == 2)
                {
                    Instantiate(roomTB, transform.position, Quaternion.identity);
                }
                canSpawn = false;
            }
            if (openingDirection == 1)
            {
                int rand = Random.Range(0, 3);
                Debug.Log(rand);
                if (rand == 0)
                {
                    Instantiate(roomT, transform.position, Quaternion.identity);
                }
                else if (rand == 1)
                {
                    Instantiate(roomTB, transform.position, Quaternion.identity);
                }
                else if (rand == 2)
                {
                    Instantiate(roomTL, transform.position, Quaternion.identity);
                }
                else if (rand == 3)
                {
                    Instantiate(roomTR, transform.position, Quaternion.identity);
                }
                canSpawn = false;

            }
            if (openingDirection == 2)
            {
                int rand = Random.Range(0, 2);
                Debug.Log(rand);
                if (rand == 0)
                {
                    Instantiate(roomL, transform.position, Quaternion.identity);
                }
                else if (rand == 1)
                {
                    Instantiate(roomLR, transform.position, Quaternion.identity);
                }
                else if (rand == 2)
                {
                    Instantiate(roomTL, transform.position, Quaternion.identity);
                }
                canSpawn = false;

            }
            if (openingDirection == 3)
            {
                int rand = Random.Range(0, 2);
                Debug.Log(rand);
                if (rand == 0)
                {
                    Instantiate(roomR, transform.position, Quaternion.identity);
                }
                else if (rand == 1)
                {
                    Instantiate(roomLR, transform.position, Quaternion.identity);
                }
                else if (rand == 2)
                {
                    Instantiate(roomRB, transform.position, Quaternion.identity);
                }
                canSpawn = false;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "room")
        {
            canSpawn = false;
        }
    }
}


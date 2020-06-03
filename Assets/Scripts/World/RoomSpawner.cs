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

    private bool canSpawn = true;
    private int maxRoom = 20;

    private static int roomIndex = 0;
    [SerializeField] private Direction openingDirection;

    enum Direction : short
    {
        BOTTOM = 0,
        TOP,
        LEFT,
        RIGHT
    }
    void Start()
    {
        roomIndex++;
    }

    void Update()
    {
        if (canSpawn)
        {
            SpawningRoom();
        }
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

}


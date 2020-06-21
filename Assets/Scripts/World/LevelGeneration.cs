using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelGeneration : MonoBehaviour
{
   [SerializeField] private Transform[] startingPositions;
   [SerializeField] private GameObject [] rooms;

   [SerializeField] private Transform player;
   [SerializeField] private GameObject zombieClassic;
   [SerializeField] private GameObject zombieKamikaze;

   [SerializeField] private Transform[] boxPos;
   [SerializeField] private GameObject winBox;
   
   private int direction;
   private int directionDefault = 5; // Move Down
   private int randRoom;

   private float moveAmountHorizontal = 12f;
   private float moveAmountVertical = 10f;
   private float timeBtwRoom;
   [SerializeField] float startTimeBtwRoom = 0.25f;

   [SerializeField] private float minX;
   [SerializeField] private float maxX;
   [SerializeField] private float minY;
   public bool stopLevelGeneration = false;
   private bool canSpawn = true;

   [SerializeField] private RoomIndex roomIndex;
   [SerializeField] private LayerMask room;

   private int downCounter;

   enum RoomIndex : short
   {
      LR = 0,
      LRB,
      LRT,
      LRBT
   }

   private void Start()
   {
      int randStartingPos = Random.Range(0, startingPositions.Length);
      transform.position = startingPositions[randStartingPos].position;
      Instantiate(rooms[0], transform.position, Quaternion.identity);
      player.position = startingPositions[randStartingPos].position;
      direction = Random.Range(1, 6);
      
      int randBoxPos = Random.Range(1, 4);
      Instantiate(winBox, boxPos[randBoxPos].transform.position, Quaternion.identity);
   }

   private void Update()
   {
      if (timeBtwRoom <= 0 && stopLevelGeneration == false)
      {
         Move();
         timeBtwRoom = startTimeBtwRoom;
      }
      else
      {
         {
            timeBtwRoom -= Time.deltaTime;
         }
      }
   }

   private void Move()
   {
      if (direction == 1 || direction == 2) // Move Right !
      {
         if (transform.position.x < maxX)
         {
            downCounter = 0;
            
            Vector2 newPos = new Vector2(transform.position.x + moveAmountHorizontal, transform.position.y);
            transform.position = newPos;

            int randRoom = Random.Range(0, rooms.Length);
            Instantiate(rooms[randRoom], transform.position, Quaternion.identity);
            SpawnEnnemy();

            direction = Random.Range(1, 6);
            if (direction == 3)
            {
               direction = 2;
            }
            else if (direction == 4)
            {
               direction = directionDefault;
            }
         }
         else
         {
            direction = directionDefault;
         }

      }
      else if (direction == 3 || direction == 4) // Move Left !
      {
         if (transform.position.x > minX)
         {
            downCounter = 0;

            Vector2 newPos = new Vector2(transform.position.x - moveAmountHorizontal, transform.position.y);
            transform.position = newPos;
            
            int randRoom = Random.Range(0, 3);
            Instantiate(rooms[randRoom], transform.position, Quaternion.identity);
            SpawnEnnemy();

            direction = Random.Range(3, 6);
         }
         else
         {
            direction = directionDefault;
         }

      }
      else if (direction == 5) // Move Down !
      {
         downCounter++;
         
         if (transform.position.y > minY)
         {
            Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
            if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
            {
               if (downCounter >= 2)
               {
                  roomDetection.GetComponent<RoomType>().RoomDestruction();
                  Instantiate(rooms[3], transform.position, quaternion.identity);
               }

               else
               {
                  roomDetection.GetComponent<RoomType>().RoomDestruction();

                  int randBottomRoom = Random.Range(1, 4);
                  if (randBottomRoom == 2)
                  {
                     randBottomRoom = 1;
                  }

                  Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
               }
            }

            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountVertical);
            transform.position = newPos;

            Instantiate(rooms[1], transform.position, Quaternion.identity);
            SpawnEnnemy();
            
            direction = Random.Range(1, 6);
         }
         else
         {
            stopLevelGeneration = true;
         }

      }
   }
   
   void SpawnEnnemy()
   {
      int rand = Random.Range(0, 3);
      if (rand == 0)
      {
         Instantiate(zombieKamikaze, transform.position, Quaternion.identity);
      }
      else
      {
         Instantiate(zombieClassic, transform.position, Quaternion.identity);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("room"))
      {
         canSpawn = false;
      }
   }
}

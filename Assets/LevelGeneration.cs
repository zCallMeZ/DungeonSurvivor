using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelGeneration : MonoBehaviour
{
   [SerializeField] private Transform[] startingPositions;
   [SerializeField] private GameObject [] rooms;

   private int direction;
   private int directionDefault = 5; // Move Down

   private float moveAmountHorizontal = 12f;
   private float moveAmountVertical = 10f;
   private float timeBtwRoom;
   [SerializeField] float startTimeBtwRoom = 0.25f;

   [SerializeField] private float minX;
   [SerializeField] private float maxX;
   [SerializeField] private float minY;
   private bool stopLevelGeneration = false;

   private void Start()
   {
      int randStartingPos = Random.Range(0, startingPositions.Length);
      transform.position = startingPositions[randStartingPos].position;
      Instantiate(rooms[0], transform.position, Quaternion.identity);
      
      direction = Random.Range(1, 6);
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
            Vector2 newPos = new Vector2(transform.position.x + moveAmountHorizontal, transform.position.y);
            transform.position = newPos;            
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
            Vector2 newPos = new Vector2(transform.position.x - moveAmountHorizontal, transform.position.y);
            transform.position = newPos;            
         }
         else
         {
            direction = directionDefault;
         }

      }
      else if (direction == 5) // Move Down !
      {
         if (transform.position.y > minY)
         {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountVertical);
            transform.position = newPos;            
         }
         else
         {
            stopLevelGeneration = true;
         }
      }

      Instantiate(rooms[0], transform.position, Quaternion.identity);
      direction = Random.Range(1, 6);
   }
}

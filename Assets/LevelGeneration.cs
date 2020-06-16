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
   private float moveAmountHorizontal = 12f;
   private float moveAmountVertical = 10f;
   private float timeBtwRoom;
   [SerializeField] float startTimeBtwRoom = 0.25f;

   private int roomIndex;
   private int maxRoom = 20;
   private void Start()
   {
      int randStartingPos = Random.Range(0, startingPositions.Length);
      transform.position = startingPositions[randStartingPos].position;
      Instantiate(rooms[0], transform.position, Quaternion.identity);
      
      direction = Random.Range(1, 6);
   }

   private void Update()
   {
      if (timeBtwRoom <= 0)
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
         Vector2 newPos = new Vector2(transform.position.x + moveAmountHorizontal, transform.position.y);
         transform.position = newPos;
      }
      if (direction == 3 || direction == 4) // Move Left !
      {
         Vector2 newPos = new Vector2(transform.position.x - moveAmountHorizontal, transform.position.y);
         transform.position = newPos;
      }
      if (direction == 5) // Move Down !
      {
         Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmountVertical);
         transform.position = newPos;
      }

      Instantiate(rooms[0], transform.position, Quaternion.identity);
      direction = Random.Range(1, 6);
   }
}

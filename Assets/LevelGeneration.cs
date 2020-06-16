using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGeneration : MonoBehaviour
{
   [SerializeField] private Transform[] startingPositions;

   private void Start()
   {
      int randStartingPos = Random.Range(0, startingPositions.Length);
      transform.position = startingPositions[randStartingPos].position;
   }
}

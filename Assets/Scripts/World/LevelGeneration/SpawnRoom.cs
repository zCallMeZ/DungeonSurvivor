using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private LayerMask whatIsRoom;
    [SerializeField] private GameObject zombieClassic;

    private LevelGeneration levelGeneration;

    private void Start()
    {
        levelGeneration = FindObjectOfType<LevelGeneration>();
    }

    private void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        bool stopLevelGeneration = levelGeneration.GetStopLevelGeneration();
        
        if (roomDetection == null && stopLevelGeneration == true)
        {
            Instantiate(room, transform.position, Quaternion.identity);
            Instantiate(zombieClassic, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private LayerMask whatIsRoom;

    public LevelGeneration levelGeneration;
    private void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if (roomDetection == null && levelGeneration.stopLevelGeneration == true)
        {
            Instantiate(room, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

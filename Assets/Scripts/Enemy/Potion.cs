using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private bool destroyPotion = false;
    private float currHealth;

    private float maxHealth = 100.0f;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        currHealth = playerHealth.GetPlayerLife();
        if(destroyPotion)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && currHealth < maxHealth)
        {
            destroyPotion = true;
        }
    }
}

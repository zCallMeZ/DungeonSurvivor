using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private bool destroyPotion = false;

    private float maxHealth = 100.0f;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        float curHealth = playerHealth.GetPlayerLife();
        
        if (curHealth < maxHealth && destroyPotion == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            destroyPotion = true;
        }
    }
}

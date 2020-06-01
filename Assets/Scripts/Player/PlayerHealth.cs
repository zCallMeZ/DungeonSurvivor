using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    float totalHealth = 100f;
    float highDmg = 5f;
    float normalDmg = 5f;
    float lowDmg = 5f;
    float health = 10f;

    enum DmgType {
        HIGH,
        NORMAL,
        LOW
    }
    
    Score score;
    [SerializeField] private TextMeshProUGUI healthText; //TODO(@Bryan) The variable score (which is private) doesn't have the modifier private, but this one does. Make a choice.

    private void Start()
    {
        totalHealth = 100f; //TODO(@Bryan) If it's a const value, then don't reassign it the start function.
    }
    private void Update()
    {
        healthText.text = totalHealth.ToString("F0");

        if (totalHealth <= 0f)
        {
            totalHealth = 0f;
        }
    }

    //TODO(@Bryan) Those 3 functions do exactly the same thing. You could use a unique function with a parameter. The parameter can be an enum (HIGH, NORMAL, LOW)
    void TakeHighDmg() //TODO(@Bryan) This function is private but you don't use the modifier "private"
    {
        health -= highDmg;
    }

    void TakeNormalDmg()
    {
        health -= normalDmg;
    }

    void TakeLowDmg()
    {
        health -= lowDmg;
    }

    private void TakeHealth()
    {
        totalHealth += health;

        if (totalHealth >= 100f) //TODO(@Bryan) Magic number. You can create a const variable called MAX_HEALTH
        {
            totalHealth = 100f; //TODO(@Bryan) Magic number.
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie1") //TODO(@Bryan) Use more modern function collision.gameobject.CompareTage("zombie1")
        {
            TakeLowDmg();
            score.GetLowPoint();
        }
        if (collision.gameObject.tag == "zombie2")
        {
            TakeNormalDmg();
            score.GetNormalPoint();
        }
        if (collision.gameObject.tag == "zombie3")
        {
            TakeHighDmg();
            score.GetHighPoint();
        }
        if (collision.gameObject.tag == "health")
        {
            TakeHealth();
        }
    }
}

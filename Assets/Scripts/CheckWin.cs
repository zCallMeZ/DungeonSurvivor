using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private bool isWin = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("chest"))
        {
            isWin = true;
        }
    }

    public bool GetIsWin()
    {
        return isWin;
    }
}

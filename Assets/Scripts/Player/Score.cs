using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    float totalPoint = 0f;
    float highPoint = 10f;
    float normalPoint = 50f;
    float lowPoint = 10f;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        totalPoint = 0f; //TODO(@Bryan) You don't need to reasign the exact same value than when declaring the variable.
    }
    private void Update()
    {
        scoreText.text = totalPoint.ToString("F0");
    }

    //TODO(@Bryan) The name of the function is misleading. It begin with a Get, so I'm thinking that I will have a return value which is not the case. Rename them to Set or Add
    //TODO(@Bryan) Those three function does the same thing. You could add a parameter using an enum.
    public void GetHighPoint()
    {
        totalPoint += highPoint;
    }

    public void GetNormalPoint()
    {
        totalPoint += normalPoint;
    }

    public void GetLowPoint()
    {
        totalPoint += lowPoint;
    }

}


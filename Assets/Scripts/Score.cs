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
        totalPoint = 0f;
    }
    private void Update()
    {
        scoreText.text = totalPoint.ToString("F0");
    }

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


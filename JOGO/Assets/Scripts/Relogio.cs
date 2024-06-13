using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Relogio : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;
    [SerializeField] private float timeValue;

    void Start()
    {
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    private void UpdateTime()
    {
        if (timeValue >= 0f)
        {
            timeValue++;
            DisplayTime(timeValue);
        }
    }

    private void DecreaseTime()
    {
        if (timeValue < 0f) return;

        timeValue--;

        DisplayTime(timeValue);
    }

    private void IncreaseTime()
    {
        if (timeValue < 0f) return;

        timeValue++;

        DisplayTime(timeValue);
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0f)
        {
            timeToDisplay = 0f;
        }

        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);

        txtTime.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }

}

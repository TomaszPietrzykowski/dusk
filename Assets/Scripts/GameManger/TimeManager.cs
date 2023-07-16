using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeMultiplier;
    
    [SerializeField] private float startHour;

    [SerializeField] private TextMeshProUGUI clock;
    
    private DateTime currentTime;
    
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
    }

    void Update()
    {
        UpdateTimeOfDay();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (clock != null)
        {
            clock.text = currentTime.ToString("HH:mm");
        }
    } 
}

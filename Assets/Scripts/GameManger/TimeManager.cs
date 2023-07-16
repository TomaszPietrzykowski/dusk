using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Time settings:")]
    [SerializeField] 
    private float timeMultiplier = 100f;
    
    [SerializeField] 
    private float sunriseHour;

    [SerializeField] 
    private float sunsetHour;

    [SerializeField] 
    private float startHour = 8f;

    [Header("Light settings")]
    [SerializeField]
    private float sunAngle = 20f;

    [SerializeField]
    private float moonAngle = -30f;
    
    [SerializeField] 
    private float maxSunLightIntensity;

    [SerializeField] 
    private float maxMoonLightIntensity;

    [SerializeField] 
    private Color dayAmbientLight;

    [SerializeField] 
    private Color nightAmbientLight;

    [SerializeField] 
    private AnimationCurve lightChangeCurve;

    [SerializeField] 
    private TextMeshProUGUI clock;

    [SerializeField] 
    private Light sunLight;

    [SerializeField] 
    private Light moonLight;

    [SerializeField] 
    private TimeSpan sunriseTime;

    [SerializeField] 
    private TimeSpan sunsetTime;
    
    private DateTime currentTime;
    
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (clock != null)
        {
            clock.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        float sunLightRotation;
        float moonLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
            moonLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
            moonLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right) * Quaternion.AngleAxis(sunAngle, Vector3.up);
        moonLight.transform.rotation = Quaternion.AngleAxis(moonLightRotation, Vector3.right) * Quaternion.AngleAxis(moonAngle, Vector3.up);
    }


    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}

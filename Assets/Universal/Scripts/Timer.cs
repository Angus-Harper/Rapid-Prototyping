using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime;
    bool isTiming = false;
    void Update()
    {
        if (isTiming)
        {
            currentTime += Time.deltaTime;
        }
    }
    /// <summary>
    /// starts the timer from 0 nad increments in real time seconds
    /// </summary>
    public void StartTimer()
    {
        isTiming = true;
        currentTime = 0;
    }
    /// <summary>
    /// will resume the timer from the previously pause time
    /// </summary>
    public void ResumeTimer()
    {
        isTiming = true;
    }
    /// <summary>
    /// will pause the timer, with the intention to resume
    /// </summary>
    public void PauseTimer()
    {
        isTiming = false;
    }
    /// <summary>
    /// stops the timer from timing
    /// </summary>
    public void StopTimer()
    {
        isTiming = false;
    }
    /// <summary>
    /// Gets the current time of the timer
    /// </summary>
    /// <returns>the current time of the timer</returns>
    public float GetTimer()
    {
        return currentTime;
    }
    /// <summary>
    /// Are we timing or not?
    /// </summary>
    /// <returns>True if we are timing</returns>
    public bool IsTiming()
    {
        return isTiming;
    }
}

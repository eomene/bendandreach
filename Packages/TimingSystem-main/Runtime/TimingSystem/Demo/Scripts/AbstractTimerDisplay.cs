using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Remember, any implementation of a timer display can be created with its own custom functionality. The class just needs to implement IAbstractTimerConsumer and be attached to the 
/// same gameobject as the timer
/// </summary>
public class AbstractTimerDisplay : MonoBehaviour, IAbstractTimerConsumer
{
    public string timerKeyToUse;
    public Text timeText;

    public void onTimerEnded()
    {
     
    }

    public void onTimerUpdated(CradaptiveTimerClass timerValue)
    {
        if (timerKeyToUse != timerValue.key) return;
        UpdateDisplay(timerValue.timer);
    }

    public void UpdateDisplay(float timeValue)
    {
        float seconds = Mathf.FloorToInt(timeValue % 60);
        if (seconds >= 0)
            timeText.text = string.Format("{0}", seconds);

    }

}

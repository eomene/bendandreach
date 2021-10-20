using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Remember, any implementation of a timer display can be created with its own custom functionality. The class just needs to implement IAbstractTimerConsumer and be attached to the 
/// same gameobject as the timer
/// </summary>
public class AbstractTimerFillDisplay : MonoBehaviour, IAbstractTimerConsumer
{
    public string timerKeyToUse;
    public Image image;

    public void onTimerEnded()
    {
        image.fillAmount = 1;
    }

    public void onTimerUpdated(CradaptiveTimerClass timerValue)
    {
        if (timerKeyToUse != timerValue.key) return;
        if (timerValue.timer > 0)
            image.fillAmount = timerValue.timer / timerValue.maxTime;
     
    }



}

using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTimerExample : MonoBehaviour
{
    AbstractTimer abstractTimer;

    // Start is called before the first frame update
    void Awake()
    {
        abstractTimer = GetComponent<AbstractTimer>();
    }

    [ContextMenu("StartDownTimer")]
    public void StartTickDownTimer()
    {
        abstractTimer.StartTickDownTimer("timerUniqueKeyTickDown", "My friendly name tick down", 15, () =>
        {
            Debug.LogError("My Timer Ended...Yaay!");
        });
    }


    [ContextMenu("StartTickUpTimer")]
    public void StartTickUpTimerCountTillManualStop()
    {
        abstractTimer.StartTickUpTimer("timerUniqueKeyTickUp", "My friendly name tick up", () =>
        {
            Debug.LogError("My Timer Ended...Yaay!");
        });
    }

    [ContextMenu("StopTickUpTimer")]
    public void StopTickUpTimer()
    {
        float timeLen = abstractTimer.EndTimer("timerUniqueKey");
        Debug.Log($"My Timer Ended in {timeLen} seconds!");
    }

}

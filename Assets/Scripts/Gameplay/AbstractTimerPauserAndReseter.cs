using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTimerPauserAndReseter : MonoBehaviour, ILocalOnGamePlayPaused, ILocalOnGamePlayEnded
{
    AbstractTimer abstractTimer;

    private void Awake()
    {
        abstractTimer = GetComponent<AbstractTimer>();
    }

    public void OnGamePlayPaused(bool state)
    {
        abstractTimer.PauseTimers(state);
    }

    public void OnGamePlayEnded()
    {
        abstractTimer.EndAllTimers();
    }
}

using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Hooks into the events system of the game to pause the timers from the timing package
/// This can be attached to any gameobject that has an abstract timer, and it would pause the timer
/// when the game is paused.
/// </summary>
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

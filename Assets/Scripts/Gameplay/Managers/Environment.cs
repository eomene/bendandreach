using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the visibility of the environment when the scene is loaded. Uses the Event subscriber to know whent the game
/// has started, so it can toggle visibility based on this
/// </summary>

public class Environment : MonoBehaviour, ILocalOnGamePlayStarted, ILocalOnGamePlayEnded
{
    [SerializeField] GameObject environment;

    // Start is called before the first frame update
    void Awake()
    {
        environment.SetActive(false);
    }

    public void OnGamePlayStarted()
    {
        environment.SetActive(true);
    }

    public void OnGamePlayEnded()
    {
        environment.SetActive(false);
    }
}

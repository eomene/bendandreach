using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

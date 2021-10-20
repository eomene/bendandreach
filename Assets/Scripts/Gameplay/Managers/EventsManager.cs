using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The awake and onenable functions of scriptable objects cant be trusted, so a class is required to initilise as well
/// as unload the events that might have be subscribed to
/// </summary>
public class EventsManager : MonoBehaviour
{

    GamePlayEventsHolder gamePlayEventsHolder;

    private void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        gamePlayEventsHolder.Initialise();
    }


    // Update is called once per frame
    void OnDestroy()
    {
        gamePlayEventsHolder?.Unload();
    }
}

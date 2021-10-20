using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallGeneratorButtonParent : MonoBehaviour
{
    GamePlayEventsHolder gamePlayEventsHolder;

    private void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        gamePlayEventsHolder.onGamePlayStarted.AddListener(Started);
        gamePlayEventsHolder.onGamePlayEnded.AddListener(Ended);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        gamePlayEventsHolder.onGamePlayStarted.RemoveListener(Started);
        gamePlayEventsHolder.onGamePlayEnded.RemoveListener(Ended);
    }

    void Started()
    {
        gameObject.SetActive(true);
    }
    void Ended()
    {
        gameObject.SetActive(false);
    }
}

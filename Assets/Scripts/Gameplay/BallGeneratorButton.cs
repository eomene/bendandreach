using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallGeneratorButton : MonoBehaviour,IDetectedObject,ITag
{
    GamePlayEventsHolder gamePlayEventsHolder;
    [SerializeField] GameConfigHolder.GameSide gameSide;
    bool interactiing;
    public string objectTag => gameSide + "Hand";

    public void OnObjectDetected(GameObject gameObject)
    {
        interactiing = true;
        gamePlayEventsHolder.onGenerateBall?.Invoke(gameSide, () => interactiing = false);
    }

    private void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
    }

}

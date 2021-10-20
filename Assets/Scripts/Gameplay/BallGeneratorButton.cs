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
    ScoresManager ScoresManager;
    protected GameConfigHolder gameConfigHolder;

    public void OnObjectDetected(GameObject gameObject)
    {
        interactiing = true;
        gamePlayEventsHolder.SendOnGenerateBallEvent(gameSide, () => interactiing = false);
        ScoresManager?.UpdateScore(gameConfigHolder.ballGeneratorScore);
    }
  
    private void Awake()
    {
        ScoresManager = GetComponent<ScoresManager>();
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Controls either of the two big buttons on top of the player, using the detector system to know when an object enters
/// or exits it. Then it fires the generate ball event and also adds some score to the player. Since they reached
/// </summary>
public class BallGeneratorButton : MonoBehaviour,IDetectedObject,ITag,ILocalOnGamePlayPaused
{
    GamePlayEventsHolder gamePlayEventsHolder;
    [SerializeField] GameConfigHolder.GameSide gameSide;
    bool interactiing;
    public string objectTag => gameSide + "Hand";
    ScoresManager ScoresManager;
    protected GameConfigHolder gameConfigHolder;
    bool isPaused;

    public void OnObjectDetected(GameObject gameObject)
    {
        if (isPaused) return;
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

    public void OnGamePlayPaused(bool state)
    {
        isPaused = state;
    }
}

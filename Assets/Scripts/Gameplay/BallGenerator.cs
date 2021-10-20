using Cradaptive.AbstractTimer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallGenerator : MonoBehaviour, ITag, IDetectedObject, ILostDetectedObject, ILocalOnGenerateBalls, ILocalOnEnteredGoal
{
    BallDataHolder ballDataHolder;
    [SerializeField] GameConfigHolder gameConfigHolder;
    [SerializeField] Vector3 spawnPositionOffset;
    [SerializeField] GameConfigHolder.GameSide currentGameSide;
    [SerializeField] int currentBallsCount;
    AbstractTimer abstractTimer;
    public string objectTag => gameConfigHolder.ballTagName;
    bool onCombo;
    string comboTimerKey = "comboTimer";

    void Awake()
    {
        if (ballDataHolder == null)
            ballDataHolder = Resources.Load<BallDataHolder>("BallDataHolder");
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        abstractTimer = GetComponent<AbstractTimer>();
    }

    void GenerateBalls(GameConfigHolder.GameSide gameSide, Action onCompleted)
    {

        if (gameSide != currentGameSide)
        {
            onCompleted?.Invoke();
            return;
        }

        if (currentBallsCount < gameConfigHolder.GetMaxCount(currentGameSide))
        {
            BallData ballData = ballDataHolder.GetBall(onCombo);
            ballData.ballSide = gameSide;
            Ball ball = Instantiate(ballData.ballGameObject, transform.position + spawnPositionOffset, Quaternion.identity)?.GetComponent<Ball>();
            if (ball)
                ball.Init(ballData);

            onCombo = true;

        }
        onCompleted?.Invoke();
    }

    public void OnObjectDetected(GameObject gameObject)
    {
        currentBallsCount++;
    }

    public void OnDetectedObjectLost(GameObject gameObject)
    {
        currentBallsCount--;
    }

    public void OnGenerateBalls(GameConfigHolder.GameSide side, Action onComplete)
    {
        GenerateBalls(side, onComplete);
    }

    public void OnEnteredGoal(GameConfigHolder.GameSide gameSide, int score)
    {
        if (gameSide != currentGameSide)
            return;
        
        if (abstractTimer)
        {
            onCombo = true;
            abstractTimer.EndTimer(comboTimerKey, false);
            abstractTimer.StartTickDownTimer(comboTimerKey, comboTimerKey, gameConfigHolder.comboDuration, () =>
            {
                onCombo = false;
            });
        }
    }
}

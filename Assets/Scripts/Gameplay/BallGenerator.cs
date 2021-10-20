using Cradaptive.AbstractTimer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is used for generating balls, ideally we can do object pooling here. But i didnt see the need to implement that
/// The idea is, this ball generating code can be changed to pooling without affecting other parts of the project
/// </summary>
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
        // We need to check if the button for this generator wa pressed before running this logic
        if (gameSide != currentGameSide)
        {
            onCompleted?.Invoke();
            return;
        }

        //We might already have the maximum balls this generator can take, lets check first before creating balls
        if (currentBallsCount < gameConfigHolder.GetMaxCount(currentGameSide))
        {
            ///We can get a ball if its a combo or not
            BallData ballData = ballDataHolder.GetBall(onCombo);
            ballData.ballSide = gameSide;
            Ball ball = Instantiate(ballData.ballGameObject, transform.position + spawnPositionOffset, Quaternion.identity)?.GetComponent<Ball>();
            //initialise the ball with the data we got, so it can be customised
            if (ball)
                ball.Init(ballData);

           // onCombo = true;

        }
        onCompleted?.Invoke();
    }

    /// <summary>
    /// Uses the detector class to know if its specified object was detected or not.
    /// </summary>
    /// <param name="gameObject"></param>
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


    /// <summary>
    /// When a ball enters the goal and we have a timer, we can set up for combos
    /// </summary>
    /// <param name="gameSide"></param>
    /// <param name="score"></param>
    public void OnEnteredGoal(GameConfigHolder.GameSide gameSide, int score)
    {
        if (gameSide != currentGameSide)
            return;
        
        ///if we have a time attached, means we can support combos
        if (abstractTimer)
        {
            //we should generate combo balls now
            onCombo = true;
            //if a combo timer was previously running, lets stop it. Since we need to start a new one
            //as a ball has gone into the goal
            //we also pass in a false, so the callback is not fired from ending the timer like this 
            //or the combo will be turned off
            abstractTimer.EndTimer(comboTimerKey, false);
            ///Starting a new timer with the timing system and using the duration from the comfig
            abstractTimer.StartTickDownTimer(comboTimerKey, comboTimerKey, gameConfigHolder.comboDuration, () =>
            {
                ///the timer elapsed, lets turn the combo off. so normal balls will be created
                onCombo = false;
            });
        }
    }
}

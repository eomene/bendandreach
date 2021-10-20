using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallGenerator : MonoBehaviour, ITag, IDetectedObject, ILostDetectedObject
{
    GamePlayEventsHolder gamePlayEventsHolder;
    BallDataHolder ballDataHolder;
    [SerializeField] GameConfigHolder gameConfigHolder;
    [SerializeField] Vector3 spawnPositionOffset;
    [SerializeField] GameConfigHolder.GameSide currentGameSide;
    [SerializeField] int currentBallsCount;

    public string objectTag => gameConfigHolder.ballTagName;

    void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        if (ballDataHolder == null)
            ballDataHolder = Resources.Load<BallDataHolder>("BallDataHolder");
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        gamePlayEventsHolder.onGenerateBall.AddListener(GenerateBalls);
    }

    private void OnDestroy()
    {
        gamePlayEventsHolder.onGenerateBall.RemoveListener(GenerateBalls);
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
            BallData ballData = ballDataHolder.ballDatas[UnityEngine.Random.Range(0, ballDataHolder.ballDatas.Length)];
            Ball ball = Instantiate(ballData.ballGameObject, transform.position + spawnPositionOffset, Quaternion.identity)?.GetComponent<Ball>();
            if (ball)
                ball.Init(ballData);
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
}

using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour, ITag, IDetectedObject
{
    [SerializeField] GameConfigHolder gameConfigHolder;
    [SerializeField] MotivationDataHolder motivationDataHolder;
    [SerializeField] GamePlayEventsHolder gamePlayEventsHolder;

    ScoresManager scoreKeeper;
    AbstractTimer abstractTimer;
    MotivationSender motivationSender;
    bool canSendMotivation;

    public string objectTag => gameConfigHolder.ballTagName;

    public void OnObjectDetected(GameObject other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            scoreKeeper?.UpdateScore(ball.ballData.score);
            ball?.Unload();
            gamePlayEventsHolder?.SendOnEnteredGoalEvent(ball.ballData.ballSide,ball.ballData.score);
            if (canSendMotivation)
            {
                canSendMotivation = false;
                string data = motivationDataHolder.data[Random.Range(0, motivationDataHolder.data.Length)].message;
                motivationSender?.SendMotivation(data);
                abstractTimer.StartTickDownTimer("timeBetweenMotivation", "timeBetweenMotivation", gameConfigHolder.timeBetweenMotivations, () =>
                {
                    canSendMotivation = true;
                });
            }
        }
    }

    private void Awake()
    {
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        if (motivationDataHolder == null)
            motivationDataHolder = Resources.Load<MotivationDataHolder>("MotivationDataHolder");
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        scoreKeeper = GetComponent<ScoresManager>();
        abstractTimer = GetComponent<AbstractTimer>();
        motivationSender = GetComponent<MotivationSender>();
        canSendMotivation = true;
    }

}

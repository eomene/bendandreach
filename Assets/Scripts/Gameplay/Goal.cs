using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles the entering of a ball. The position is also set based on position of the player. It assigns score as well
/// as shows motivation to the player. Ofcourse, those are methods from other classes. It uses the detection system to know
/// when an object is detected
/// </summary>
public class Goal : MonoBehaviour, ITag, IDetectedObject,IHMDLocationOffset
{
    [SerializeField] GameConfigHolder gameConfigHolder;
    MotivationDataHolder motivationDataHolder;
     GamePlayEventsHolder gamePlayEventsHolder;

    ScoresManager scoreKeeper;
    AbstractTimer abstractTimer;
    MotivationSender motivationSender;
    bool canSendMotivation;

    public string objectTag => gameConfigHolder.ballTagName;

    public Vector3 offset => gameConfigHolder.distanceToGoalOffset;
    string goalTimerKey = "timeBetweenMotivation";

    public void OnObjectDetected(GameObject other)
    {
        ///See if this is a valide ball
        if (other.TryGetComponent(out Ball ball))
        {
            ///update the score based on the ball
            scoreKeeper?.UpdateScore(ball.ballData.score);
            //Unload the ball
            ball?.Unload();
            ///Send event that a ball entered the goal
            gamePlayEventsHolder?.SendOnEnteredGoalEvent(ball.ballData.ballSide,ball.ballData.score);
            ///Motivation shouldnt be always, so lets check if we are allowed to send a motivation at the moment 
            if (canSendMotivation)
            {
                ///lets prevent future till next time
                canSendMotivation = false;
                //get a random message
                string data = motivationDataHolder.data[Random.Range(0, motivationDataHolder.data.Length)].message;
                //send it
                motivationSender?.SendMotivation(data);
                //lets start a timer that allows motivation after a while, settings available in the config
                abstractTimer.StartTickDownTimer(goalTimerKey, goalTimerKey, gameConfigHolder.timeBetweenMotivations, () =>
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

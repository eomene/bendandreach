using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoresHolder", menuName = "Create/ScoresHolder")]
public class ScoresHolder : ScriptableObject
{
    int score;
    float bestTime;
    int highScore;
    [SerializeField] GamePlayEventsHolder gamePlayEventsHolder;

    public void Init()
    {
        score = 0;
        gamePlayEventsHolder?.SendOnGamePlayerScoredEvent(0);
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        gamePlayEventsHolder?.SendOnGamePlayerScoredEvent(this.score);
    }
}

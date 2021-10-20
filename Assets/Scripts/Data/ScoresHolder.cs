using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoresHolder", menuName = "Create/ScoresHolder")]
public class ScoresHolder : ScriptableObject
{
    int score;
    float bestTime;
    int highScore;
    public UnityEvent<int> onScoreUpdated = new UnityEvent<int>();

    public void Init()
    {
        score = 0;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        onScoreUpdated?.Invoke(this.score);
    }
}

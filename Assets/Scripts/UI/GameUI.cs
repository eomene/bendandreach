using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    ScoresHolder scoresHolder;
    [SerializeField] Text scoreTxt;

    void Awake()
    {
        if (scoresHolder == null)
            scoresHolder = Resources.Load<ScoresHolder>("ScoresHolder");
        scoresHolder?.onScoreUpdated.AddListener(ScoreUpdated);
    }

    private void OnDestroy()
    {
        scoresHolder?.onScoreUpdated.RemoveListener(ScoreUpdated);
    }

    public void ScoreUpdated(int score)
    {
        if (scoreTxt != null)
            scoreTxt.text = score.ToString();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIScreen
{

    [SerializeField] Text scoreTxt;

    public override void Awake()
    {
        base.Awake();
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

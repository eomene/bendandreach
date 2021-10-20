using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIScreen, ILocalOnPlayerScored
{

    [SerializeField] Text scoreTxt;


    public void ScoreUpdated(int score)
    {
        if (scoreTxt != null)
            scoreTxt.text = score.ToString();

    }

    public void OnPlayerScored(int score)
    {
        ScoreUpdated(score);
    }
}

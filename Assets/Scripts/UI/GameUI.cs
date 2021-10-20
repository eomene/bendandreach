using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// use the events to update the score text
/// </summary>

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

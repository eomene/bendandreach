using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Can be used by any class to add scores to the player
/// if this gameobject also has an eventsubscriber. it resets the scores at the end of the game.
/// Ideally even if this can be used by mutliple gameobjects, only one of those objects should have an events subscriber
/// it should not break things though
/// </summary>
public class ScoresManager : MonoBehaviour,ILocalOnGamePlayEnded
{
    ScoresHolder scoresHolder;

    // Start is called before the first frame update
    void Awake()
    {
        if (scoresHolder == null)
            scoresHolder = Resources.Load<ScoresHolder>("ScoresHolder");
        scoresHolder.Init();
    }

    public void UpdateScore(int score)
    {
        scoresHolder?.UpdateScore(score);
    }

    public void OnGamePlayEnded()
    {
        scoresHolder.Init();
    }
}

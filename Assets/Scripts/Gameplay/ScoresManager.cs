using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresManager : MonoBehaviour
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

}

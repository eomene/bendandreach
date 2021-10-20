using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour,ITag,IDetectedObject
{
    [SerializeField] GameConfigHolder gameConfigHolder;
    ScoreKeeper scoreKeeper;

    public string objectTag => gameConfigHolder.ballTagName;

    public void OnObjectDetected(GameObject other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            scoreKeeper?.UpdateScore(ball.ballData.score);
            ball?.Unload();
        }
    }

    private void Awake()
    {
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");

        scoreKeeper = GetComponent<ScoreKeeper>();
    }

}

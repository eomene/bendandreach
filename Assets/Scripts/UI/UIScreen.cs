using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    protected GamePlayEventsHolder gamePlayEventsHolder;
    protected GameConfigHolder gameConfigHolder;
    protected ScoresHolder scoresHolder;

    public virtual void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        if (scoresHolder == null)
            scoresHolder = Resources.Load<ScoresHolder>("ScoresHolder");
    }

    public virtual void Open()
    {

    }

    public virtual void Close()
    {

    }
}

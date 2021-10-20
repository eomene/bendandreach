using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGeneratorParent : MonoBehaviour, IHMDLocationOffset
{
    Vector3 locationOffset;
    public Vector3 offset => locationOffset;
    protected GameConfigHolder gameConfigHolder;


    public virtual void Awake()
    {
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        locationOffset = gameConfigHolder.ballGeneratorButtonOffset;
    }
}

using UnityEngine;

/// <summary>
/// Only needed to set the position of the buttons based on the config. 
/// It implements the interface used by the positionmodifier class for its offset
/// </summary>

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

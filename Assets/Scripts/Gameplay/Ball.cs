using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// This is attached to all balls. So it can be customised based on the data from the balldata class
/// </summary>
public class Ball : MonoBehaviour
{
    XRGrabInteractable xRGrabInteractable;
    MeshRenderer meshRenderer;
    [SerializeField] GameConfigHolder gameConfigHolder;
    public BallData ballData { get; private set; }

    private void Awake()
    {
        ///make sure the gameconfig is assigned, we do not want to call this code
         if (gameConfigHolder == null)
        gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
    }


    /// <summary>
    /// Initialised the ball by configuring it based on the data received, right now I only customise color and velocity
    /// But it can be used for others
    /// </summary>
    /// <param name="ballData"></param>
    public void Init(BallData ballData)
    {
        this.ballData = ballData;
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer)
        {
            meshRenderer.material.color = ballData.color;
        }
        if (xRGrabInteractable)
        {
            xRGrabInteractable.throwVelocityScale = ballData.speed;
        }

    }

    /// <summary>
    /// When the ball passes through the goal, we might want effects or to destroy the ball. That can be done here
    /// </summary>
    public void Unload()
    {
        //effects can also be played here
        Invoke("DestroyGameobject", gameConfigHolder.ballDurationAfterUse);
    }


    public void DestroyGameobject()
    {
        Destroy(this.gameObject);
    }


}

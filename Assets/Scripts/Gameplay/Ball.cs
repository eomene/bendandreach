using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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

    public void Unload()
    {
        //effects can also be played here
        Invoke("DestroyGameobjecy", gameConfigHolder.ballDurationAfterUse);
    }

    public void DestroyGameobjecy()
    {
        Destroy(this.gameObject);
    }


}

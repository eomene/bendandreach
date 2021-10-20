using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A button that is triggered by collision, using the detector system. a collider needs to be added to the button for
/// this to work
/// </summary>

[RequireComponent(typeof(ObjectDetector))]
public class DetectorButton : MonoBehaviour, IDetectedObject,ILostDetectedObject
{
    public Action onButtonClicked;
    public Action onButtonClickedUp;

    public void OnDetectedObjectLost(GameObject gameObject)
    {
        onButtonClickedUp?.Invoke();
    }

    public void OnObjectDetected(GameObject gameObject)
    {
        onButtonClicked?.Invoke();
    }

    public void ToggleState(bool state)
    {
        gameObject.SetActive(state);
    }
}

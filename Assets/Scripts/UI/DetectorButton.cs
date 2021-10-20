using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

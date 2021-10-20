using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PositionModifierBasedOnHeadset : TrackedPoseDriver
{
    [SerializeField] Vector3 extraOffset;

   // [SerializeField] GameConfigHolder gameConfigHolder;
    protected override void SetLocalTransform(Vector3 newPosition, Quaternion newRotation)
    {
        base.SetLocalTransform(newPosition + extraOffset, newRotation);
    }
}

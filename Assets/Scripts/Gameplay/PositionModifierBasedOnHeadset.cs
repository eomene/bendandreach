using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public interface IHMDLocationOffset
{
    Vector3 offset { get; }
}


public class PositionModifierBasedOnHeadset : TrackedPoseDriver
{
    IHMDLocationOffset locationOffset;

    protected override void Awake()
    {
        base.Awake();
        locationOffset = GetComponent<IHMDLocationOffset>();
    }
    protected override void SetLocalTransform(Vector3 newPosition, Quaternion newRotation)
    {
        base.SetLocalTransform(newPosition + locationOffset.offset, newRotation);
    }
}

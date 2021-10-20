
using UnityEngine;
using UnityEngine.InputSystem.XR;

/// <summary>
/// Moves anygame object to a position relative to the headset or view of the player. It used an interface to add an offset
/// which makes it easy for multiple objects to use the same code of the interface is implemented by them
/// </summary>
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
        //if we dont have the interface, just use the new position
        Vector3 newP = (locationOffset != null) ? newPosition + locationOffset.offset : newPosition;
        base.SetLocalTransform(newP, newRotation);
    }
}

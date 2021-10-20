
using UnityEngine;
/// <summary>
/// An easy detection system, makes it faster for classes to detect objects without always implementing ontriggerenter.
/// It also makes it easy for us to swap this detection to anyother method in the future without changing the other classes
/// Everything will just work. It sends its responses via interfaces to any class that implements the interfaces
/// You can either manually write out the tag to detect or provide it via an interface.
/// It only supports one detection per gameobject at the moment
/// </summary>
public interface ITag
{
    string objectTag { get; }
}
public interface IDetectedObject
{
    void OnObjectDetected(GameObject gameObject);
}
public interface ILostDetectedObject
{
    void OnDetectedObjectLost(GameObject gameObject);
}

public class ObjectDetector : MonoBehaviour
{
    public string objectToDetectTag;
    ITag objectToDetect;
    IDetectedObject detectedObject;
    ILostDetectedObject lostDetectedObject;

    bool detecting;
    // Start is called before the first frame update
    void Awake()
    {
        objectToDetect = GetComponent<ITag>();
        detectedObject = GetComponent<IDetectedObject>();
        lostDetectedObject = GetComponent<ILostDetectedObject>();
    }

    private void OnTriggerExit(Collider other)
    {

        ///interface overwrites what is set in the inspector. Ideally, this should be a choice 
        string tag = objectToDetect != null ? objectToDetect.objectTag : objectToDetectTag;
        if (other.tag.Contains(tag))
        {
            lostDetectedObject?.OnDetectedObjectLost(other.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (detecting) return;
        detecting = true;
        string tag = objectToDetect != null ? objectToDetect.objectTag : objectToDetectTag;
        if (other.tag.Contains(tag))
            detectedObject?.OnObjectDetected(other.gameObject);
        detecting = false;
    }
}

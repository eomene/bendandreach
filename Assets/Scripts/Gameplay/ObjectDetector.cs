using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
      //  if (detecting) return;
      //  detecting = true;
        ///interface overwrites what is set in the inspector. Ideally, this should be a choice 
        string tag = objectToDetect != null ? objectToDetect.objectTag : objectToDetectTag;
        if (other.tag.Contains(tag))
        {
            lostDetectedObject?.OnDetectedObjectLost(other.gameObject);
        }
      //  detecting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = objectToDetect != null ? objectToDetect.objectTag : objectToDetectTag;
        if (other.tag.Contains(tag))
            detectedObject?.OnObjectDetected(other.gameObject);
    }
}

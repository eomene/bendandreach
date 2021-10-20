
using UnityEngine;

[System.Serializable]
public class MotivationData
{
    public string message;
}

[CreateAssetMenu(fileName = "MotivationDataHolder", menuName = "Create/MotivationDataHolder")]
public class MotivationDataHolder : ScriptableObject
{

    public MotivationData[] data;
}

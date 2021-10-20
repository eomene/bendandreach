using UnityEngine.UI;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class BallData
{
    public float speed;
    public int score;
    public GameObject ballGameObject;
    public Color color;
}

[CreateAssetMenu(fileName = "BallDataHolder", menuName = "Create/BallDataHolder")]
public class BallDataHolder : ScriptableObject
{
    public BallData[] ballDatas;
}

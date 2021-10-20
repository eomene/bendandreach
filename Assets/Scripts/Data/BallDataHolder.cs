using UnityEngine;
using System.Linq;

[System.Serializable]
public class BallData
{
    public float speed;
    public int score;
    public GameObject ballGameObject;
    public Color color;
    public string ballType;
    public GameConfigHolder.GameSide ballSide;
}

[CreateAssetMenu(fileName = "BallDataHolder", menuName = "Create/BallDataHolder")]
public class BallDataHolder : ScriptableObject
{
    [SerializeField] BallData[] ballDatas;
    BallData[] nonComboBalls => ballDatas.Where(x => x.ballType != ("Combo")).ToArray();


    /// <summary>
    /// Gets a ball
    /// </summary>
    /// <param name="combo"></param>
    /// <returns></returns>
    public BallData GetBall(bool combo)
    {
        BallData ballData = ballDatas[0];
        if (combo)
            ballData = ballDatas.FirstOrDefault(x => x.ballType.Contains("Combo"));
        else
            ballData = nonComboBalls[UnityEngine.Random.Range(0, nonComboBalls.Length)];
        return ballData;
    }
}

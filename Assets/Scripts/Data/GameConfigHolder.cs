using UnityEngine;
using System.Linq;

/// <summary>
/// Controls all the config of the gameplay, this should allow for modularity and progression. Since this parameters
/// can be modified to make the game difficult or easy
/// </summary>

[System.Serializable]
public class GameSideConfig
{
    public GameConfigHolder.GameSide side;
    public int maxCount;
}

[CreateAssetMenu(fileName = "GameConfigHolder", menuName = "Create/GameConfigHolder")]
public class GameConfigHolder : ScriptableObject
{
    public enum GameSide { Left, Right }
    public GameSideConfig[] gameSideConfigs;
    public int comboDuration = 15;
    public string ballTagName = "Ball";
    public string leftHandTagName = "LeftHand";
    public string rightHandTagName = "RightHand";
    public int ballDurationAfterUse = 3;

    public float timeBetweenMotivations = 5;
    public float durationOfMotivations = 2;

    public int ballGeneratorScore = 3;
    public int ballPickupScore = 3;
    public Vector3 ballGeneratorButtonOffset;
    public Vector3 distanceToGoalOffset;
    public Vector3 menuUIOffset;
    public Vector3 gameCanvasUIOffset;
    public int GetMaxCount(GameSide gameSide)
    {
        int count = 1;
        GameSideConfig gameSideConfig = gameSideConfigs.FirstOrDefault(x => x.side == gameSide);
        if (gameSideConfig != null)
            count = gameSideConfig.maxCount;
        return count;
    }
  
}

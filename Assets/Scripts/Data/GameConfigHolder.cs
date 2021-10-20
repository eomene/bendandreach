using UnityEngine;
using System.Linq;

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
    public int comboSecs = 3;
    public string ballTagName = "Ball";
    public string leftHandTagName = "LeftHand";
    public string rightHandTagName = "RightHand";
    public int ballDurationAfterUse = 3;
    public Vector3 ballGeneratorButtonOffset;

    public int GetMaxCount(GameSide gameSide)
    {
        int count = 1;
        GameSideConfig gameSideConfig = gameSideConfigs.FirstOrDefault(x => x.side == gameSide);
        if (gameSideConfig != null)
            count = gameSideConfig.maxCount;
        return count;
    }
  
}

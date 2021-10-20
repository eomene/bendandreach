using System;
using UnityEngine;


/// <summary>
/// Only required to position UI based on player position. It also turns on the tutorial ui on game started
/// and turns it off once the first ball is generated.
/// </summary>
public class GameCanvaMenu : MenuManagerBase, IHMDLocationOffset, ILocalOnGamePlayStarted, ILocalOnGenerateBalls
{
    public Vector3 offset => gameConfigHolder.gameCanvasUIOffset;

    public void OnGamePlayStarted()
    {
        OpenScreen(3, false);
    }

    /// <summary>
    /// A ball was generated, the player probabbly got how to play the game
    /// </summary>
    /// <param name="side"></param>
    /// <param name="onComplete"></param>
    public void OnGenerateBalls(GameConfigHolder.GameSide side, Action onComplete)
    {
        CloseScreen(3);
    }
}

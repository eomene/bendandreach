using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvaMenu : MenuManagerBase, IHMDLocationOffset, ILocalOnGamePlayStarted, ILocalOnGenerateBalls
{
    public Vector3 offset => gameConfigHolder.gameCanvasUIOffset;

    public void OnGamePlayStarted()
    {
        OpenScreen(3, false);
    }

    public void OnGenerateBalls(GameConfigHolder.GameSide side, Action onComplete)
    {
        CloseScreen(3);
    }
}

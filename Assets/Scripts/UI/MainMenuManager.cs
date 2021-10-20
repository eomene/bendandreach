using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MenuManagerBase, ILocalOnGamePlayEnded, ILocalOnGamePlayStarted,IHMDLocationOffset
{
    bool isPlayingGame;
    public Vector3 offset => gameConfigHolder.menuUIOffset;
   // public Vector3 locationOffset;
    public override void Awake()
    {
        base.Awake();
       // locationOffset = gameConfigHolder.menuUIOffset;
    }

    public void OnGamePlayEnded()
    {
        OpenScreen(0);
        isPlayingGame = false;
    }

    public void OnGamePlayStarted()
    {
        isPlayingGame = true;
    }

    public void ShowExitMenu()
    {
        if (isPlayingGame)
            OpenScreen(1, pauseScreen: true);
    }

}

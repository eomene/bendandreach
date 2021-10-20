using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MenuManagerBase, ILocalOnGamePlayEnded, ILocalOnGamePlayStarted
{
    bool isPlayingGame;

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

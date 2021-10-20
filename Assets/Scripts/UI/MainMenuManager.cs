
using UnityEngine;

/// <summary>
/// Controls the showing of the main menu as well as the location based on the player view. Uses events to show either
/// the main menu or exit menu
/// </summary>
public class MainMenuManager : MenuManagerBase, ILocalOnGamePlayEnded, ILocalOnGamePlayStarted,IHMDLocationOffset
{
    bool isPlayingGame;
    public Vector3 offset => gameConfigHolder.menuUIOffset;

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

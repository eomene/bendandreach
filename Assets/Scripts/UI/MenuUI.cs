using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public DetectorButton playGameButton;
    public DetectorButton backToMenuButton;
    [SerializeField] GamePlayEventsHolder gamePlayEventsHolder;

    private void Awake()
    {
        playGameButton.onButtonClicked = PlayGame;
        backToMenuButton.onButtonClicked = Endgame;
        backToMenuButton.onButtonClickedUp = BackToMenu;
    }

    public void PlayGame()
    {
        playGameButton.ToggleState(false);
        gamePlayEventsHolder?.onGamePlayStarted?.Invoke();
    }

    public void ShowExitMenu()
    {
        backToMenuButton.ToggleState(true);
    }

    public void BackToMenu()
    {
        backToMenuButton.ToggleState(false);
        playGameButton.ToggleState(true);
    }

    public void Endgame()
    {
        gamePlayEventsHolder?.onGamePlayEnded?.Invoke();
    }
}

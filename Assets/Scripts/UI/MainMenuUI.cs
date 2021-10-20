using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// For the main menu, only contains the play button that fires the play event
/// </summary>
public class MainMenuUI : UIScreen
{
    public DetectorButton playGameButton;

    public override void Awake()
    {
        base.Awake();
        playGameButton.onButtonClicked = PlayGame;
    }

    public void PlayGame()
    {
        CloseSelf();
        gamePlayEventsHolder?.SendOnGamePlayStartedEvent();
    }


}

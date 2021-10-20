using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// simple pause menu
/// </summary>
public class PauseMenuUI : UIScreen
{
    public DetectorButton backToMenuButton;
    public DetectorButton exitPauseMenuButton;

    public override void Awake()
    {
        base.Awake();
 
        backToMenuButton.onButtonClicked = Endgame;
        exitPauseMenuButton.onButtonClicked = CloseSelf;
    }

    public void Endgame()
    {
        gamePlayEventsHolder?.SendOnGamePlayEndedEvent();
    }
}

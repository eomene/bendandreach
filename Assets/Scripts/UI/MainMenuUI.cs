using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame

}

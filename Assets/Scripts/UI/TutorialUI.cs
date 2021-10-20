using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


/// <summary>
/// plays and stops video when it is opend or closed
/// </summary>
public class TutorialUI : UIScreen
{

    [SerializeField]VideoPlayer videoPlayer;


    public override void Open(Action onOpen = null, bool pauseScene = false, Action onCloseScreen = null)
    {
        base.Open(onOpen, pauseScene, onCloseScreen);
        videoPlayer.Play();
    }

    public override void Close(Action onClose = null)
    {
        base.Close(onClose);
        videoPlayer.Stop();
    }
}

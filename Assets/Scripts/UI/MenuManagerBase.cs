using System;
using UnityEngine;


/// <summary>
/// Handles easy opening and closing of ui screens using indexs in an array
/// </summary>
public class MenuManagerBase : MonoBehaviour
{
    public UIScreen[] screens;
    [SerializeField] int defaultScreen = 1;
    [SerializeField] bool openDefaultOnStart;
    [SerializeField] bool closeAllScreensOnStart = true;
    protected GamePlayEventsHolder gamePlayEventsHolder;
    [SerializeField] protected GameConfigHolder gameConfigHolder;
    protected ScoresHolder scoresHolder;

    public virtual void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        if (scoresHolder == null)
            scoresHolder = Resources.Load<ScoresHolder>("ScoresHolder");
    }


    public virtual void Start()
    {
        if (closeAllScreensOnStart)
            CloseAllScreens();
        if (openDefaultOnStart)
            OpenDefault();
    }

    public void OpenDefault()
    {
        OpenScreen(defaultScreen);
    }


    public void OpenScreen(int index, bool closeOthers = true, bool pauseScreen = false, Action onCloseScreen = null)
    {
        if (closeOthers)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (i != index)
                {
                    screens[i]?.Close();
                }
            }
        }

        if (index >= 0 && index < screens.Length)
            screens[index]?.Open(pauseScene: pauseScreen, onCloseScreen: onCloseScreen);
    }

    public void CloseScreen(int index)
    {
        if (index > 0 && index < screens.Length)
            screens[index]?.Close();
    }

    public void CloseAllScreens()
    {
        for (int i = 0; i < screens.Length; i++)
            screens[i]?.Close();
    }

}

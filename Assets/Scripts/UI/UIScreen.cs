using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    protected GamePlayEventsHolder gamePlayEventsHolder;
    protected GameConfigHolder gameConfigHolder;
    protected ScoresHolder scoresHolder;
    CanvasGroup canvasGroup;
    Action onCloseScreen;
    bool isPauseMenu;
    protected MenuManagerBase menuManagerBase;

    public virtual void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        if (gameConfigHolder == null)
            gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
        if (scoresHolder == null)
            scoresHolder = Resources.Load<ScoresHolder>("ScoresHolder");
        menuManagerBase = GetComponentInParent<MenuManagerBase>();
    }

    public virtual void Open(Action onOpen = null, bool pauseScene = false, Action onCloseScreen = null)
    {
        this.onCloseScreen = onCloseScreen;
        this.isPauseMenu = pauseScene;
        if (canvasGroup)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
        }
        gameObject.SetActive(true);
        gamePlayEventsHolder?.SendOnGamePlayerPausedEvent(pauseScene);
        onOpen?.Invoke();
    }

    public virtual void Close(Action onClose = null)
    {
        onClose?.Invoke();
        onCloseScreen?.Invoke();
        if (canvasGroup)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = false;
        }
        gameObject.SetActive(false);
        this.isPauseMenu = false;
        gamePlayEventsHolder?.SendOnGamePlayerPausedEvent(isPauseMenu);

    }

    public void CloseSelf()
    {
        Close();
    }
    public void OpenSelf()
    {
        Open();
    }
}

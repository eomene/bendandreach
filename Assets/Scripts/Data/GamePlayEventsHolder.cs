using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IOnGenerateBalls
{
    void OnGenerateBalls(GameConfigHolder.GameSide side, Action onComplete);
}
public interface IOnGamePlayStarted
{
    void OnGamePlayStarted();
}
public interface IOnGamePlayEnded
{
    void OnGamePlayEnded();
}
public interface IOnBallReleased
{
    void OnBallReleased();
}
public interface IOnPlayerScored
{
    void OnPlayerScored(int score);
}
public interface IOnEnteredGoal
{
    void OnEnteredGoal(GameConfigHolder.GameSide gameSide,int score);
}
public interface IOnMotivationReceived
{
    void OnMotivationReceived(string message);
}

public interface IEventsHolder
{

}

[CreateAssetMenu(fileName = "GamePlayEventsHolder", menuName = "Create/GamePlayEventsHolder")]
public class GamePlayEventsHolder : ScriptableObject
{
    UnityEvent<GameConfigHolder.GameSide, Action> onGenerateBall = new UnityEvent<GameConfigHolder.GameSide, Action>();
    UnityEvent onGamePlayStarted = new UnityEvent();
    UnityEvent onGamePlayEnded = new UnityEvent();
    UnityEvent<int> onPlayerScored = new UnityEvent<int>();
    UnityEvent<GameConfigHolder.GameSide ,int> onEnteredGoal = new UnityEvent<GameConfigHolder.GameSide,int>();
    UnityEvent<string> onMotivationReceived = new UnityEvent<string>();
    UnityEvent onBallReleased = new UnityEvent();
    List<IEventsHolder> callbackHolders = new List<IEventsHolder>();


    public void SendOnGamePlayStartedEvent()
    {
        onGamePlayStarted?.Invoke();
    }

    public void SendOnGamePlayEndedEvent()
    {
        onGamePlayEnded?.Invoke();
    }

    public void SendOnGamePlayerScoredEvent(int score)
    {
        onPlayerScored?.Invoke(score);
    }

    public void SendOnEnteredGoalEvent(GameConfigHolder.GameSide gameSide,int score)
    {
        onEnteredGoal?.Invoke(gameSide,score);
    }

    public void SendOnMotivationReceivedEvent(string message)
    {
        onMotivationReceived?.Invoke(message);
    }
    public void SendOnGenerateBallEvent(GameConfigHolder.GameSide side, Action onComplete)
    {
        onGenerateBall?.Invoke(side, onComplete);
    }
    public void SendOnBallReceivedEvent()
    {
        onBallReleased?.Invoke();
    }
    public void Initialise()
    {
        callbackHolders.Clear();
    }

    public void SubscribeToEvent(IEventsHolder callbackHolder)
    {
        if (callbackHolder == null) return;
        if (!callbackHolders.Contains(callbackHolder))
        {

            MainSubscribeToEvents(callbackHolder);
            callbackHolders.Add(callbackHolder);
        }
    }
    public void UnsubscribeToEvent(IEventsHolder callbackHolder)
    {
        if (callbackHolder == null) return;
        if (callbackHolders.Contains(callbackHolder))
        {
            MainUnsubscribeToEvent(callbackHolder);
            callbackHolders.Remove(callbackHolder);
        }
    }

    void MainSubscribeToEvents(IEventsHolder callbackHolder)
    {
        IOnGenerateBalls onGenerateBalls = callbackHolder as IOnGenerateBalls;
        IOnGamePlayStarted onGamePlayStarted = callbackHolder as IOnGamePlayStarted;
        IOnGamePlayEnded onGamePlayEnded = callbackHolder as IOnGamePlayEnded;
        IOnBallReleased onBallReleased = callbackHolder as IOnBallReleased;
        IOnPlayerScored onPlayerScored = callbackHolder as IOnPlayerScored;
        IOnMotivationReceived onMotivationReceived = callbackHolder as IOnMotivationReceived;
        IOnEnteredGoal onEnteredGoal = callbackHolder as IOnEnteredGoal;
        if (onGenerateBalls != null)
            this.onGenerateBall.AddListener(onGenerateBalls.OnGenerateBalls);
        if (onGamePlayStarted != null)
            this.onGamePlayStarted.AddListener(onGamePlayStarted.OnGamePlayStarted);
        if (onGamePlayEnded != null)
            this.onGamePlayEnded.AddListener(onGamePlayEnded.OnGamePlayEnded);
        if (onBallReleased != null)
            this.onBallReleased.AddListener(onBallReleased.OnBallReleased);
        if (onPlayerScored != null)
            this.onPlayerScored.AddListener(onPlayerScored.OnPlayerScored);
        if (onMotivationReceived != null)
            this.onMotivationReceived.AddListener(onMotivationReceived.OnMotivationReceived);
        if (onEnteredGoal != null)
            this.onEnteredGoal.AddListener(onEnteredGoal.OnEnteredGoal);
    }

    public void MainUnsubscribeToEvent(IEventsHolder callbackHolder)
    {
        IOnGenerateBalls onGenerateBalls = callbackHolder as IOnGenerateBalls;
        IOnGamePlayStarted onGamePlayStarted = callbackHolder as IOnGamePlayStarted;
        IOnGamePlayEnded onGamePlayEnded = callbackHolder as IOnGamePlayEnded;
        IOnBallReleased onBallReleased = callbackHolder as IOnBallReleased;
        IOnPlayerScored onPlayerScored = callbackHolder as IOnPlayerScored;
        IOnMotivationReceived onMotivationReceived = callbackHolder as IOnMotivationReceived;
        IOnEnteredGoal onEnteredGoal = callbackHolder as IOnEnteredGoal;
        if (onGenerateBalls != null)
            this.onGenerateBall.RemoveListener(onGenerateBalls.OnGenerateBalls);
        if (onGamePlayStarted != null)
            this.onGamePlayStarted.RemoveListener(onGamePlayStarted.OnGamePlayStarted);
        if (onGamePlayEnded != null)
            this.onGamePlayEnded.RemoveListener(onGamePlayEnded.OnGamePlayEnded);
        if (onBallReleased != null)
            this.onBallReleased.RemoveListener(onBallReleased.OnBallReleased);
        if (onPlayerScored != null)
            this.onPlayerScored.RemoveListener(onPlayerScored.OnPlayerScored);
        if (onMotivationReceived != null)
            this.onMotivationReceived.RemoveListener(onMotivationReceived.OnMotivationReceived);
        if (onEnteredGoal != null)
            this.onEnteredGoal.RemoveListener(onEnteredGoal.OnEnteredGoal);
    }

    public void Unload()
    {
        for (int i = 0; i < callbackHolders.Count; i++)
            UnsubscribeToEvent(callbackHolders[i]);

        onGamePlayStarted.RemoveAllListeners();
        onGamePlayEnded.RemoveAllListeners();
        onPlayerScored.RemoveAllListeners();
        onBallReleased.RemoveAllListeners();

        callbackHolders.Clear();
    }

}

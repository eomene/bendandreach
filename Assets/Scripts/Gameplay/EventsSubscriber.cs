using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public interface ILocalOnGenerateBalls
{
    void OnGenerateBalls(GameConfigHolder.GameSide side, Action onComplete);
}
public interface ILocalOnGamePlayStarted
{
    void OnGamePlayStarted();
}
public interface ILocalOnGamePlayEnded
{
    void OnGamePlayEnded();
}
public interface ILocalOnBallReleased
{
    void OnBallReleased();
}
public interface ILocalOnPlayerScored
{
    void OnPlayerScored(int score);
}
public interface ILocalOnMotivationReceived
{
    void OnMotivationReceived(string message);
}

public class EventsSubscriber : MonoBehaviour,IOnBallReleased,IOnGamePlayEnded,IOnGamePlayStarted,IOnGenerateBalls,IOnPlayerScored, IEventsHolder,IOnMotivationReceived
{
    GamePlayEventsHolder gamePlayEventsHolder;
    ILocalOnGenerateBalls[] onGenerateBallsEventHolders;
    ILocalOnGamePlayStarted[] onGamePlayStartedEventHolders;
    ILocalOnGamePlayEnded[] onGamePlayEndedEventHolders;
    ILocalOnBallReleased[] onBallReleasedEventHolders;
    ILocalOnPlayerScored[] onPlayerScoredEventHolders;
    ILocalOnMotivationReceived[] onMotivationReceivedEventHolders;
    /// <summary>
    /// Local events that can be assigned in the inspector, if the interfaces are not used
    /// </summary>
    public UnityEvent<GameConfigHolder.GameSide, Action> onGenerateBall = new UnityEvent<GameConfigHolder.GameSide, Action>();
    public UnityEvent onGamePlayStarted = new UnityEvent();
    public UnityEvent onGamePlayEnded = new UnityEvent();
    public UnityEvent<int> onPlayerScored = new UnityEvent<int>();
    public UnityEvent onBallReleased = new UnityEvent();
    public UnityEvent<string> onMotivationReceived = new UnityEvent<string>();
    private void Start()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
        onGenerateBallsEventHolders = GetComponents<ILocalOnGenerateBalls>();
        onGamePlayStartedEventHolders = GetComponents<ILocalOnGamePlayStarted>();
        onGamePlayEndedEventHolders = GetComponents<ILocalOnGamePlayEnded>();
        onBallReleasedEventHolders = GetComponents<ILocalOnBallReleased>();
        onPlayerScoredEventHolders = GetComponents<ILocalOnPlayerScored>();
        onMotivationReceivedEventHolders = GetComponents<ILocalOnMotivationReceived>();

        gamePlayEventsHolder?.SubscribeToEvent(this);
    }


    public void OnBallReleased()
    {
        for (int i = 0; i < onBallReleasedEventHolders.Length; i++)
            onBallReleasedEventHolders[i]?.OnBallReleased();
        onBallReleased?.Invoke();
    }

    public void OnGamePlayEnded()
    {
        for (int i = 0; i < onGamePlayEndedEventHolders.Length; i++)
            onGamePlayEndedEventHolders[i]?.OnGamePlayEnded();
        onGamePlayEnded?.Invoke();
    }

    public void OnGamePlayStarted()
    {
        for (int i = 0; i < onGamePlayStartedEventHolders.Length; i++)
            onGamePlayStartedEventHolders[i]?.OnGamePlayStarted();
        onGamePlayStarted?.Invoke();
    }

    public void OnGenerateBalls(GameConfigHolder.GameSide side, Action onComplete)
    {
        for (int i = 0; i < onGenerateBallsEventHolders.Length; i++)
            onGenerateBallsEventHolders[i]?.OnGenerateBalls(side, onComplete);
        onGenerateBall?.Invoke(side, onComplete);
    }

    public void OnPlayerScored(int score)
    {
        for (int i = 0; i < onPlayerScoredEventHolders.Length; i++)
            onPlayerScoredEventHolders[i]?.OnPlayerScored(score);
        onPlayerScored?.Invoke(score);
    }

    public void OnMotivationReceived(string message)
    {
        for (int i = 0; i < onMotivationReceivedEventHolders.Length; i++)
            onMotivationReceivedEventHolders[i]?.OnMotivationReceived(message);
        onMotivationReceived?.Invoke(message);
    }
}

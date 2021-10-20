using UnityEngine;

/// <summary>
/// Easily sending motivation by attaching to any gameobject. All it does it fire the 
/// motivation event from the gameplayeventsholder
/// </summary>
public class MotivationSender : MonoBehaviour
{
    protected GamePlayEventsHolder gamePlayEventsHolder;

    public virtual void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
    }

    public void SendMotivation(string message)
    {
        gamePlayEventsHolder?.SendOnMotivationReceivedEvent(message);
    }

}

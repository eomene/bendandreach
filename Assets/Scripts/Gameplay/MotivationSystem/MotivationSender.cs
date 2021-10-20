using UnityEngine;

public class MotivationSender : MonoBehaviour
{
    protected GamePlayEventsHolder gamePlayEventsHolder;
   // protected GameConfigHolder gameConfigHolder;

    public virtual void Awake()
    {
        if (gamePlayEventsHolder == null)
            gamePlayEventsHolder = Resources.Load<GamePlayEventsHolder>("GamePlayEventsHolder");
    //    if (gameConfigHolder == null)
     //       gameConfigHolder = Resources.Load<GameConfigHolder>("GameConfigHolder");
    }

    public void SendMotivation(string message)
    {
        gamePlayEventsHolder?.onMotivationReceived?.Invoke(message);
    }

}

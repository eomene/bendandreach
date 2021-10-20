using UnityEngine;
using UnityEngine.UI;
using Cradaptive.AbstractTimer;


/// <summary>
/// Shows motivation, if it receives the events, also uses a timer to know how long it should be displayed
/// </summary>
public class MotivationUI : UIScreen, ILocalOnMotivationReceived
{
    [SerializeField]Text motivationText;
    AbstractTimer abstractTimer;

    public override void Awake()
    {
        base.Awake();
        abstractTimer = GetComponent<AbstractTimer>();
    }

    public void OnMotivationReceived(string message)
    {
        motivationText.text = message;
        abstractTimer.StartTickDownTimer("myMotivationTimer", "Motivation Timer", gameConfigHolder.durationOfMotivations, () =>
        {
            motivationText.text = "";
        });
    }
}

using UnityEngine;
using UnityEngine.UI;
using Cradaptive.AbstractTimer;

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

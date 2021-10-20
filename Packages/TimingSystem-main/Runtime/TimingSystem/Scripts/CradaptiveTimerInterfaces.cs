using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cradaptive.AbstractTimer
{
    public interface IAbstractTimerConsumer
    {
        void onTimerUpdated(CradaptiveTimerClass timerValue);
        void onTimerEnded();
    }
}
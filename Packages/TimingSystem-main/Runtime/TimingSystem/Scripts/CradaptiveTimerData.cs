using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cradaptive.AbstractTimer
{
    public enum TimerType { TickDown, TickUp }


    [Serializable]
    public class CradaptiveTimerClass
    {
        /// <summary>
        /// Unique identifier for timer
        /// </summary>
        public string key;
        /// <summary>
        /// Ticking time, should not be modified by outsider the timer manager
        /// </summary>
        public float timer;
        /// <summary>
        /// Should tick
        /// </summary>
        public bool tick;
        /// <summary>
        /// Friendly name for timer
        /// </summary>
        public string name;
        /// <summary>
        /// Callback once the timer has reached its maxmum
        /// </summary>
        public Action onTimerCompleted;
        /// <summary>
        /// maximum time if it ticks up
        /// </summary>
        [HideInInspector]
        public float maxTime = 60;

        public bool tickDownTimer;

        public TimerType timerType;

        /// <summary>
        /// Callback when timer is updated
        /// </summary>
        public Action<float> onTimerUpdated;

    }
}
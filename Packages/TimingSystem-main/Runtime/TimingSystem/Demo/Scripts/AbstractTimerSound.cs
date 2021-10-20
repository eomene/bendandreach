using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradaptive.AbstractTimer;

[RequireComponent(typeof(AudioSource))]
public class AbstractTimerSound : MonoBehaviour, IAbstractTimerConsumer
{
    [SerializeField] AudioClip clipToPlay;
    [SerializeField] AudioSource audioSource;
    public string timerKeyToUse;
    bool playing;

    private void Awake()
    {
        if (!audioSource)
            audioSource = GetComponent<AudioSource>();
    }

    public void onTimerEnded()
    {
        CancelInvoke("PlaySound");
        playing = false;
    }

    public void onTimerUpdated(CradaptiveTimerClass timerValue)
    {
        if (timerKeyToUse != timerValue.key) return;
        UpdateDisplay(timerValue.timer);
    }

    public void UpdateDisplay(float timeValue)
    {
        float seconds = Mathf.FloorToInt(timeValue % 60);
        if (seconds <= 10 && seconds >= 0 && !playing) 
        {
            playing = true;
            InvokeRepeating("PlaySound", 0, 1);
        }
    }

    public void PlaySound()
    {
        if (!audioSource.isPlaying)
            audioSource?.PlayOneShot(clipToPlay);
    }

}

# DOCUMENTATION

## INSTALLATION USING UNITY PACKAGE MANAGER

### USING GIT

Before you start, make sure you have git installed on your computer.
Open the Unity editor and navigate to the Package Manager by clicking on Window and then Package Manager.

Click on the + at the top of the Package Manager window and select Add package from git URL.

Enter the URL below into the text box and click Add. 
https://github.com/eomene/TextureDownloader.git

The SDK is now installed in your project, and you are ready to configure the SDK and make your first API calls.

### USING FULL REPO

If you do not have git installed on your computer. You can install the SDK by downloading the entire repository and pasting in the packages folder of your project.
You can download the entire repo by clicking Code and Download Zip

The SDK is now installed in your project, and you are ready to configure the SDK and make your first API calls.

## Using Timers
This system can be used by attaching the abstract timer class to any gameobject that intends to use the timer in your scene. Thats all. You can now reference and start as many timers as you want with that class.

### Tick Up Timer
A tickup timer is a timer that continues to run until you explicitly stop it using the stop timer method. A good implementation of this is if you intend test how long it takes a 
server calls for example to occur.

#### Starting Tick up Timer
An easy was to start a timer is by using a reference to the timer attached to the gameobject and calling the Start Timer method. It requires you to send a unique key for timer , a friendly name to identify the timer if you intend to display this and finally a callback you intend to occur when the timer stops.

Example:

    AbstractTimer abstractTimer;

    void Awake()
    {
        abstractTimer = GetComponent<AbstractTimer>();
    }
    
    public void StartTickUpTimer()
    {
        abstractTimer.StartTickUpTimer("timerUniqueKey", "Friendly name of timer", () =>
        {
            Debug.Log("My Timer Ended...Yaay!");
        });
    }
     

#### Stoping Tick up Timer 
You can easily stop timer by calling the EndTimer method as shown below. This returns a float with the current timer value.

    public void StopTickUpTimer()
    {
       float timeLen = abstractTimer.EndTimer("timerUniqueKey");
       Debug.Log($"My Timer Ended in {timeLen} seconds!");
    }

### Tick Down timer
A tick down timer is a timer that has a fixed time. It runs for the duration you give it and finally stops and fires the callback.

#### Starting Tick Down Timer 
An easy was to start a tick down timer is by using a reference to the timer attached to the gameobject and calling the Start Timer method. It requires you to send a unique key for timer , a friendly name to identify the timer if you intend to display this, how long you want the timer to take, and finally a callback you intend to occur when the timer stops.

Example:

    AbstractTimer abstractTimer;

    void Awake()
    {
        abstractTimer = GetComponent<AbstractTimer>();
    }
    
    public void StartTickDownTimer()
    {
        abstractTimer.StartTickDownTimer("timerUniqueKey", "Friendly name of timer", 15, () =>
        {
            Debug.Log("My Timer Ended...Yaay!");
        });
    }
    
### Getting Data from timers
A simple way to get data from the timers without actively calling the methods and hence causing dependencies is by implementing the IAbstractTimerConsumer in a class and attaching this class to the same gameobject as the AbstractTimer. 
Implementing this interface requires you to have two methods in your class

    public void onTimerEnded();
    public void onTimerUpdated(CradaptiveTimerClass timerValue);

A good use case would be if you intend to show your timer counting down. You could write a simple class like the example below, attach to the game object and hence have access to the state of the timer.
    
    public class AbstractTimerDisplay : MonoBehaviour, IAbstractTimerConsumer
    {
          public string timerKeyToUse;
          public Text timeText;
          public void onTimerEnded()
          {

          }

          public void onTimerUpdated(CradaptiveTimerClass timerValue)
          {
              if (timerKeyToUse != timerValue.key) return;
              UpdateDisplay(timerValue.timer);
          }

          public void UpdateDisplay(float timeValue)
          {
              float seconds = Mathf.FloorToInt(timeValue % 60);
              if (seconds >= 0)
                  timeText.text = string.Format("{0}", seconds);
          }

     }

Examples are also included for playing sounds when timer gets to a certain value. You can check out the demo folder for this 


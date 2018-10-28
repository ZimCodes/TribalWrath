using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITimer
{
    void ResetTimer();
    void PlayTimerContinuous(float timerinseconds);
    void PlayTimerOnce(float timerinseconds);
}
public class Timer : ITimer {
    enum TimerState { Play, Stop, Reset };
    /// <summary>
    /// Holds all Timer Instances
    /// </summary>
    public List<Timer> Timers = new List<Timer>();

    private float CurrentTime;
    private float SecondsTimer;
    /// <summary>
    /// Time is up.
    /// </summary>
    public bool IsTimeUp;
    public Timer()
    {
        CurrentTime = 0;
        SecondsTimer = 0;
    }
    /// <summary>
    /// Activates different states of a timer.
    /// </summary>
    /// <param name="timerState">Timer State.</param>
    private void ActivateTimerType(TimerState timerState)
    {
        switch (timerState)
        {
            case TimerState.Play:
                CurrentTime += Time.deltaTime;
                break;
            case TimerState.Stop:
                IsTimeUp = true;
                break;
            case TimerState.Reset:
                CurrentTime = 0;
                IsTimeUp = false;
                break;
        }
    }
    public void ResetTimer()
    {
        ActivateTimerType(TimerState.Reset);
    }
    /// <summary>
    /// Plays the timer once.
    /// </summary>
    /// <param name="seconds">Seconds before timer ends</param>
    public void PlayTimerOnce(float seconds)
    {
        SecondsTimer = seconds;
        if (CurrentTime < SecondsTimer)
        {
            ActivateTimerType(TimerState.Play);
        }
        else
        {
            ActivateTimerType(TimerState.Stop);
        }
    }
    /// <summary>
    /// Plays the timer continuous.
    /// </summary>
    /// <param name="seconds">Seconds before timer restarts</param>
    public void PlayTimerContinuous(float seconds)
    {
        SecondsTimer = seconds;
        if (CurrentTime < SecondsTimer)
        {
            ActivateTimerType(TimerState.Play);
        }
        else if (!IsTimeUp && CurrentTime >= SecondsTimer)
        {
            IsTimeUp = true;
        }
        else if (IsTimeUp && CurrentTime >= SecondsTimer)
        {
            ActivateTimerType(TimerState.Reset);
            ActivateTimerType(TimerState.Play);
        }
    }
    public void NumberofTimers(int numoftimers)
    {
        Timer t;
        for (int i = 0; i < numoftimers; i++)
        {
            t = new Timer();
            Timers.Add(t);
        }
    }
    public override string ToString()
    {
        return string.Format("Current Time: {0}", CurrentTime);
    }

}

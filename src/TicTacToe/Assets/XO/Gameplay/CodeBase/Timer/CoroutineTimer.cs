using System;
using System.Collections;
using UnityEngine;

namespace XO.Gameplay.CodeBase.Timer
{
  public class CoroutineTimer : MonoBehaviour
  {
    public event Action<int> Update;
    public event Action OnFinish;
      
    private Coroutine _timerCoroutine;
    private bool _isRunning;
    private int _remainingTime;
    private int _interval;
    
    public void StartTimer(int time, int interval)
    {
      if (_isRunning)
        return;

      _remainingTime = time;
      _interval = interval;

      _timerCoroutine = StartCoroutine(TimerCoroutine());

      _isRunning = true;
    }

    public void StopTimer()
    {
      if (!_isRunning)
        return;

      StopCoroutine(_timerCoroutine);
      _isRunning = false;
    }

    private IEnumerator TimerCoroutine()
    {
      while (_remainingTime > 0)
      {
        yield return new WaitForSeconds(_interval);
        _remainingTime -= _interval;
        Update?.Invoke(_remainingTime);
      }

      OnFinish?.Invoke();
      _isRunning = false;
    }
  }}
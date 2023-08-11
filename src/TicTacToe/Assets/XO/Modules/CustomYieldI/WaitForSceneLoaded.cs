using UnityEngine;
using UnityEngine.SceneManagement;

namespace XO.Modules.CustomYieldI
{
  public class WaitForSceneLoaded : CustomYieldInstruction
  {
    private readonly string _sceneName;
    private readonly float _timeout;
    private readonly float _startTime;
    private bool _timedOut;

    public bool TimedOut => _timedOut;

    public override bool keepWaiting
    {
      get
      {
        var scene = SceneManager.GetSceneByName(_sceneName);
        var sceneLoaded = scene.IsValid() && scene.isLoaded;

        if (Time.realtimeSinceStartup - _startTime >= _timeout) 
          _timedOut = true;

        return !sceneLoaded && !_timedOut;
      }
    }

    public WaitForSceneLoaded(string sceneName, float timeout = 10)
    {
      _sceneName = sceneName;
      _timeout = timeout;
      _startTime = Time.realtimeSinceStartup;
    }
  }
}
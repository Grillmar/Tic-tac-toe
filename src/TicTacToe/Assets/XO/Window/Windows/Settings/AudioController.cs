using UnityEngine;
using XO.Modules.Progress;

namespace XO.Window.Windows.Settings
{
  public class AudioController
  {
    private readonly Progress _progress;
    
    public AudioController(Progress progress)
    {
      _progress = progress;

      Initialize();
    }

    public void Initialize()
    {
      Debug.Log("Initialize");
    }

    public void Update()
    {
      Debug.Log("Update");
    }
  }
}
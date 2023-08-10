using XO.Modules.Progress;
using Zenject;

namespace XO.Window.Windows.Settings
{
  public class AudioController : IInitializable
  {
    private readonly Progress _progress;

    public AudioController(Progress progress)
    {
      _progress = progress;
    }
    
    public void Initialize()
    {
      
    }

    public void Update()
    {
      
    }
  }
}
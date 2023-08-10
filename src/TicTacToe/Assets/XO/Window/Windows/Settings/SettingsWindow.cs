using UnityEngine.UI;
using XO.Gameplay.CodeBase;
using XO.Modules.Progress;
using Zenject;

namespace XO.Window.Windows.Settings
{
  public class SettingsWindow : BaseWindow
  {
    public Button Back;
    public Toggle MusicToggle;
    public Toggle SoundToggle;

    private IWindowService _windowService;
    private Progress _progress;
    private AudioController _audioController;

    [Inject]
    public void SetDependency(IWindowService windowService, Progress progress, AudioController audioController)
    {
      _progress = progress;
      _windowService = windowService;
      _audioController = audioController;
    }
    
    private void Awake()
    {
      MusicToggle.onValueChanged.AddListener(UpdateMusic);
      SoundToggle.onValueChanged.AddListener(UpdateSound);
      Back.onClick.AddListener(CloseWindow);
    }

    private void UpdateSound(bool value)
    {
      _progress.SettingsData.TurnSound = value;
      _audioController.Update();
    }

    private void UpdateMusic(bool value)
    {
      _progress.SettingsData.TurnMusic = value;
      _audioController.Update();
    }

    private void OnDestroy()
    {
      Back.onClick.RemoveListener(CloseWindow);

    }
    private void CloseWindow() => 
      _windowService.Close(TypeId);
  }
}
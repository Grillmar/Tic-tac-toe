using UnityEngine.UI;
using XO.Modules.Progress;
using Zenject;

namespace XO.Modules.Window.Windows.Settings
{
  public class SettingsWindow : BaseWindow
  {
    public Button Back;
    public Toggle MusicToggle;
    public Toggle SoundToggle;

    private IWindowService _windowService;
    private ProgressData _progressData;
    private AudioController _audioController;

    [Inject]
    public void SetDependency(IWindowService windowService, ProgressData progressData, AudioController audioController)
    {
      _progressData = progressData;
      _windowService = windowService;
      _audioController = audioController;
    }
    
    private void Start()
    {
      UpdateToggles();

      MusicToggle.onValueChanged.AddListener(UpdateMusic);
      SoundToggle.onValueChanged.AddListener(UpdateSound);
      Back.onClick.AddListener(CloseWindow);
    }

    private void OnDestroy()
    {
      MusicToggle.onValueChanged.RemoveListener(UpdateMusic);
      SoundToggle.onValueChanged.RemoveListener(UpdateSound);
      Back.onClick.RemoveListener(CloseWindow);
    }

    private void UpdateToggles()
    {
      MusicToggle.isOn = _progressData.SettingsData.TurnMusic;
      SoundToggle.isOn = _progressData.SettingsData.TurnSound;
    }

    private void UpdateSound(bool value)
    {
      _progressData.SettingsData.TurnSound = value;
      _audioController.Update();
    }

    private void UpdateMusic(bool value)
    {
      _progressData.SettingsData.TurnMusic = value;
      _audioController.Update();
    }

    private void CloseWindow() => 
      _windowService.Close(TypeId);
  }
}
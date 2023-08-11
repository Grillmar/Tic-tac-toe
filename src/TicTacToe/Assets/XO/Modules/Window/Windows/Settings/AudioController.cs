using UnityEngine.Audio;
using XO.Modules.Progress;
using Zenject;

namespace XO.Modules.Window.Windows.Settings
{
  public class AudioController : IInitializable
  {
    private const string Music = "music";
    private const string Sound = "sound";
    
    private readonly ProgressData _progressData;
    private readonly AudioMixer _audioMixer;

    public AudioController(ProgressData progressData, AudioMixer audioMixer)
    {
      _progressData = progressData;
      _audioMixer = audioMixer;
    }

    public void Initialize() => 
      Update();

    public void Update()
    {
      Update(Music, _progressData.SettingsData.TurnMusic);
      Update(Sound, _progressData.SettingsData.TurnSound);
    }

    private void Update(string name, bool value) => 
      _audioMixer.SetFloat(name, value ? 0f : -80f);
  }
}
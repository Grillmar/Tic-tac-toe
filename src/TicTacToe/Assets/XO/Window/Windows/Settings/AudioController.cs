using UnityEngine.Audio;
using XO.Modules.Progress;

namespace XO.Window.Windows.Settings
{
  public class AudioController
  {
    private const string Music = "music";
    private const string Sound = "sound";
    
    private readonly Progress _progress;
    private readonly AudioMixer _audioMixer;

    public AudioController(Progress progress, AudioMixer audioMixer)
    {
      _progress = progress;
      _audioMixer = audioMixer;
    }

    public void Initialize()
    {
      Update();
    }

    public void Update()
    {
      Update(Music, _progress.SettingsData.TurnMusic);
      Update(Sound, _progress.SettingsData.TurnSound);
    }

    private void Update(string name, bool value) => 
      _audioMixer.SetFloat(name, value ? 0f : -80f);
  }
}
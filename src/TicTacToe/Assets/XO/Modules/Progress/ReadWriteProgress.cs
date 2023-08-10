using System;
using UnityEngine;
using XO.Extensions;
using Zenject;

namespace XO.Modules.Progress
{
  public class ReadWriteProgress : IInitializable, IDisposable
  {
    private const string SettingsKey = "Settings";
    
    private readonly Progress _progress;

    public ReadWriteProgress(Progress progress) => 
      _progress = progress;

    public void Initialize()
    {
      _progress.SettingsData = HasProgress() 
        ? LoadProgress() 
        : new SettingsData();
    }

    public void Dispose()
    {
      SaveProgress();
    }
    
    public bool HasProgress() => 
      PlayerPrefs.HasKey(SettingsKey);

    public void SaveProgress()
    {
      PlayerPrefs.SetString(SettingsKey, _progress.SettingsData.ToJson());
      PlayerPrefs.Save();
    }

    public SettingsData LoadProgress() =>
      PlayerPrefs.GetString(SettingsKey)?.ToDeserialize<SettingsData>();
  }
}
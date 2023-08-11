using System;
using UnityEngine;
using XO.Modules.Extensions;
using Zenject;

namespace XO.Modules.Progress
{
  public class ReadWriteProgress : IInitializable, IDisposable
  {
    private const string SettingsKey = "Settings";
    
    private readonly ProgressData _progressData;

    public ReadWriteProgress(ProgressData progressData) => 
      _progressData = progressData;

    public void Initialize()
    {
      _progressData.SettingsData = HasProgress() 
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
      PlayerPrefs.SetString(SettingsKey, _progressData.SettingsData.ToJson());
      PlayerPrefs.Save();
    }

    public SettingsData LoadProgress() =>
      PlayerPrefs.GetString(SettingsKey)?.ToDeserialize<SettingsData>();
  }
}
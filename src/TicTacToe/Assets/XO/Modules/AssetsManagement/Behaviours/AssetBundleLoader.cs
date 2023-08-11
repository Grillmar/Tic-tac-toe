using System.IO;
using TMPro;
using UnityEngine;
using XO.Modules.Progress;
using Zenject;

namespace XO.Modules.AssetsManagement.Behaviours
{
  public class AssetBundleLoader : MonoBehaviour
  {
    public TMP_Dropdown Dropdown;

    private IAssetProvider _assetProvider;
    private string[] _assetBundleFiles;
    private ProgressData _progressData;

    [Inject]
    public void SetDependency(IAssetProvider assetProvider, ProgressData progressData)
    {
      _progressData = progressData;
      _assetProvider = assetProvider;
    }

    void Start()
    {
      _assetBundleFiles = _assetProvider.GetAllAssetBundles();

      UpdateDropdownWith(_assetBundleFiles);

      Dropdown.value = _progressData.SettingsData.BundleIndex;
      _assetProvider.LoadAssetBundle(_assetBundleFiles[_progressData.SettingsData.BundleIndex]);

      Dropdown.onValueChanged.AddListener(ReloadAssetBundle);
    }

    private void OnDestroy() =>
      Dropdown.onValueChanged.RemoveListener(ReloadAssetBundle);

    private void ReloadAssetBundle(int index)
    {
      _progressData.SettingsData.BundleIndex = index;
      _assetProvider.LoadAssetBundle(_assetBundleFiles[index]);
    }

    private void UpdateDropdownWith(string[] assetBundleFiles)
    {
      Dropdown.ClearOptions();

      foreach (string assetBundleFile in assetBundleFiles)
      {
        string assetBundleFileName = Path.GetFileNameWithoutExtension(assetBundleFile);
        Dropdown.options.Add(new TMP_Dropdown.OptionData(assetBundleFileName));
      }

      Dropdown.RefreshShownValue();
    }
  }
}
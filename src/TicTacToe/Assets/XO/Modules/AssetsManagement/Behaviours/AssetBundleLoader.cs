using System.IO;
using TMPro;
using UnityEngine;
using Zenject;

namespace XO.Modules.AssetsManagement.Behaviours
{
  public class AssetBundleLoader : MonoBehaviour
  {
    public TMP_Dropdown Dropdown;

    private IAssetProvider _assetProvider;
    private string[] _assetBundleFiles;
    private Progress.Progress _progress;

    [Inject]
    public void SetDependency(IAssetProvider assetProvider, Progress.Progress progress)
    {
      _progress = progress;
      _assetProvider = assetProvider;
    }

    void Start()
    {
      _assetBundleFiles = _assetProvider.GetAllAssetBundles();

      UpdateDropdownWith(_assetBundleFiles);

      Dropdown.value = _progress.SettingsData.BundleIndex;
      _assetProvider.LoadAssetBundle(_assetBundleFiles[_progress.SettingsData.BundleIndex]);

      Dropdown.onValueChanged.AddListener(ReloadAssetBundle);
    }

    private void OnDestroy() =>
      Dropdown.onValueChanged.RemoveListener(ReloadAssetBundle);

    private void ReloadAssetBundle(int index)
    {
      _progress.SettingsData.BundleIndex = index;
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
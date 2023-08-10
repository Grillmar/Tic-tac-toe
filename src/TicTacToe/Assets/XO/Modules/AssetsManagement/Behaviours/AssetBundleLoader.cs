using System.IO;
using TMPro;
using UnityEngine;
using XO.Modules.AssetsManagement;
using Zenject;

public class AssetBundleLoader : MonoBehaviour
{
  public TMP_Dropdown Dropdown;

  private IAssetProvider _assetProvider;
  private string[] _assetBundleFiles;

  [Inject]
  public void SetDependency(IAssetProvider assetProvider) =>
    _assetProvider = assetProvider;

  void Start()
  {
    _assetBundleFiles = _assetProvider.GetAllAssetBundles();

    UpdateDropdownWith(_assetBundleFiles);

    _assetProvider.LoadAssetBundle(_assetBundleFiles[0]);

    Dropdown.onValueChanged.AddListener(ReloadAssetBundle);
  }

  private void OnDestroy() =>
    Dropdown.onValueChanged.RemoveListener(ReloadAssetBundle);

  private void ReloadAssetBundle(int index) =>
    _assetProvider.LoadAssetBundle(_assetBundleFiles[index]);

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
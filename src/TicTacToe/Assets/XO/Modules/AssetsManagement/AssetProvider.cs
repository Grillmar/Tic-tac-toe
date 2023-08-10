using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace XO.Modules.AssetsManagement
{
  public class AssetProvider : IAssetProvider
  {
    public bool IsBundleReady { get; private set; }
    
    private AssetBundleCreateRequest _assetBundleRequest;

    public async void LoadAssetBundle(string assetBundleName)
    {
      IsBundleReady = false;
      string assetBundlePath = Path.Combine(Application.streamingAssetsPath, assetBundleName);
      _assetBundleRequest = AssetBundle.LoadFromFileAsync(assetBundlePath);
      await _assetBundleRequest;
      
      if (_assetBundleRequest.assetBundle == null)
      {
        Debug.LogError("Failed to load Asset Bundle.");
        return;
      }

      IsBundleReady = true;
    }

    public async Task<T> LoadAsset<T>(string name) where T : Object
    {
      if (!IsBundleReady)
      {
        return default;
      }
      AssetBundleRequest request = _assetBundleRequest.assetBundle.LoadAssetAsync<T>(name);
      await request;

      if (request.asset == null) 
        Debug.LogError($"Failed to load {typeof(T)} from Asset Bundle.");

      return (T)request.asset;
    }
  }
}
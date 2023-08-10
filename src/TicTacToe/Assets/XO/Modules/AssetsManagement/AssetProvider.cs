using System;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace XO.Modules.AssetsManagement
{
  public class AssetProvider : IAssetProvider
  {
    public bool IsBundleReady { get; private set; }

    private AssetBundleCreateRequest _assetBundleRequest;

    public async void LoadAssetBundle(string assetBundleName)
    {
      if (IsBundleReady)
      {
        if (_assetBundleRequest.assetBundle != null) 
          _assetBundleRequest.assetBundle.Unload(false);
        IsBundleReady = false;
      }

      string assetBundlePath = Path.Combine(Application.streamingAssetsPath, assetBundleName);
      _assetBundleRequest = AssetBundle.LoadFromFileAsync(assetBundlePath);
      IsBundleReady = true;
      await _assetBundleRequest;

      if (_assetBundleRequest.assetBundle == null) 
        Debug.LogError("Failed to load Asset Bundle.");
    }

    public async Task<T> LoadAsset<T>(string name) where T : Object
    {
      if (!IsBundleReady)
      {
        return default;
      }

      AssetBundleRequest request = _assetBundleRequest.assetBundle.LoadAssetAsync<T>(name);
      await request;

      if (request.asset != null) 
        return (T)request.asset;
      
      string[] allAssetNames = _assetBundleRequest.assetBundle.GetAllAssetNames();
      foreach (string assetName in allAssetNames)
      {
        string fileName = Path.GetFileNameWithoutExtension(assetName);
        
        if (!fileName.Equals(name, StringComparison.OrdinalIgnoreCase))
          continue;
        
        T asset = _assetBundleRequest.assetBundle.LoadAsset<T>(assetName);
        if (asset != null)
          return asset;
      }
      
      Debug.Log($"Failed to load {typeof(T)} from Asset Bundle.");
      return null;
    }

    public string[] GetAllAssetBundles()
    {
      string streamingAssetsPath = Application.streamingAssetsPath;

      string[] assetBundleFiles = Directory.GetFiles(streamingAssetsPath, "*.assetbundle");

      return assetBundleFiles;
    }
    
    public async Task<Sprite> LoadSprites(string name)
    {
      var texture = await LoadAsset<Texture2D>(name);
      return texture != null 
        ? Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f) 
        : null;
    }
  }
}
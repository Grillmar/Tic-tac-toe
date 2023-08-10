using System.Threading.Tasks;
using UnityEngine;

namespace XO.Modules.AssetsManagement
{
  public interface IAssetProvider
  {
    bool IsBundleReady { get; }
    void LoadAssetBundle(string assetBundleName);
    Task<T> LoadAsset<T>(string name) where T : Object;
  }
}
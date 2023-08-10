using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace XO.Modules.AssetsManagement.Behaviours
{
  public class ImageLoader : MonoBehaviour
  {
    public Image Image;
    public string AssetName;
    private IAssetProvider _assetProvider;

    [Inject]
    public void SetDependency(IAssetProvider assetProvider) => 
      _assetProvider = assetProvider;

    public void Start()
    {
      UpdateImage();
    }

    private async void UpdateImage()
    {
      var sprite = await _assetProvider.LoadSprites(AssetName);
      Image.sprite = sprite ? sprite : Image.sprite;
    }
  }
}
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
      Texture2D texture = await _assetProvider.LoadAsset<Texture2D>(AssetName);

      if (texture == null)
        return;
      
      Image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }
  }
}
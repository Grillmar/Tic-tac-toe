using System.IO;
using UnityEditor;
using UnityEngine;

namespace XO.Editor
{
  public class AssetBuilder : EditorWindow
  {
    private string _assetBundleName = "Enter asset bundle name";

    private Texture2D _xSprite;
    private Texture2D _oSprite;

    private Texture2D _backgroundSprite;
    private readonly int _space = 40;

    private void OnGUI()
    {
      _assetBundleName = EditorGUILayout.TextField("Asset Bundle Name", _assetBundleName);

      _xSprite = (Texture2D)EditorGUILayout.ObjectField("X Sprite", _xSprite, typeof(Texture2D), false);

      _oSprite = (Texture2D)EditorGUILayout.ObjectField("O Sprite", _oSprite, typeof(Texture2D), false);

      _backgroundSprite = (Texture2D)EditorGUILayout.ObjectField("Background Sprite", _backgroundSprite, typeof(Texture2D), false);
   
      if (GUILayout.Button("Create Asset Bundle"))
      {
        CreateAssetBundle();
      }

      if (_xSprite != null) 
        GUILayout.Label(_xSprite, GUILayout.Width(position.width - _space), GUILayout.Height(position.width - _space));
      if (_oSprite != null) 
        GUILayout.Label(_oSprite, GUILayout.Width(position.width - _space), GUILayout.Height(position.width - _space));

      if (_backgroundSprite != null) 
        GUILayout.Label(_backgroundSprite, GUILayout.Width(position.width - _space), GUILayout.Height(position.width - _space));
    }

    [MenuItem("Build/Asset Builder")]
    public static void SliceSettingsWindow()
    {
      var window = GetWindow<AssetBuilder>("Asset Builder Window");
      window.Show();
    }

    private void CreateAssetBundle()
    {
      if (_xSprite == null && _oSprite == null && _xSprite == null)
      {
        Debug.LogError("No images selected!");
        return;
      }

      PrepareAsset(_xSprite, "X");
      PrepareAsset(_oSprite, "O");
      PrepareAsset(_backgroundSprite, "Background");
    
      AssetBundleBuild[] builds = CreateAssetBundleBuilds();

      AssetDatabase.Refresh();
    
      BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, builds, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

      string outputPath = Path.Combine(Application.streamingAssetsPath, _assetBundleName);
      Debug.Log("Asset Bundle created at: " + outputPath);
    
      AssetDatabase.Refresh();
    }

    private void PrepareAsset(Object asset, string name)
    {
      string originalImagePath = AssetDatabase.GetAssetPath(asset);

      string newImageName = name + ".png";

      string newImagePath = Path.Combine(Path.GetDirectoryName(originalImagePath), newImageName);
    
      AssetDatabase.MoveAsset(originalImagePath, newImagePath);
    }

    private AssetBundleBuild[] CreateAssetBundleBuilds()
    {
      var builds = new AssetBundleBuild[1];
      builds[0].assetNames = new[] { AssetDatabase.GetAssetPath(_xSprite), AssetDatabase.GetAssetPath(_oSprite), AssetDatabase.GetAssetPath(_backgroundSprite) };
      builds[0].assetBundleName = _assetBundleName + ".assetbundle";
      return builds;
    }
  }
}
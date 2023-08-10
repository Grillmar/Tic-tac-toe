using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBuilder : EditorWindow
{
  private string _assetBundleName = "Enter asset bundle name";

  private Texture2D _xSprite;
  private Texture2D _oSprite;

  private Texture2D _backgroundSprite;
  private int _space = 40;

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
      Debug.LogError("No image selected!");
      return;
    }

    string outputPath = Path.Combine(Application.streamingAssetsPath, _assetBundleName + ".assetbundle");

    BuildPipeline.BuildAssetBundle(null, new Object[] { _xSprite, _oSprite, _backgroundSprite }, outputPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

    Debug.Log("Asset Bundle created at: " + outputPath);
  }
}
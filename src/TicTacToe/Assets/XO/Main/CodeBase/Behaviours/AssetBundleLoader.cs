using System.IO;
using TMPro;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    public TMP_Dropdown Dropdown;

    void Start()
    {
        string streamingAssetsPath = Application.streamingAssetsPath;

        string[] assetBundleFiles = Directory.GetFiles(streamingAssetsPath, "*.assetbundle");

        Dropdown.ClearOptions();
        
        foreach (string assetBundleFile in assetBundleFiles)
        {
            string assetBundleFileName = Path.GetFileNameWithoutExtension(assetBundleFile);
            Debug.Log(assetBundleFileName);
            
            Dropdown.options.Add(new TMP_Dropdown.OptionData(assetBundleFileName));
        }
        
        Dropdown.RefreshShownValue();
    }
}

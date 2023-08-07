using UnityEngine;
using UnityEngine.UI;
using XO.Extensions;

namespace XO.Modules.Curtain
{
  public class LoadingCurtain : MonoBehaviour
  {
    public Image Background;
    
    public void Show()
    {
      Background.Alpha(1);
    }

    public void Hide()
    {
      Background.Alpha(0);
    }
  }
}
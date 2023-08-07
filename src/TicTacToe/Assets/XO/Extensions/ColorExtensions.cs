using UnityEngine;
using UnityEngine.UI;

namespace XO.Extensions
{
  public static class ColorExtensions
  {
    public static Color Alpha(this Color color, float a)
    {
      color.a = a;
      return color;
    }
    
    public static Image Alpha(this Image image, float a)
    {
      image.color = image.color.Alpha(a);
      return image;
    }
  }
}
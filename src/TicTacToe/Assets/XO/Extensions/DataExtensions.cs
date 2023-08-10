using UnityEngine;

namespace XO.Extensions
{
  public static class DataExtensions
  {
    public static T ToDeserialize<T>(this string json) => 
      JsonUtility.FromJson<T>(json);

    public static string ToJson(this object self) => 
      JsonUtility.ToJson(self);
    
    public static bool IsDestroyedOrNull(this object o) =>
      o == null || o.Equals(null);
  }
}
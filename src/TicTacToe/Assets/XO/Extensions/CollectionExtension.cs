using System;
using System.Collections.Generic;

namespace XO.Extensions
{
  public static class CollectionExtension
  {
    private static readonly Random Random = new Random();

    public static T RandomElement<T>(this IList<T> list) => 
      list[Random.Next(list.Count)];

    public static T RandomElement<T>(this T[] array) => 
      array[Random.Next(array.Length)];

    public static void Shuffle<T>(this IList<T> list)
    {
      int range = list.Count;  
      while (range > 1) {  
        range--;  
        int next = Random.Next(range + 1);  
        (list[next], list[range]) = (list[range], list[next]);
      }  
    }
  }
}
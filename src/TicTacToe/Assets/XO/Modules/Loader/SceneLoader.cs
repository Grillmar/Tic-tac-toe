using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XO.Modules.Loader
{
  public class SceneLoader : ISceneLoader
  {
    public async UniTask LoadScene(string name)
    {
      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);

      while (!asyncOperation.isDone) 
        await UniTask.Yield();
    }

    public async UniTask LoadScene(string name, CancellationToken cancellationToken)
    {
      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
      
      while (!asyncOperation.isDone && !cancellationToken.IsCancellationRequested) 
        await UniTask.Yield();

      if (cancellationToken.IsCancellationRequested) 
        Debug.Log("Scene loading cancelled.");
    }
  }
}
using System.Threading;
using Cysharp.Threading.Tasks;

namespace XO.Modules.Loader
{
  public interface ISceneLoader
  {
    UniTask LoadScene(string name);
    UniTask LoadScene(string name, CancellationToken cancellationToken);
  }
}
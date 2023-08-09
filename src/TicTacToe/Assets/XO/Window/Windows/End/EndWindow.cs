using TMPro;
using Zenject;

namespace XO.Window.Windows.End
{
  public class EndWindow : PayloadedWindow<string>
  {
    public TextMeshProUGUI Who;

    private IWindowService _windowService;

    public override void Set(string who) =>
      Who.text = who;

    [Inject]
    public void SetDependency(IWindowService windowService) =>
      _windowService = windowService;

    private void OnDestroy() =>
      _windowService.Close(TypeId);
  }
}
using UnityEngine;
using UnityEngine.UI;
using XO.Modules.Window.Windows;
using Zenject;

namespace XO.Modules.Window.Behaviours
{
  public class OpenWindow : MonoBehaviour
  {
    public Button Button;
  
    public WindowTypeId TypeId;
    private IWindowService _windowService;

    [Inject]
    public void SetDependency(IWindowService windowService) => 
      _windowService = windowService;

    private void Start()
    {
      if (Button == null) 
        Button = GetComponent<Button>();
    
      if (Button == null) 
        return;
    
      Button.onClick.AddListener(Open);
    }

    private void Open() => 
      _windowService.Open(TypeId);
  }
}

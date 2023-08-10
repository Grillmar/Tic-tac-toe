using TMPro;
using UnityEngine;
using Zenject;

namespace XO.Gameplay.CodeBase.Timer
{
  public class TimerView : MonoBehaviour
  {
    public TextMeshProUGUI TimerText;
    private CoroutineTimer _timer;

    [Inject]
    public void SetDependency(CoroutineTimer timer) =>
      _timer = timer;

    private void Start() => 
      _timer.Update += UpdateText;

    private void OnDestroy() => 
      _timer.Update -= UpdateText;

    private void UpdateText(int seconds) => 
      TimerText.text = seconds.ToString();
  }
}
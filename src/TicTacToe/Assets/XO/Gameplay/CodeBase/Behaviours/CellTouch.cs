using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using XO.Gameplay.CodeBase.Player;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours
{
  public class CellTouch : MonoBehaviour, IPointerClickHandler
  {
    public UnityEvent OnProduce;

    private (int row, int column) _cell;
    
    private PlayersInGame playersInGame;

    [Inject]
    public void SetDependency(PlayersInGame playersInGame) => 
      this.playersInGame = playersInGame;

    public void Initialize((int row, int column) cell) => 
      _cell = cell;

    public void OnPointerClick(PointerEventData eventData)
    {
      OnProduce?.Invoke();
      if (playersInGame.GetActivePlayer() is RealPlayer realPlayer) 
        realPlayer.Move(_cell);
    }
  }
}
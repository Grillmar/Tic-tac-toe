using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XO.Extensions;
using Zenject;

namespace XO.Gameplay.CodeBase.Behaviours.Buttons
{
  public class HintButton : MonoBehaviour
  {
    public Button Button;
    public BoardView BoardView;

    public Color blinkColor;
    public float blinkDuration = 0.5f;
    public int blinkCount = 3;

    private Image _targetImage;
    private Color _originalColor;
    private Coroutine _blinkCoroutine;
    
    private Game _game;

    [Inject]
    public void SetDependency(Game game) =>
      _game = game;

    public void Start()
    {
      Button.onClick.AddListener(Hint);
      _game.UpdateState += StopBlinking;
    }

    public void OnDestroy()
    {
      Button.onClick.RemoveListener(Hint);
      _game.UpdateState -= StopBlinking;
    }

    private void Hint()
    {
      Cell cell = GetRandomCell();
      if (cell == null)
      {
        Debug.Log("Nothing to hint.");
        return;
      }
      
      CellView cellView = BoardView.GetCellView(cell);

      StartBlinking(cellView.View, blinkCount, blinkDuration, blinkColor);
    }

    private void StartBlinking(Image image, int count, float duration, Color color)
    {
      StopBlinking();
      
      _targetImage = image;
      _originalColor = _targetImage.color;
      
      _blinkCoroutine = StartCoroutine(BlinkCoroutine(image, count, duration, color));
    }

    private void StopBlinking()
    {
      if (_blinkCoroutine == null) 
        return;
      
      _targetImage.color = _originalColor;
      StopCoroutine(_blinkCoroutine);
      _blinkCoroutine = null;
    }

    private void StopBlinking(GameState obj) => 
      StopBlinking();

    private IEnumerator BlinkCoroutine(Image image, int count, float duration, Color сolor)
    {
      for (var i = 0; i < count; i++)
      {
        image.color = сolor;
        yield return new WaitForSeconds(duration / 2);

        image.color = _originalColor;
        yield return new WaitForSeconds(duration / 2);
      }

      image.color = _originalColor;
      _blinkCoroutine = null;
    }

    private Cell GetRandomCell()
    {
      IList<Cell> possibleMoves = _game.GetPossibleMoves();
      if (!possibleMoves.Any())
        return null;

      Cell randomElement = possibleMoves.RandomElement();
      return randomElement;
    }
  }
}
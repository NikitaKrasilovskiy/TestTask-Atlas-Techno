using DG.Tweening;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    private void OnMouseDown()
    {
        if (!_gameController._rightFan && !_gameController._leftFan)
        {
            transform.DOMoveY(0.0465f, 0.5f);
            _gameController._rightFan = true;
            _gameController.SoundBlower(true);
        }
        else if (_gameController._rightFan && !_gameController._leftFan)
        {
            transform.DOMoveY(0.05214914f, 0.5f);
            _gameController._rightFan = false;
            _gameController.SoundBlower(false);
        }
    }
    private void OnMouseEnter()
    {
        _gameController._textView[1].SetActive(true);
    }

    private void OnMouseExit()
    {
        _gameController._textView[1].SetActive(false);
    }
}

using DG.Tweening;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    private void OnMouseDown()
    {
        if (!_gameController._leftFan && !_gameController._rightFan)
        {
            transform.DOMoveY(0.0465f, 0.5f);
            _gameController._leftFan = true;
            _gameController.SoundBlower(true);
        }
        else if (_gameController._leftFan && !_gameController._rightFan)
        {
            transform.DOMoveY(0.05214914f, 0.5f);
            _gameController._leftFan = false;
            _gameController.SoundBlower(false);
        }
    }

    private void OnMouseEnter()
    {
        _gameController._textView[0].SetActive(true);
    }

    private void OnMouseExit()
    {
        _gameController._textView[0].SetActive(false);
    }
}

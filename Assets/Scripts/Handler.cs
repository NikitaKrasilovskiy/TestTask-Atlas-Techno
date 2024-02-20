using DG.Tweening;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    private void OnMouseDown()
    {
        _gameController.HingleRotate();
    }

    private void OnMouseEnter()
    {
        _gameController._textView[2].SetActive(true);
    }

    private void OnMouseExit()
    {
        _gameController._textView[2].SetActive(false);
    }
}

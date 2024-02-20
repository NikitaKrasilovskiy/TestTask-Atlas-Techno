using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _mouseSprite;
    [SerializeField] private Image _mouse;
    [SerializeField] private GameObject _miniText;
    [SerializeField] private GameObject[] _textMiniMouse;
    [SerializeField] private CameraRotate _cameraRotate;
    [SerializeField] private GameObject _object;
    [SerializeField] private Transform _panelMenu;
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonDemo;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private GameObject[] _textMouse;

    private Tween activAnim;

    private void Awake()
    {
        _buttonStart.onClick.AddListener(delegate { Play(); CloseDemo(); });
        _buttonDemo.onClick.AddListener(delegate { Demo();});
        _buttonExit.onClick.AddListener(delegate { Exit(); });
    }

    private void Play()
    {
        DOTween.Sequence()
            .Join(_panelMenu.transform.DOScale(0, 1).SetEase(Ease.InBack))
            .Join(_object.transform.DOScale(1, 3).SetEase(Ease.InOutSine))
            .Join(_buttonExit.GetComponent<RectTransform>().DOAnchorPos(new Vector3(150, -70, 0), 1).SetEase(Ease.InOutSine))
            .AppendCallback(delegate { _panelMenu.gameObject.SetActive(false); _miniText.SetActive(true); });
    }

    private void Demo()
    {
        _buttonDemo.onClick.RemoveAllListeners();
        _buttonDemo.onClick.AddListener(delegate { CloseDemo(); });
        _buttonDemo.GetComponentInChildren<TextMeshProUGUI>().text = "Скрыть управление";

        activAnim = DOTween.Sequence()
            .Join(_mouse.gameObject.transform.DOScale(0.8f, 1).SetEase(Ease.InOutSine))
            .Join(_mouse.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-873, 130, 0), 1).SetEase(Ease.InOutSine))
            .AppendCallback(delegate { _mouse.sprite = _mouseSprite[1]; })
            .Append(_textMouse[0].transform.DOScale(1, 1).SetEase(Ease.InOutSine))
            .AppendInterval(1)
            .AppendCallback(delegate { _mouse.sprite = _mouseSprite[2]; })
            .Append(_textMouse[1].transform.DOScale(1, 1).SetEase(Ease.InOutSine))
            .AppendInterval(1)
            .AppendCallback(delegate { _mouse.sprite = _mouseSprite[3]; })
            .Append(_textMouse[2].transform.DOScale(1, 1).SetEase(Ease.InOutSine))
            .AppendInterval(1)
            .AppendCallback(delegate { _mouse.sprite = _mouseSprite[0]; });
    }

    private void CloseDemo()
    {
        activAnim.Kill(false);
        _mouse.sprite = _mouseSprite[0];

        _buttonDemo.GetComponentInChildren<TextMeshProUGUI>().text = "Показать управление";

        foreach (var item in _textMouse)
        { item.transform.DOScale(0, 1).SetEase(Ease.InOutSine); }

        _mouse.gameObject.transform.DOScale(0.5f, 1).SetEase(Ease.InOutSine);
        _mouse.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-100, 100, 0), 1).SetEase(Ease.InOutSine);
        _buttonDemo.onClick.RemoveAllListeners();
        _buttonDemo.onClick.AddListener(delegate { Demo(); });
    }

    private void Exit()
    { SceneManager.LoadScene(0); }
}
using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool _leftFan;
    public bool _rightFan;
    public GameObject[] _textView;

    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private GameObject _fan;
    [SerializeField] private GameObject _hingle;
    [SerializeField] private GameObject _handle;
    [SerializeField] private Material _lighting;
    
    [SerializeField] private AudioClip _click, _blower;
    [SerializeField] private AudioSource _sorce;

    private int _number;

    private void Start()
    {
        _lighting.DOColor(Color.green, 2).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if (_leftFan && !_rightFan)
        { _fan.transform.Rotate(0, 0, 0 - 300 * Time.deltaTime); }
        else if (!_leftFan && _rightFan)
        { _fan.transform.Rotate(0, 0, 0 + 300 * Time.deltaTime); }
    }

    public void HingleRotate()
    {
        SoundClick();

        _number++;
        var x = 0;

        switch (_number)
        {
            case 1: x = 15; break;
            case 2: x = -15; break;
            case 3: x = 0; _number = 0; break;
            default: break;
        }
        _hingle.transform.DORotate(new Vector3(x, 0, 0), 1);
        _handle.transform.DORotate(new Vector3(x, 0, 0), 1);
    }
    public void SoundBlower(bool value)
    {
        SoundClick();
        _sorce.clip = _blower;
        if (value) _sorce.Play();
        else _sorce.Stop();
    }

    private void SoundClick()
    {
        var sorce = this.gameObject.AddComponent<AudioSource>();
        sorce.clip = _click;
        sorce.Play();
        Destroy(sorce, 1);
    }

    
}
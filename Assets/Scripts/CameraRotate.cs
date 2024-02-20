using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform target;   // объект вокруг которого будем вращать камеру
    public float sensitivity;  // чувствительность мышки
    public float limit;        // ограничение вращения по Y
    public float zoom;         // чувствительность при увеличении, колесиком мышки
    public float zoomMax;      // макс. увеличение
    public float zoomMin;      // мин. увеличение

    [SerializeField] private GameObject _panelMenu;

    private Vector3 offset = new(0, 0.3f, 0);
    private float X, Y;

    private void Awake()
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;

        RotateCam();
        ZoomCamera();
    }

    private void Update()
    {
        if (_panelMenu.activeInHierarchy) return;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset.z += zoom;
            ZoomCamera();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset.z -= zoom;
            ZoomCamera();
        }

        if (Input.GetMouseButton(1))
        { RotateCam(); }
    }

    private void RotateCam()
    {
        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        Y += Input.GetAxis("Mouse Y") * sensitivity;
        Y = Mathf.Clamp(Y, -limit, limit);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset + target.position;
    }

    private void ZoomCamera()
    {
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMin), -Mathf.Abs(zoomMax));
        transform.position = transform.localRotation * offset + target.position;
    }
}
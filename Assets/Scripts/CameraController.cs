using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public float panSpeed = 30f;
    public float rotationSpeed = 30f;
    public float zoomSpeed = 3f;
    public Camera mainCamera;
    public bool enableRotation;

    [Header("Camera Restrictions")]
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 10f;
    public float maxX = 80f;
    public float minZ = 10f;
    public float maxZ = 80f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        GameManager.GameIsOver = false;

        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    private void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("q") && enableRotation)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey("e") && enableRotation)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey("r"))
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        if (Input.GetKey("left shift") && enableRotation)
        {
            pos.y -= 10 * zoomSpeed * Time.deltaTime;
        }

        if (Input.GetKey("space") && enableRotation)
        {
            pos.y += 10 * zoomSpeed * Time.deltaTime;
        }

        if (enableRotation)
        {
            pos.y -= scroll * 1000 * zoomSpeed * Time.deltaTime;
        }

        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        Vector3 rot = mainCamera.transform.eulerAngles;

        // Camera rotation in relation to distance to ground MATH
        rot.x = pos.y * 0.7129f + 22.8705f;

        transform.position = pos;
        mainCamera.transform.eulerAngles = rot;
    }
}

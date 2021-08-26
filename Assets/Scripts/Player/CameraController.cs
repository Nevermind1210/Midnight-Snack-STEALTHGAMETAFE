using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Setup")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

    // MoveCamera() function placed in LateUpdate() so there is no glitchiness as this updates at the end of the frame
    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        // smoothly moves the camera to the offset position
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}

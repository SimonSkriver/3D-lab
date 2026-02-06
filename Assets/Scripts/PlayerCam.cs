using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    [Header ("Camera")]
    [SerializeField] float sensitivity;
    [SerializeField] Transform playerOrientation;
    [SerializeField] Vector2 lookDirection;
    private InputAction lookAction;
    private Vector2 cameraRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookAction = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        HandleCamera();
    }

    void HandleCamera()
    {
        lookDirection = lookAction.ReadValue<Vector2>();
        cameraRotation += lookDirection * sensitivity;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90f, 90f);
        transform.rotation = Quaternion.Euler(-cameraRotation.y, cameraRotation.x, 0f);
        playerOrientation.rotation = Quaternion.Euler(0f, cameraRotation.x, 0f);
    }
}
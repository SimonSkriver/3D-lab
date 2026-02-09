using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    [Header ("Camera")]
    [SerializeField] float sensitivity;
    [SerializeField] Transform playerOrientation;
    [SerializeField] Vector2 lookInput;
    private InputAction lookAction;
    private Vector2 cameraRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookAction = InputSystem.actions.FindAction("Look");
    }

    void LateUpdate()
    {
        HandleCamera();
    }

    void HandleCamera()
    {
        lookInput = lookAction.ReadValue<Vector2>();
        cameraRotation += lookInput * sensitivity * Time.deltaTime;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90f, 90f);
        transform.rotation = Quaternion.Euler(-cameraRotation.y, cameraRotation.x, 0f);
        playerOrientation.rotation = Quaternion.Euler(0f, cameraRotation.x, 0f);
    }
}
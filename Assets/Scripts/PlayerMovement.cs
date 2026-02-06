using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header ("Actions")]
    [SerializeField] InputAction move;
    [SerializeField] InputAction jump;
    [SerializeField] InputAction interact;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void GetActions()
    {
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        interact = InputSystem.actions.FindAction("Interact");
    }
}

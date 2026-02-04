using UnityEngine;
using UnityEngine.InputSystem;

public class DropAndPickup : MonoBehaviour
{
    [SerializeField] float raycastDistance;
    [SerializeField] Transform hands;
    [SerializeField] Transform oldObjectAnchor;

    private Transform heldObject;
    private InputAction interactAction;

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (interactAction.WasPressedThisFrame() && !heldObject)
        {
            Debug.Log("Casting ray");
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Object"))
                {
                    Debug.Log("Ray cast hit a cube");
                    Grab(hit.collider.transform);
                }
            }


        }
        else if (interactAction.WasPressedThisFrame() && heldObject)
        {
            Debug.Log("Dropping");
            Drop();
        }
    }

    void Grab(Transform puzzleObject)
    {
        if (heldObject != null)
        {
            return;
        }
        heldObject = puzzleObject;
        oldObjectAnchor = puzzleObject.parent;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        heldObject.GetComponent<BoxCollider>().enabled = false;

        heldObject.SetParent(hands);
        heldObject.localPosition = Vector3.zero;
        heldObject.localRotation = Quaternion.identity;
    }

    void Drop()
    {
        if (!heldObject)
        {
            return;
        }

        Transform puzzleObject = heldObject;
        puzzleObject.SetParent(oldObjectAnchor);
        puzzleObject.GetComponent<Rigidbody>().isKinematic = false;
        puzzleObject.GetComponent<BoxCollider>().enabled = true;
        puzzleObject.localRotation = Quaternion.identity;

        oldObjectAnchor = null;
        heldObject = null; 

        //return puzzleObject;
    }

    /*void OnInteract()
    {
        Debug.Log("Casting ray");
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Object"))
            {
                Debug.Log("Ray cast hit a cube");
                Grab(hit.collider.transform);
            }
        }
    }*/
}
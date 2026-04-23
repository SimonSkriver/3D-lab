using UnityEngine;

public class Camswitch : MonoBehaviour
{
    [SerializeField] GameObject cameraToTurnOn;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Entered the zone");
        if (collider.CompareTag("Player"))
        {
            Debug.Log("It was, in fact, the player");
            cameraToTurnOn.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        cameraToTurnOn.SetActive(false);
    }
}

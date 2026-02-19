using UnityEngine;

public class ThirstyMate : MonoBehaviour
{
    private bool hasTalked;
    public GameObject water;
    public DropAndPickup player;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasTalked)
        {
            Debug.Log("Yo, I'm thirsty, find water");
            hasTalked = true;
        }

        else if (other.gameObject.CompareTag("Player") && hasTalked && player.hasWater == false)
        {
            Debug.Log("The water might be squared shaped");
        }

        else if (other.gameObject.CompareTag("Player") && player.hasWater)
        {
            Debug.Log("Thanks dog");
            Destroy(water);
        }
    }
}

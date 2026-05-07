using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("You hit a checkpoint");
            SaveData myData = new SaveData();
            myData.playerHealth = 50f;
            SaveGameSystem.Save(myData);
        }
    }
}
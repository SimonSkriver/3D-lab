using UnityEngine;

public class Balloon : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip audioClip;


    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public void Pop()
    {
        audioSource.PlayOneShot(audioClip);
    }
}

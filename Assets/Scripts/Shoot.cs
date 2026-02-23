using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] Camera eyes;
    private InputAction shootAction;
    public AudioClip gunShotAudio;
    public AudioSource audioSource;


    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Shoot");    
    }

    void Update()
    {
        HandleShooting();
    }


    void HandleShooting()
    {
        if (shootAction.WasPerformedThisFrame())
        {
            if (Physics.Raycast(eyes.transform.position, eyes.transform.forward))
            {
                
            }
            smokeParticle.Play();
            audioSource.PlayOneShot(gunShotAudio);
        }
    }
}

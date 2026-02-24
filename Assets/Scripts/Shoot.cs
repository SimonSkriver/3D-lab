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
            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Target"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
            smokeParticle.Play();
            audioSource.PlayOneShot(gunShotAudio);
        }
    }
}

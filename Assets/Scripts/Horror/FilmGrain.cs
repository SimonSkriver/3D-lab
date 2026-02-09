using UnityEngine;
using UnityEngine.Rendering;

public class FilmGrainController : MonoBehaviour
{
    public Volume volume;
    public Transform targetObject;
    public float maxDistance = 20f; // Distance at which grain starts
    public float minDistance = 2f;  // Distance at which grain is maximum
    public float maxIntensity = 1f; // Max grain intensity (0-1)

    private UnityEngine.Rendering.Universal.FilmGrain filmGrainComponent;

    void Start()
    {
        // Get the Film Grain profile from the Volume
        if (volume.profile.TryGet<UnityEngine.Rendering.Universal.FilmGrain>(out filmGrainComponent))
        {
            filmGrainComponent.intensity.value = 0f; // Ensure it starts off
        }
    }

    void Update()
    {
        if (filmGrainComponent == null || targetObject == null) return;

        // Calculate distance
        float distance = Vector3.Distance(transform.position, targetObject.position);

        // Calculate intensity based on inverse distance (closer = higher)
        // Normalized intensity between 0 and 1
        float t = Mathf.InverseLerp(maxDistance, minDistance, distance);
        float newIntensity = Mathf.Lerp(0f, maxIntensity, t);

        // Apply intensity
        filmGrainComponent.intensity.Override(newIntensity);
    }
}

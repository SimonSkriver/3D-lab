using UnityEngine;

public class DistanceColor : MonoBehaviour
{
    public Transform target;
    public Material material;

    public float maxDistance = 10f;
    public Color nearColor = Color.green;
    public Color farColor = Color.blue;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        // Normalize distance to 0–1
        float t = Mathf.Clamp01(distance / maxDistance);

        // Lerp color based on distance
        Color color = Color.Lerp(nearColor, farColor, t);

        material.SetColor("_BaseColor", color); // URP/HDRP
        // material.SetColor("_Color", color);   // Built-in pipeline
    }
}
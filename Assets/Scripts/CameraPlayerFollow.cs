using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float camFollowSpeed;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 1.84f, -2.68f), Time.deltaTime * camFollowSpeed);
    }
}
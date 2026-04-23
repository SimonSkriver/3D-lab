using UnityEngine;

public class CamLerp : MonoBehaviour
{
    //[SerializeField] Camera mainCam;
    [SerializeField] Transform point0, point1;
    float counter;
    float maxTime = 5;

    public Transform camTarget;
    public Transform thingToMoveAround;

    void Start()
    {

    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, point1.position, Time.deltaTime);
        camTarget.position = Vector3.Lerp(camTarget.position, thingToMoveAround.position, Time.deltaTime);
        transform.LookAt(camTarget);
    }
}
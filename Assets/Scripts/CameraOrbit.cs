using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private Transform Cam;
    private Transform Pivot;
    private Vector3 Rotation;
    private float Distance;
    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;
    public float MinDistance = 1f;
    public float MaxDistance = 10f;

    // Use this for initialization
    void Start()
    {
        Cam = transform;
        Pivot = transform.parent;
        Distance = Vector3.Distance(Cam.position, Pivot.position);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                Rotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                Rotation.y += -Input.GetAxis("Mouse Y") * MouseSensitivity;
                //Clamp the y Rotation to not go upside down
                if (Rotation.y < -90f)
                {
                    Rotation.y = -90f;
                }
                else if (Rotation.y > 90f)
                {
                    Rotation.y = 90f;
                }
            }
        }
        //Zooming Input from our Mouse Scroll Wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            Distance += -Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity * Distance;
            Distance = Mathf.Clamp(Distance, MinDistance, MaxDistance);
        }
        //Actual Camera Rig Transformations
        Pivot.rotation = Quaternion.Lerp(
            Pivot.rotation,
            Quaternion.Euler(Rotation.y, Rotation.x, 0),
            Time.deltaTime * OrbitDampening);
        if (Cam.localPosition.z != Distance * -1f)
        {
            Cam.localPosition = new Vector3(
                0f,
                0f,
                Mathf.Lerp(
                    Cam.localPosition.z,
                    Distance * -1f,
                    Time.deltaTime * ScrollDampening));
        }
    }
}
using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{

    Transform cameraTransform;
    Transform parentTransform;

    Vector3 localRotation;

    public float cameraStartingRotationX = 0;
    public float cameraStartingRotationY = 45;
    [Space]

    public float cameraStartingDistance = 30f;
    [Space]

    private float currentCameraDistance;
    public float cameraMinDistance = 1.5f;
    public float cameraMaxDistance = 90f;
    [Space]

    public float cameraMinAngle = 0;
    public float cameraMaxAngle = 90;
    [Space]

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    [Space]

    public float ScrollDampening = 6f;
    [Space]

    public static bool CameraEnabled = false;
    [Space]

    public static bool ready = true;

    public static LineRenderer LR;
    int distance = 15;

    // Variable also used by putter 
    [HideInInspector] public static Vector3 facingDirection;


    // Start is called before the first Update
    void Awake()
    {
        // start at the correct position and rotation
        cameraTransform = transform;
        parentTransform = transform.parent;
        localRotation.x = cameraStartingRotationX;
        localRotation.y = cameraStartingRotationY;


        currentCameraDistance = cameraStartingDistance;

        LR = GetComponent<LineRenderer>();
    }

    void LateUpdate()
    {

        MoveCamera();
        UpdateLineRenderer();

    }

    void MoveCamera()
    {
            
        // if the camera is not disabled and we are ready to putt and the cursor is locked
        if (CameraEnabled && ready && Cursor.lockState == CursorLockMode.Locked)
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                //invert the default unity y axis
                localRotation.y += -Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp the y Rotation to min angle and not flipping over at the top
                localRotation.y = Mathf.Clamp(localRotation.y, cameraMinAngle, cameraMaxAngle);
            }
            //Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

                // make the camera go slower the closer it is to min distance (found on internet)
                ScrollAmount *= (currentCameraDistance * 0.3f);
                currentCameraDistance += ScrollAmount * -1f;

                currentCameraDistance = Mathf.Clamp(currentCameraDistance, cameraMinDistance, cameraMaxDistance);
            }
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        this.parentTransform.rotation = Quaternion.Lerp(parentTransform.rotation, QT, 1);

        // check if the camera is already at the desired position
        if (cameraTransform.localPosition.z != currentCameraDistance * -1f)
        {
            cameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(cameraTransform.localPosition.z, this.currentCameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }
    }

    void UpdateLineRenderer()
    {
        // Get the direction that the camera is facing, perpendicular to the UP vector
        facingDirection = Vector3.Cross(cameraTransform.right, Vector3.up);
        LR.SetPosition(0, parentTransform.position);
        LR.SetPosition(1, parentTransform.position + facingDirection * distance);
    }

    public void EnableAimLine()
    {
        LR.enabled = true;
    }

    public void DisableAimLine()
    {
        LR.enabled = false;
    }

    public void EnableCameraControlls()
    {
        CameraEnabled = true;
    }

    public void DisableCameraControlls()
    {
        CameraEnabled = false;
    }

    public void SleepThenEnable()
    {
        EnableCameraControlls();
        StartCoroutine(WaitASec());
    }

    public IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1);
        ready = true;
    }


}
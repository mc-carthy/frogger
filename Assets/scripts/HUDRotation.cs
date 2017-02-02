using UnityEngine;

public class HUDRotation : MonoBehaviour {

	private Camera mainCam;

    private void Awake ()
    {
        mainCam = transform.parent.GetComponentInChildren<Camera> ();
    }

    private void Update ()
    {
        Vector3 cameraForward = mainCam.transform.forward;
        Vector3 projectedCameraForward = Vector3.ProjectOnPlane (cameraForward, Vector3.up);
        transform.rotation = Quaternion.LookRotation (projectedCameraForward);
    }

}

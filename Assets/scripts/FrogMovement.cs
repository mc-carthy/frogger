using UnityEngine;

public class FrogMovement : MonoBehaviour {

    private Rigidbody rb;
    private Camera cam;
    private float jumpAngleDeg = 45;
    private float jumpSpeed = 5;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody> ();
        cam = GetComponentInChildren<Camera> ();
    }

	private void Update ()
    {
        Vector3 cameraForwardVector = Vector3.ProjectOnPlane (cam.transform.forward, Vector3.up).normalized;
        float jumpAngleRad = jumpAngleDeg * Mathf.Deg2Rad;
        Vector3 jumpVector = Vector3.RotateTowards (cameraForwardVector, Vector3.up, jumpAngleRad, 0);
        jumpVector *= jumpSpeed;
        if (Input.GetKeyDown (KeyCode.Space) || GvrViewer.Instance.Triggered)
        {
            rb.AddForce (jumpVector, ForceMode.VelocityChange);
        }
    }

}

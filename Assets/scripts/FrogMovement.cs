using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
public class FrogMovement : MonoBehaviour {

    private Rigidbody rb;
    private CapsuleCollider col;
    private Camera cam;
    private float jumpAngleDeg = 45;
    private float jumpSpeed = 5;
    private float colHeight;
    private float colSkinWidth = 0.25f;
    private float groundedRayLength;
    private float maxVelocity = 5;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody> ();
        col = GetComponent<CapsuleCollider> ();
        cam = GetComponentInChildren<Camera> ();
    }

    private void Start ()
    {
        colHeight = col.height;
        groundedRayLength = (colHeight / 2f) + colSkinWidth;
    }

	private void Update ()
    {
        bool isGrounded = Physics.Raycast (transform.position, -transform.up, groundedRayLength);
        if ((
            Input.GetKeyDown (KeyCode.Space) || GvrViewer.Instance.Triggered) && 
            isGrounded &&
            rb.velocity.magnitude < maxVelocity)
        {
            Vector3 cameraForwardVector = Vector3.ProjectOnPlane (cam.transform.forward, Vector3.up).normalized;
            float jumpAngleRad = jumpAngleDeg * Mathf.Deg2Rad;
            Vector3 jumpVector = Vector3.RotateTowards (cameraForwardVector, Vector3.up, jumpAngleRad, 0);
            jumpVector *= jumpSpeed;
            rb.AddForce (jumpVector, ForceMode.VelocityChange);
        }
    }

}

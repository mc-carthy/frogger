using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
public class FrogMovement : MonoBehaviour {

    private Rigidbody rb;
    private CapsuleCollider col;
    private Camera cam;
    private float jumpAngleDeg = 45;
    private float jumpSpeed = 700;
    private float colHeight;
    private float colSkinWidth = 7.5f;
    private float groundedRayLength;
    private float maxVelocity = 5;
    private int collisionCount;

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
        bool isGrounded = collisionCount > 0;
        if ((
            Input.GetKeyDown (KeyCode.Space) || GvrViewer.Instance.Triggered) && 
            isGrounded
            )
        {
            Jump ();
        }
    }

    private void OnCollisionEnter (Collision other)
    {
        collisionCount++;
    }

    private void OnCollisionExit (Collision other)
    {
        collisionCount--;
    }

    private void Jump ()
    {
        Vector3 cameraForwardVector = Vector3.ProjectOnPlane (cam.transform.forward, Vector3.up).normalized;
        float jumpAngleRad = jumpAngleDeg * Mathf.Deg2Rad;
        Vector3 jumpVector = Vector3.RotateTowards (cameraForwardVector, Vector3.up, jumpAngleRad, 0);
        jumpVector *= jumpSpeed;
        rb.AddForce (jumpVector, ForceMode.VelocityChange);
    }

}

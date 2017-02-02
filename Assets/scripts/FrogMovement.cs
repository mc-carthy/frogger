using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
public class FrogMovement : MonoBehaviour {

    private Rigidbody rb;
    private CapsuleCollider col;
    private Camera cam;
    private float jumpAngleDeg = 45;
    private float[] jumpSpeed = { 200, 350, 500 };
    private float colHeight;
    private float colSkinWidth = 7.5f;
    private float groundedRayLength;
    private int collisionCount;
    private int hopCount;

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
        if (isGrounded)
        {
            hopCount = 0;
        }
        if ((
            Input.GetKeyDown (KeyCode.Space) || GvrViewer.Instance.Triggered) && 
            hopCount < jumpSpeed.Length
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
        jumpVector *= jumpSpeed[hopCount];
        rb.AddForce (jumpVector, ForceMode.VelocityChange);
        hopCount++;
    }

}

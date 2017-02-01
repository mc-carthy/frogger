using UnityEngine;

public class FrogMovement : MonoBehaviour {

    [SerializeField]
    private Vector3 jumpForce;
    private Rigidbody rb;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody> ();
    }

	private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            rb.AddForce (jumpForce, ForceMode.VelocityChange);
        }
    }

}

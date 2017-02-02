using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class VehicleMovement : MonoBehaviour {

    private Rigidbody rb;
    private float speed = 1000;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody> ();
    }

    private void FixedUpdate ()
    {
        rb.MovePosition (transform.position + new Vector3 (-speed * Time.fixedDeltaTime, 0, 0));
    }

}

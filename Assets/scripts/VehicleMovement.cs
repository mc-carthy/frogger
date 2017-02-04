using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class VehicleMovement : MonoBehaviour {

    private Rigidbody rb;
    private float speed = 1000;
    private float xDir;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody> ();
        xDir = Mathf.Cos (Mathf.Deg2Rad * transform.parent.rotation.eulerAngles.y);
        Debug.Log (xDir);
    }

    private void FixedUpdate ()
    {
        rb.MovePosition (transform.position + new Vector3 (-speed * xDir * Time.fixedDeltaTime, 0, 0));
    }

}

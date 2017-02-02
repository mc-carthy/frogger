using UnityEngine;

public class VehicleMovement : MonoBehaviour {

    float speed = 1000;

    private void Update ()
    {
        transform.Translate (-speed * Time.deltaTime, 0, 0);
    }

}

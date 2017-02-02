using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;

    private float spawnIntervalMean = 8f;
    private float spawnIntervalMin = 2f;
	private float nextSpawnTime = 0f;

    private void Start ()
    {
        SetNewSpawnTime ();
    }

    private void Update ()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn ();
        }
    }

    private void Spawn ()
    {
        GameObject instance = Instantiate (prefab, transform.position, transform.rotation, transform) as GameObject;
        SetNewSpawnTime ();
    }

    private void SetNewSpawnTime ()
    {
        nextSpawnTime = Time.time + -Mathf.Log (Random.value) * spawnIntervalMean + nextSpawnTime;
    }

}

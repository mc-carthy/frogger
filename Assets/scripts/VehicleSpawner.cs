using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float spawnIntervalMean;
    [SerializeField]
    private float spawnIntervalMin;
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
        nextSpawnTime = Time.time + spawnIntervalMin - (Mathf.Log (Random.value) * spawnIntervalMean);
    }

}

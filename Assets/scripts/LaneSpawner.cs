using UnityEngine;

public class LaneSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] lanePrefabs;


    private void Start ()
    {
        CreateRandomLane (0);
        CreateRandomLane (10);
        CreateRandomLane (20);
        CreateRandomLane (30);
        CreateRandomLane (40);
    }

    private void CreateRandomLane (float offset)
    {
        int laneIndex = Random.Range (0, lanePrefabs.Length);
        GameObject lane = Instantiate (lanePrefabs [laneIndex]) as GameObject;
        lane.transform.parent = transform;
        lane.transform.position = new Vector3 (0, 0, offset);
    }
}

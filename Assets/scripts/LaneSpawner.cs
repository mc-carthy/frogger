using UnityEngine;

public class LaneSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] lanePrefabs;

    private int numStartLanes = 20;
    private int laneWidth = 10;

    private void Start ()
    {
        int offset = 0;
        while (offset < numStartLanes * laneWidth)
        {
            CreateRandomLane (offset);
            offset += laneWidth;
        }
    }

    private void CreateRandomLane (float offset)
    {
        int laneIndex = Random.Range (0, lanePrefabs.Length);
        GameObject lane = Instantiate (lanePrefabs [laneIndex]) as GameObject;
        lane.transform.parent = transform;
        lane.transform.position = new Vector3 (0, 0, offset);
    }
}

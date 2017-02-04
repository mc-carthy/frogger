using UnityEngine;

public enum LaneType { Safe, Danger }

public class LaneSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] safeLanePrefabs;
    [SerializeField]
    private GameObject[] dangerLanePrefabs;

    private LaneType lastLaneType = LaneType.Safe;
    private float safeLaneProbability = 0.2f;
    private int numStartLanes = 20;
    private int laneWidth = 1000;

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
        GameObject[] lanes;
        if (lastLaneType == LaneType.Danger)
        {
            lanes = safeLanePrefabs;
            lastLaneType = LaneType.Safe;
        }
        else
        {
            if (Random.value < safeLaneProbability)
            {
                lanes = safeLanePrefabs;
                lastLaneType = LaneType.Safe;
            }
            else
            {
                lanes = dangerLanePrefabs;
                lastLaneType = LaneType.Danger;
            }
        }
        GameObject lane = InstantiateRandomLane (lanes);
        lane.transform.SetParent(transform, false);
        lane.transform.localPosition = new Vector3 (0, 0, offset);
    }

    private GameObject InstantiateRandomLane (GameObject[] lanes)
    {
        int laneIndex = Random.Range (0, lanes.Length);
        return Instantiate (lanes [laneIndex]) as GameObject;
    }
}

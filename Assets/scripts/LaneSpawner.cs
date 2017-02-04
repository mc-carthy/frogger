using UnityEngine;

public enum LaneType { Safe, Danger }

public class LaneSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] safeLanePrefabs;
    [SerializeField]
    private GameObject[] dangerLanePrefabs;
    [SerializeField]
    private int numStartLanes;

    private GameObject player;
    private LaneType lastLaneType = LaneType.Safe;
    private float safeLaneProbability = 0.2f;
    private int laneWidth = 1000;
    private int offset = 0;

    private void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    private void Update ()
    {
        while (offset < numStartLanes * laneWidth + player.transform.position.z)
        {
            CreateRandomLane (offset);
            offset += laneWidth;
        }
        foreach (Transform lane in transform)
        {
            if (lane.transform.position.z + (numStartLanes * laneWidth) < player.transform.position.z)
            {
                Destroy (lane.gameObject);
            }
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

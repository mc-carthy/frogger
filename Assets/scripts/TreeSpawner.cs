using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	[SerializeField]
    private GameObject treePrefab;

    private int minTrees = 3;
    private int maxTrees = 15;

    private void Start ()
    {
        int numTrees = Random.Range (minTrees, maxTrees);
        for (int i = 0; i < numTrees; i++)
        {
            CreateTree ();
        }
    }

    private void CreateTree ()
    {
        GameObject tree = Instantiate (treePrefab) as GameObject;
        tree.transform.parent = transform;
        float randX = Random.Range (-4000f, 4000f);
        float randZ = Random.Range (-500f, 500f);
        tree.transform.localPosition = new Vector3 (randX, 0, randZ);
    }

}
